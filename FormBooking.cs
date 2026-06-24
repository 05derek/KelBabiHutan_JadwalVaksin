using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace UCP_1_Revisi
{
    public partial class FormBooking : Form
    {
        string Koneksi = "Server=localhost;Database=db_vaksin;User Id=derek;Password=123;Encrypt=True;TrustServerCertificate=True;";
        BindingSource bsJadwal = new BindingSource();
        int selectedId = 0;
        int userId = 0; // Tambahkan ini untuk menyimpan user_id

        public FormBooking()
        {
            InitializeComponent();

            // Ambil user_id dari Session
            userId = Session.UserId;

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

            comboBoxWaktu.Items.Add("08:00:00");
            comboBoxWaktu.Items.Add("10:00:00");
            comboBoxWaktu.Items.Add("13:00:00");
            comboBoxWaktu.Items.Add("15:00:00");
        }

        private void tampilVaksin()
        {
            SqlConnection conn = new SqlConnection(Koneksi);
            try
            {
                conn.Open();
                string query = "SELECT * FROM vaksin";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxVaksin.DataSource = dt;
                comboBoxVaksin.DisplayMember = "nama_vaksin";
                comboBoxVaksin.ValueMember = "vaksin_id";
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
            SqlConnection conn = new SqlConnection(Koneksi);
            try
            {
                conn.Open();
                string query = "SELECT jadwal.jadwal_id, jadwal.vaksin_id, vaksin.nama_vaksin, " +
                               "jadwal.tanggal, jadwal.waktu, jadwal.kuota FROM jadwal " +
                               "JOIN vaksin ON jadwal.vaksin_id = vaksin.vaksin_id";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                bsJadwal.DataSource = dt;
                dataGridView1.DataSource = bsJadwal;

                comboBoxWaktu.DataBindings.Clear();
                dateTimePicker.DataBindings.Clear();
                comboBoxVaksin.DataBindings.Clear();

                comboBoxWaktu.DataBindings.Add("Text", bsJadwal, "waktu", true, DataSourceUpdateMode.OnPropertyChanged);
                dateTimePicker.DataBindings.Add("Value", bsJadwal, "tanggal", true, DataSourceUpdateMode.OnPropertyChanged);
                comboBoxVaksin.DataBindings.Add("SelectedValue", bsJadwal, "vaksin_id", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex) { MessageBox.Show("Error Binding: " + ex.Message); }
            finally { conn.Close(); }
        }

        // ==================== BTN SIMPAN (BOOKING) ====================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Pilih jadwal terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conn = new SqlConnection(Koneksi);
            try
            {
                conn.Open();

                // ===== AMBIL DATA USER DARI DATABASE =====
                string queryUser = "SELECT nik, nama, no_hp FROM users WHERE user_id = @user_id";
                SqlCommand cmdUser = new SqlCommand(queryUser, conn);
                cmdUser.Parameters.AddWithValue("@user_id", userId);
                SqlDataReader reader = cmdUser.ExecuteReader();

                string nik = "", nama = "", noHp = "";
                if (reader.Read())
                {
                    nik = reader["nik"].ToString();
                    nama = reader["nama"].ToString();
                    noHp = reader["no_hp"].ToString();
                }
                reader.Close();

                // ===== INSERT BOOKING =====
                SqlCommand cmd = new SqlCommand("sp_InsertBooking", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@jadwal_id", selectedId);
                cmd.Parameters.AddWithValue("@nik", nik);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@no_hp", noHp);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Booking berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tampilData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bsJadwal.EndEdit();

            if (selectedId == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }

            SqlConnection conn = new SqlConnection(Koneksi);
            try
            {
                conn.Open();
                string query = "UPDATE jadwal SET vaksin_id = @vaksin, tanggal = @tanggal, waktu = @waktu WHERE jadwal_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@vaksin", comboBoxVaksin.SelectedValue);
                cmd.Parameters.AddWithValue("@tanggal", dateTimePicker.Value.Date);
                cmd.Parameters.AddWithValue("@waktu", comboBoxWaktu.Text);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Jadwal berhasil diupdate!");
                tampilData();
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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }

            SqlConnection conn = new SqlConnection(Koneksi);
            try
            {
                conn.Open();
                string query = "DELETE FROM jadwal WHERE jadwal_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Jadwal berhasil dihapus!");
                tampilData();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["jadwal_id"].Value);
                comboBoxVaksin.Text = row.Cells["nama_vaksin"].Value.ToString();
                dateTimePicker.Value = Convert.ToDateTime(row.Cells["tanggal"].Value);
                comboBoxWaktu.Text = row.Cells["waktu"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormAwal awal = new FormAwal();
            awal.Show();
            this.Hide();
        }

        private void btninjection_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Koneksi))
                {
                    conn.Open();
                    string query = "UPDATE jadwal SET kuota = 999 WHERE jadwal_id = " + selectedId;
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show(result + " baris berhasil diubah (Simulasi Injection)");
                    }
                }
                tampilData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Simulasi: " + ex.Message);
            }
        }

        private void FormBooking_Load(object sender, EventArgs e) { }

        private void comboBoxVaksin_SelectedIndexChanged(object sender, EventArgs e) { }

        private void comboBoxWaktu_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}