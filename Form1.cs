using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        private SqlConnection conn; // Moved inside the class to fix CS8370 and CS0168

        public Form1()
        {
            InitializeComponent();
        }

        private void Koneksi()
        {
            conn = new SqlConnection("Server=DEREK-PC\\DEREKGANTENG;Database=BookingVaksinDB;Trusted_Connection=True;"); // Initialize the connection
            conn.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input (Lengkapi Profil)
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("NIK dan Nama wajib diisi!");
                return;
            }

            try
            {
                Koneksi(); // Memanggil fungsi koneksi yang sudah Anda buat

                // 2. Sesuaikan Query dengan tabel 'Users' yang baru Anda buat
                // Kita mendaftarkan user baru sebagai 'pasien' secara default
                string query = @"INSERT INTO Users (nik, nama, no_hp, username, password, role) 
                         VALUES (@NIK, @Nama, @NoHP, @Username, @Password, 'pasien')";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Menyesuaikan parameter dengan nama kolom di database baru
                    cmd.Parameters.AddWithValue("@NIK", textBox1.Text);      // NIK
                    cmd.Parameters.AddWithValue("@Nama", textBox2.Text);     // Nama
                    cmd.Parameters.AddWithValue("@NoHP", textBox3.Text);     // No HP
                    cmd.Parameters.AddWithValue("@Username", textBox4.Text); // Username
                    cmd.Parameters.AddWithValue("@Password", textBox5.Text); // Password

                    int result = cmd.ExecuteNonQuery();

                    // Di dalam Form1.cs bagian button1_Click
                    if (result > 0)
                    {
                        MessageBox.Show("Registrasi Pasien Berhasil!");
                        ClearForm();

                        // PINDAH KE FORM LOGIN
                        Form2 loginForm = new Form2();
                        loginForm.Show();
                        this.Hide(); // Sembunyikan form registrasi
                    }
                }
            }
            catch (Exception ex)
            {
                // Menampilkan pesan error yang lebih spesifik jika NIK atau Username sudah ada (Unique Constraint)
                MessageBox.Show("Gagal Registrasi: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 loginForm = new Form2();
            loginForm.Show();
            this.Hide();
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}

