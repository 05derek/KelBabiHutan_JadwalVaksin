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
            
        }
        private void SetupDataGridView()
        {
           
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
