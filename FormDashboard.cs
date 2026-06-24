using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UCP_1_Revisi
{
    public partial class FormDashboard : Form
    {
        private string connectionString = "Server=localhost;Database=db_vaksin;User Id=derek;Password=123;Encrypt=True;TrustServerCertificate=True;";

        public FormDashboard()
        {
            InitializeComponent();
            SetupChartTypes();
            LoadDashboardData();
        }

        private void SetupChartTypes()
        {
            cmbChartType.Items.Clear();
            cmbChartType.Items.Add("📊 Bar Chart");
            cmbChartType.Items.Add("📈 Column Chart");
            cmbChartType.Items.Add("🥧 Pie Chart");
            cmbChartType.SelectedIndex = 0;
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Total data
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM vaksin", conn);
                    lblTotalVaksin.Text = cmd.ExecuteScalar().ToString();

                    cmd = new SqlCommand("SELECT COUNT(*) FROM jadwal", conn);
                    lblTotalJadwal.Text = cmd.ExecuteScalar().ToString();

                    cmd = new SqlCommand("SELECT COUNT(*) FROM booking", conn);
                    lblTotalBooking.Text = cmd.ExecuteScalar().ToString();

                    cmd = new SqlCommand("SELECT ISNULL(SUM(kuota), 0) - ISNULL((SELECT COUNT(*) FROM booking), 0) FROM jadwal", conn);
                    lblKuotaTersedia.Text = cmd.ExecuteScalar().ToString();

                    // Data per vaksin
                    string query = @"SELECT 
                                        v.nama_vaksin,
                                        v.stok,
                                        COUNT(DISTINCT j.jadwal_id) AS total_jadwal,
                                        ISNULL(COUNT(b.booking_id), 0) AS total_booking
                                    FROM vaksin v
                                    LEFT JOIN jadwal j ON v.vaksin_id = j.vaksin_id
                                    LEFT JOIN booking b ON j.jadwal_id = b.jadwal_id
                                    GROUP BY v.vaksin_id, v.nama_vaksin, v.stok
                                    ORDER BY v.nama_vaksin";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvData.DataSource = dt;

                    LoadChart(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load dashboard: " + ex.Message);
            }
        }

        private void LoadChart(DataTable dt)
        {
            chartVaksin.Series.Clear();
            chartVaksin.Titles.Clear();

            Title title = new Title("📊 Statistik Data Vaksin", Docking.Top, new Font("Segoe UI", 14, FontStyle.Bold), Color.FromArgb(44, 62, 80));
            chartVaksin.Titles.Add(title);

            string selectedType = cmbChartType.SelectedItem?.ToString() ?? "📊 Bar Chart";

            if (selectedType.Contains("Pie"))
            {
                chartVaksin.Series.Clear();
                Series pieSeries = new Series("Data Vaksin")
                {
                    ChartType = SeriesChartType.Pie,
                    ChartArea = "ChartArea1"
                };
                chartVaksin.Series.Add(pieSeries);

                foreach (DataRow row in dt.Rows)
                {
                    string namaVaksin = row["nama_vaksin"].ToString();
                    int totalBooking = Convert.ToInt32(row["total_booking"]);
                    pieSeries.Points.AddXY(namaVaksin, totalBooking);
                    int index = pieSeries.Points.Count - 1;
                    pieSeries.Points[index].Label = $"{namaVaksin}\n{totalBooking}";
                    pieSeries.Points[index].LegendText = namaVaksin;
                    pieSeries.Points[index].Color = GetColor(index);
                }
                chartVaksin.Legends[0].Docking = Docking.Right;
            }
            else
            {
                Series seriesBooking = new Series("Total Booking") { ChartType = GetChartType(selectedType), ChartArea = "ChartArea1" };
                Series seriesStok = new Series("Stok Vaksin") { ChartType = GetChartType(selectedType), ChartArea = "ChartArea1" };
                Series seriesJadwal = new Series("Total Jadwal") { ChartType = GetChartType(selectedType), ChartArea = "ChartArea1" };
                chartVaksin.Series.Add(seriesBooking);
                chartVaksin.Series.Add(seriesStok);
                chartVaksin.Series.Add(seriesJadwal);

                foreach (DataRow row in dt.Rows)
                {
                    string namaVaksin = row["nama_vaksin"].ToString();
                    seriesBooking.Points.AddXY(namaVaksin, Convert.ToInt32(row["total_booking"]));
                    seriesStok.Points.AddXY(namaVaksin, Convert.ToInt32(row["stok"]));
                    seriesJadwal.Points.AddXY(namaVaksin, Convert.ToInt32(row["total_jadwal"]));
                }

                chartVaksin.ChartAreas[0].AxisX.Title = "Nama Vaksin";
                chartVaksin.ChartAreas[0].AxisY.Title = "Jumlah";
                chartVaksin.ChartAreas[0].AxisX.Interval = 1;
                chartVaksin.Legends[0].Docking = Docking.Bottom;

                foreach (Series series in chartVaksin.Series)
                {
                    series.IsValueShownAsLabel = true;
                }
            }

            chartVaksin.Invalidate();
            chartVaksin.Update();
        }

        private SeriesChartType GetChartType(string selectedType)
        {
            if (selectedType.Contains("Bar")) return SeriesChartType.Bar;
            if (selectedType.Contains("Column")) return SeriesChartType.Column;
            if (selectedType.Contains("Line")) return SeriesChartType.Line;
            return SeriesChartType.Column;
        }

        private Color GetColor(int index)
        {
            Color[] colors = { Color.FromArgb(52, 152, 219), Color.FromArgb(46, 204, 113), Color.FromArgb(231, 76, 60), Color.FromArgb(155, 89, 182), Color.FromArgb(241, 196, 15) };
            return colors[index % colors.Length];
        }

        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            FormCetakCrystal cetak = new FormCetakCrystal();
            cetak.ShowDialog();
        }

        private void btnDataVaksin_Click(object sender, EventArgs e)
        {
            FormJadwalVaksin admin = new FormJadwalVaksin();
            admin.Show();
            this.Hide();
        }
    }
}