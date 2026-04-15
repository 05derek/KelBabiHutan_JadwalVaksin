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

                    }


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

     
                }
            }

                


        
    

