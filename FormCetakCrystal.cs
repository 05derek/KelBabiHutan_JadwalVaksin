using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace UCP_1_Revisi
{
    public partial class FormCetakCrystal : Form
    {
        private string connectionString = "Server=localhost;Database=db_vaksin;User Id=derek;Password=123;Encrypt=True;TrustServerCertificate=True;";

        public FormCetakCrystal()
        {
            InitializeComponent();  // ← Panggil dari Designer.cs
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
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
                    da.Fill(dt);
                }

                // Tampilkan data di DataGridView
                DataGridView dgv = new DataGridView();
                dgv.Dock = DockStyle.Fill;
                dgv.DataSource = dt;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = false;
                dgv.RowHeadersVisible = false;
                dgv.RowTemplate.Height = 30;
                this.Controls.Add(dgv);

                Label lblTotal = new Label();
                lblTotal.Text = $"Total Data: {dt.Rows.Count}";
                lblTotal.Dock = DockStyle.Top;
                lblTotal.Height = 30;
                lblTotal.Padding = new Padding(10);
                lblTotal.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
                lblTotal.ForeColor = System.Drawing.Color.White;
                this.Controls.Add(lblTotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}