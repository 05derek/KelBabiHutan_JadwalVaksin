using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace UCP_1_Revisi
{
    public partial class FormBooking : Form
    {
        string koneksi =
            "Data Source=DEREK-PC\\DEREKGANTENG;" +
            "Initial Catalog=db_vaksin;" +
            "Integrated Security=True; TrustServerCertificate=True;";

        BindingSource bsJadwal = new BindingSource();

        int selectedId = 0;
        public FormBooking()
        {
            InitializeComponent();

            tampilVaksin();
            tampilData();

            bsJadwal.PositionChanged += (s, e) =>
            {
                if (bsJadwal.Current != null)
                {
                    DataRowView row = (DataRowView)bsJadwal.Current;
                    selectedId = Convert.ToInt32(row["jadwal_id"]);
                }
            };

            // ISI COMBOBOX WAKTU
            comboBoxWaktu.Items.Add("08:00:00");
            comboBoxWaktu.Items.Add("10:00:00");
            comboBoxWaktu.Items.Add("13:00:00");
            comboBoxWaktu.Items.Add("15:00:00");
        }

        private void tampilVaksin()
        {
            SqlConnection conn =
                new SqlConnection(koneksi);

            try
            {
                conn.Open();

                string query =
                    "SELECT * FROM vaksin";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                MessageBox.Show(dt.Rows.Count.ToString());

                comboBoxVaksin.DataSource = dt;

                comboBoxVaksin.DisplayMember =
                    "nama_vaksin";

                comboBoxVaksin.ValueMember =
                    "vaksin_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void tampilData()
        {
            SqlConnection conn = new SqlConnection(koneksi);
            try
            {
                // Pindahkan pembuatan BindingNavigator ke Form_Load agar tidak double saat refresh data
                // bn.BindingSource = bsJadwal;

                conn.Open();
                string query = "SELECT jadwal.jadwal_id, jadwal.vaksin_id, vaksin.nama_vaksin, " +
                               "jadwal.tanggal, jadwal.waktu, jadwal.kuota FROM jadwal " +
                               "JOIN vaksin ON jadwal.vaksin_id = vaksin.vaksin_id";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                bsJadwal.DataSource = dt;
                dataGridView1.DataSource = bsJadwal;

                // Bersihkan binding sebelum menambah yang baru
                comboBoxWaktu.DataBindings.Clear();
                dateTimePicker.DataBindings.Clear();
                comboBoxVaksin.DataBindings.Clear();

                // PERBAIKAN DI SINI:
                // Gunakan "Text" untuk ComboBox yang isinya manual
                comboBoxWaktu.DataBindings.Add("Text", bsJadwal, "waktu", true, DataSourceUpdateMode.OnPropertyChanged);

                // Pastikan format tanggal sesuai
                dateTimePicker.DataBindings.Add("Value", bsJadwal, "tanggal", true, DataSourceUpdateMode.OnPropertyChanged);

                // Untuk comboBoxVaksin, pastikan DataSource-nya (daftar nama vaksin) sudah di-set sebelumnya
                comboBoxVaksin.DataBindings.Add("SelectedValue", bsJadwal, "vaksin_id", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex) { MessageBox.Show("Error Binding: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            SqlConnection conn =
        new SqlConnection(koneksi);

            try
            {
                conn.Open();

                string query =
                    "INSERT INTO jadwal " +
                    "(vaksin_id, tanggal, waktu, kuota) " +
                    "VALUES " +
                    "(@vaksin, @tanggal, @waktu, @kuota)";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@vaksin",
                    comboBoxVaksin.SelectedValue);



        }

        private void comboBoxVaksin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxWaktu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
        }

        private void FormBooking_Load(object sender, EventArgs e)
        {

        }

        private void btninjection_Click(object sender, EventArgs e)
        {
           
        }
    }
}

