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
    public partial class FormVaksin : Form
    {
        string connectionString = "Server=DEREK-PC\\DEREKGANTENG;Database=db_vaksin;Trusted_Connection=True;TrustServerCertificate=True;";
        SqlDataAdapter adapter;
        DataTable dtVaksin;
        public FormVaksin()
        {
            InitializeComponent();
        }
        private void btnKembali_Click(object sender, EventArgs e)
        {
            FormAdmin admin = new FormAdmin();
            admin.Show();

            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Mohon isi semua field sebelum menambahkan data.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO vaksin (nama_vaksin, stok) VALUES (@nama_vaksin, @stok)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama_vaksin", comboBox1.Text);
                cmd.Parameters.AddWithValue("@stok", textBox1.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data vaksin berhasil ditambahkan.");
                LoadData(); // Method untuk memuat ulang data setelah penambahan
                ClearInput(); // Method untuk membersihkan input setelah penambahan
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Mengambil ID dari baris yang dipilih di grid
                    string id = dataGridView1.CurrentRow.Cells["vaksin_id"].Value.ToString();


                    string query = "UPDATE vaksin SET nama_vaksin = @nama, stok = @stok WHERE vaksin_id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@stok", textBox1.Text);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Data Vaksin Berhasil Diperbarui!");
                    LoadData();
                    ClearInput();
                }
            }
            else
            {
                MessageBox.Show("Mohon pilih data yang ingin diubah.");
            }
        }


        // Tombol Hapus di FormVaksin
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string idVaksin = dataGridView1.CurrentRow.Cells["vaksin_id"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Hapus data di tabel jadwal dulu agar tidak terjadi error Foreign Key
                    string deleteJadwal = "DELETE FROM jadwal WHERE vaksin_id = @id";
                    SqlCommand cmd1 = new SqlCommand(deleteJadwal, conn);
                    cmd1.Parameters.AddWithValue("@id", idVaksin);
                    cmd1.ExecuteNonQuery();

                    // Kemudian hapus data di tabel vaksin
                    string deleteVaksin = "DELETE FROM vaksin WHERE vaksin_id = @id";
                    SqlCommand cmd2 = new SqlCommand(deleteVaksin, conn);
                    cmd2.Parameters.AddWithValue("@id", idVaksin);
                    cmd2.ExecuteNonQuery();

                    conn.Close();
                    LoadData(); // DataGrid di FormVaksin langsung bersih
                }
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Pastikan nama tabel sesuai dengan yang ada di SQL Server Anda
                    string query = "SELECT vaksin_id, nama_vaksin, stok FROM vaksin";
                    adapter = new SqlDataAdapter(query, conn);
                    dtVaksin = new DataTable();
                    adapter.Fill(dtVaksin);
                    dataGridView1.DataSource = dtVaksin;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }
        }

        private void FormVaksin_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["nama_vaksin"].Value.ToString();
                textBox1.Text = row.Cells["stok"].Value.ToString();
            }
        }
        private void ClearInput()
        {
            comboBox1.SelectedIndex = -1;
            // Jika di Design namanya textBox1, ganti kode di bawah ini jadi textBox1.Clear();
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
