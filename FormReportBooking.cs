using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace UCP_1_Revisi
{
    public partial class FormReportBooking : Form
    {
        private string connectionString = "Server=localhost;Database=db_vaksin;User Id=derek;Password=123;Encrypt=True;TrustServerCertificate=True;";

        public FormReportBooking()
        {
            InitializeComponent();
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // ===== PAKAI SP_REPORTBOOKING =====
                    SqlCommand cmd = new SqlCommand("sp_ReportBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tanggal_mulai", DBNull.Value);
                    cmd.Parameters.AddWithValue("@tanggal_selesai", DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReport.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        lblTotal.Text = $"Total Data: {dt.Rows.Count}";
                    }
                    else
                    {
                        lblTotal.Text = "Tidak ada data booking";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load report: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DateTime mulai = dtpMulai.Value.Date;
                    DateTime selesai = dtpSelesai.Value.Date;

                    SqlCommand cmd = new SqlCommand("sp_ReportBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tanggal_mulai", mulai);
                    cmd.Parameters.AddWithValue("@tanggal_selesai", selesai);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReport.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        lblTotal.Text = $"Total Data: {dt.Rows.Count} (Filter: {mulai:dd/MM/yyyy} - {selesai:dd/MM/yyyy})";
                    }
                    else
                    {
                        lblTotal.Text = $"Tidak ada data booking untuk periode {mulai:dd/MM/yyyy} - {selesai:dd/MM/yyyy}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filter: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}