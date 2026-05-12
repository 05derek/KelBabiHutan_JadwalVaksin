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

        // --- TOMBOL TAMBAH ---
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(koneksi))
            {
                // Tambahkan kolom vaksin_id dalam query insert
                string query = "INSERT INTO jadwal (tanggal, waktu, kuota, vaksin_id) VALUES (@tgl, @waktu, @kuota, @v_id)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tgl", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@waktu", comboBox1.Text);
                cmd.Parameters.AddWithValue("@kuota", textBox1.Text);

                
                conn.Open();
                MessageBox.Show("Jadwal Berhasil Ditambahkan!");
                tampilData();
            }
        }

        // --- TOMBOL UPDATE ---
        private void button2_Click(object sender, EventArgs e)
        {
            if (bsJadwal.Current == null) return;

            // Pastikan perubahan di UI masuk ke BindingSource
            bsJadwal.EndEdit();

            DataRowView row = (DataRowView)bsJadwal.Current;
            int id = (int)row["jadwal_id"];

            using (SqlConnection conn = new SqlConnection(koneksi))
            {
                string query = "UPDATE jadwal SET tanggal=@tgl, waktu=@waktu, kuota=@kuota WHERE jadwal_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tgl", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@waktu", comboBox1.Text);
                cmd.Parameters.AddWithValue("@kuota", textBox1.Text);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diupdate!");

                tampilData(); // Refresh grid
            }
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
