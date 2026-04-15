using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        private int userId;
        private int bookingId;
        private SqlConnection conn;
        private string connectionString = "Server=DEREK-PC\\DEREKGANTENG;Database=BookingVaksinDB;Trusted_Connection=True;";
        public Form6(int bookingId, int userId)
        {
            InitializeComponent();
            this.bookingId = bookingId;
            this.userId = userId;

            // Daftarkan event Load
            this.Load += Form6_Load;
        }



        private void Form6_Load(object sender, EventArgs e)
        {
            // Ambil detail data booking saat form terbuka
            LoadData();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Query untuk mengambil detail booking beserta info jadwalnya
                    string query = @"
                        SELECT b.booking_id, b.user_id, b.jadwal_id, j.tanggal, j.waktu 
                        FROM Booking b
                        LEFT JOIN Jadwal j ON b.jadwal_id = j.jadwal_id
                        WHERE b.booking_id = @Bid";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Bid", bookingId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Isi TextBox berdasarkan data dari database
                            textBox1.Text = reader["booking_id"].ToString();
                            textBox2.Text = reader["user_id"].ToString();
                            textBox3.Text = reader["jadwal_id"].ToString();

                            // Jika kamu punya label tambahan untuk info tanggal/waktu
                            // lblInfo.Text = $"Jadwal saat ini: {reader["tanggal"]} jam {reader["waktu"]}";
                        }
                        else
                        {
                            MessageBox.Show("Data booking tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat detail data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






        private void button1_Click(object sender, EventArgs e)
        {
            // Validasi input: Pastikan Jadwal ID baru sudah diisi
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Silahkan isi Jadwal ID baru!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query UPDATE
                    string query = "UPDATE Booking SET jadwal_id = @Jid WHERE booking_id = @Bid";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Jid", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Bid", this.bookingId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Jadwal Berhasil Diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Mengirim sinyal OK agar Form5 tahu harus me-refresh data
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Gagal memperbarui: ID Booking tidak ditemukan di sistem.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Menangkap error Foreign Key (ID Jadwal tidak ada di tabel Jadwal)
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Error: ID Jadwal yang kamu masukkan tidak terdaftar di sistem!", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Error SQL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }
    }
}

                


        
    

