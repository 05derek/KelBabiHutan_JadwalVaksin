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
            // Setup BindingNavigator secara manual karena .NET 8 tidak memunculkannya di Toolbox
            bn = new BindingNavigator(true);
            this.Controls.Add(bn);
            bn.BindingSource = bsJadwal;

            tampilData();
        }
        
        //test
        private void tampilData()
        {
            using (SqlConnection conn = new SqlConnection(koneksi))
            {
                try
                {
                    // Query ini menghubungkan tabel jadwal dengan tabel vaksin
                    // v.nama_vaksin akan selalu mengambil data terbaru dari formVaksin
                    string query = @"SELECT j.jadwal_id, v.nama_vaksin, j.tanggal, j.waktu, j.kuota 
                             FROM jadwal j 
                             INNER JOIN vaksin v ON j.vaksin_id = v.vaksin_id";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bsJadwal.DataSource = dt;
                    dataGridView1.DataSource = bsJadwal;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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
