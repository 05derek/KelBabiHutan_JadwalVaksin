using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCP_1_Revisi
{
    public partial class FormJadwal : Form
    {
        // Sesuaikan string koneksi dengan database Anda
        string koneksi = "Data Source=DEREK-PC\\DEREKGANTENG;Initial Catalog=db_vaksin;Integrated Security=True;TrustServerCertificate=True";
        BindingSource bsJadwal = new BindingSource();
        BindingNavigator bn;

        private ComboBox comboBoxWaktu;
        private DateTimePicker dateTimePickerTanggal;
        private TextBox textBoxKuota;
        private DataGridView dataGridView1; // Pastikan ini hanya dideklarasikan sekali di FormJadwal.cs

        public FormJadwal()
        {
            InitializeComponent();
        }

        private void FormJadwal_Load(object sender, EventArgs e)
        {
          
        }
        
        //test
        private void tampilData()
        {
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void FormJadwal_Activated(object sender, EventArgs e)
        {
         
        }
    }
}
