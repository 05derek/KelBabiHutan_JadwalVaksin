using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        private int userId;
        private string connectionString = "Server=DEREK-PC\\DEREKGANTENG;Database=BookingVaksinDB;Trusted_Connection=True;";
        public Form5(int id)
        {
            InitializeComponent();
            this.userId = id;
            // Pastikan event Load terhubung
            this.Load += Form5_Load;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Query JOIN untuk mengambil detail tanggal dan waktu dari tabel Jadwal
                    string query = @"
                        SELECT 
                            b.booking_id AS [ID Booking], 
                            j.tanggal AS [Tanggal], 
                            j.waktu AS [Waktu],
                            b.status AS [Status]
                        FROM Booking b
                        INNER JOIN Jadwal j ON b.jadwal_id = j.jadwal_id
                        WHERE b.user_id = @UserId";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@UserId", this.userId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Refresh DataSource
                    dgvbooking.DataSource = null;
                    dgvbooking.DataSource = dt;

                    // Pengaturan tampilan Grid otomatis
                    SetupDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SetupDataGridView()
        {
            if (dgvbooking.Columns.Count > 0)
            {
                // Sembunyikan ID Booking agar tidak membingungkan user, tapi tetap bisa diakses kode
                if (dgvbooking.Columns["ID Booking"] != null)
                    dgvbooking.Columns["ID Booking"].Visible = false;

                // Membuat kolom mengisi seluruh area DataGridView
                dgvbooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvbooking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvbooking.MultiSelect = false;
                dgvbooking.AllowUserToAddRows = false;
                dgvbooking.ReadOnly = true;
            }
        }



        // Tombol Edit / Reschedule
        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        
        


        private void dgvbooking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            }

        }
    }
