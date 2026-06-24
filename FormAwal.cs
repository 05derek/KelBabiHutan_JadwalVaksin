using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace UCP_1_Revisi
{
    public partial class FormAwal : Form
    {
        string Koneksi = "Server=localhost;Database=db_vaksin;User Id=derek;Password=123;Encrypt=True;TrustServerCertificate=True;";

        public FormAwal()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Biarkan kosong
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            FormSignUp daftar = new FormSignUp();
            daftar.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Koneksi))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Login", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string role = reader["role"].ToString();

                        // ===== SIMPAN SESSION =====
                        Session.UserId = Convert.ToInt32(reader["user_id"]);
                        Session.Username = reader["username"].ToString();
                        Session.Role = role;

                        if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                        {
                            FormJadwalVaksin adminForm = new FormJadwalVaksin();
                            adminForm.Show();
                        }
                        else
                        {
                            FormBooking bookingForm = new FormBooking();
                            bookingForm.Show();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void FormAwal_Load(object sender, EventArgs e)
        {
        }
    }
}