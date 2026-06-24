using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace UCP_1_Revisi
{
    public partial class FormJadwalVaksin : Form
    {
        private string connectionString = "Server=localhost;Database=db_vaksin;User Id=derek;Password=123;Encrypt=True;TrustServerCertificate=True;";

        private BindingSource bsJadwal = new BindingSource();
        private BindingSource bsVaksin = new BindingSource();

        public FormJadwalVaksin()
        {
            InitializeComponent();

            dgvVaksin.DataSource = bsVaksin;
            dgvJadwal.DataSource = bsJadwal;

            dgvVaksin.Columns.Clear();
            dgvVaksin.AutoGenerateColumns = true;
            dgvJadwal.Columns.Clear();
            dgvJadwal.AutoGenerateColumns = true;

            RegisterEvents();
            LoadAllData();
        }

        private void RegisterEvents()
        {
            btnTambahJadwal.Click += BtnTambahJadwal_Click;
            btnUpdateJadwal.Click += BtnUpdateJadwal_Click;
            btnHapusJadwal.Click += BtnHapusJadwal_Click;
            btnRefreshJadwal.Click += (s, e) => LoadJadwal();

            btnTambahVaksin.Click += BtnTambahVaksin_Click;
            btnUpdateVaksin.Click += BtnUpdateVaksin_Click;
            btnHapusVaksin.Click += BtnHapusVaksin_Click;
            btnRefreshVaksin.Click += (s, e) => LoadVaksin();

            btnImportExcel.Click += (s, e) =>
            {
                FormImportExcel import = new FormImportExcel();
                if (import.ShowDialog() == DialogResult.OK)
                {
                    LoadVaksin();
                    LoadDashboardData();
                    LoadVaksinComboBox(); // ===== REFRESH COMBOBOX =====
                }
            };

            btnReport.Click += (s, e) =>
            {
                FormReportBooking report = new FormReportBooking();
                report.ShowDialog();
            };

            btnCetak.Click += (s, e) =>
            {
                formCetak cetak = new formCetak();
                cetak.ShowDialog();
            };

            btnLogout.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show("Yakin ingin logout?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FormAwal login = new FormAwal();
                    login.Show();
                    this.Close();
                }
            };

            dgvJadwal.CellClick += DgvJadwal_CellClick;
            dgvVaksin.CellClick += DgvVaksin_CellClick;
        }

        private void LoadAllData()
        {
            LoadVaksinComboBox();
            LoadJadwal();
            LoadVaksin();
            LoadDashboardData();
        }

        private void LoadVaksinComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllVaksin", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        cmbVaksinJadwal.DataSource = dt;
                        cmbVaksinJadwal.DisplayMember = "nama_vaksin";
                        cmbVaksinJadwal.ValueMember = "vaksin_id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load vaksin combo: " + ex.Message);
            }
        }

        private void LoadJadwal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllJadwal", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bsJadwal.DataSource = dt;
                    dgvJadwal.DataSource = null;
                    dgvJadwal.DataSource = bsJadwal;
                    dgvJadwal.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load jadwal: " + ex.Message);
            }
        }

        private void LoadVaksin()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllVaksin", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bsVaksin.DataSource = dt;
                    dgvVaksin.DataSource = null;
                    dgvVaksin.DataSource = bsVaksin;
                    dgvVaksin.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load vaksin: " + ex.Message);
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_DashboardData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        lblTotalVaksin.Text = ds.Tables[0].Rows[0]["total_vaksin"].ToString();

                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        lblTotalJadwal.Text = ds.Tables[1].Rows[0]["total_jadwal"].ToString();

                    if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                        lblTotalBooking.Text = ds.Tables[2].Rows[0]["total_booking"].ToString();

                    if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                        lblKuotaTersedia.Text = ds.Tables[3].Rows[0]["kuota_tersedia"].ToString();

                    if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                    {
                        dgvRingkasan.DataSource = ds.Tables[4];
                    }
                    else
                    {
                        DataTable emptyDt = new DataTable();
                        emptyDt.Columns.Add("nama_vaksin");
                        emptyDt.Columns.Add("total_jadwal");
                        emptyDt.Columns.Add("total_kuota");
                        emptyDt.Columns.Add("total_booking");
                        dgvRingkasan.DataSource = emptyDt;
                    }
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("booking"))
                {
                    MessageBox.Show("Error load dashboard: " + ex.Message);
                }
            }
        }

        private void DgvJadwal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && bsJadwal.Current != null)
            {
                DataRowView row = (DataRowView)bsJadwal.Current;
                if (row != null)
                {
                    try { cmbVaksinJadwal.SelectedValue = row["vaksin_id"]; } catch { }
                    dtpTanggalJadwal.Value = Convert.ToDateTime(row["tanggal"]);
                    cmbWaktuJadwal.Text = row["waktu"].ToString();
                    nudKuotaJadwal.Value = Convert.ToDecimal(row["kuota"]);
                }
            }
        }

        private void DgvVaksin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && bsVaksin.Current != null)
            {
                DataRowView row = (DataRowView)bsVaksin.Current;
                if (row != null)
                {
                    txtNamaVaksin.Text = row["nama_vaksin"].ToString();
                    nudStokVaksin.Value = Convert.ToDecimal(row["stok"]);
                }
            }
        }

        private void BtnTambahJadwal_Click(object sender, EventArgs e)
        {
            if (cmbVaksinJadwal.SelectedValue == null || string.IsNullOrEmpty(cmbWaktuJadwal.Text))
            {
                MessageBox.Show("Lengkapi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertJadwal", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vaksin_id", cmbVaksinJadwal.SelectedValue);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggalJadwal.Value.Date);
                    cmd.Parameters.AddWithValue("@waktu", cmbWaktuJadwal.Text);
                    cmd.Parameters.AddWithValue("@kuota", (int)nudKuotaJadwal.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Jadwal berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadJadwal();
                    LoadDashboardData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateJadwal_Click(object sender, EventArgs e)
        {
            if (bsJadwal.Current == null)
            {
                MessageBox.Show("Pilih data yang akan diupdate!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DataRowView row = (DataRowView)bsJadwal.Current;
                int id = (int)row["jadwal_id"];

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateJadwal", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@jadwal_id", id);
                    cmd.Parameters.AddWithValue("@vaksin_id", cmbVaksinJadwal.SelectedValue);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggalJadwal.Value.Date);
                    cmd.Parameters.AddWithValue("@waktu", cmbWaktuJadwal.Text);
                    cmd.Parameters.AddWithValue("@kuota", (int)nudKuotaJadwal.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Jadwal berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadJadwal();
                    LoadDashboardData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHapusJadwal_Click(object sender, EventArgs e)
        {
            if (bsJadwal.Current == null)
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus jadwal ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRowView row = (DataRowView)bsJadwal.Current;
                    int id = (int)row["jadwal_id"];

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("sp_DeleteJadwal", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jadwal_id", id);
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Jadwal berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadJadwal();
                        LoadDashboardData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnTambahVaksin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaVaksin.Text))
            {
                MessageBox.Show("Masukkan nama vaksin!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertVaksin", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nama_vaksin", txtNamaVaksin.Text.Trim());
                    cmd.Parameters.AddWithValue("@stok", (int)nudStokVaksin.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Vaksin berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVaksin();
                    LoadVaksinComboBox();
                    LoadDashboardData();
                    txtNamaVaksin.Clear();
                    nudStokVaksin.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateVaksin_Click(object sender, EventArgs e)
        {
            if (bsVaksin.Current == null)
            {
                MessageBox.Show("Pilih data yang akan diupdate!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNamaVaksin.Text))
            {
                MessageBox.Show("Masukkan nama vaksin!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataRowView row = (DataRowView)bsVaksin.Current;
                int id = (int)row["vaksin_id"];

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateVaksin", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vaksin_id", id);
                    cmd.Parameters.AddWithValue("@nama_vaksin", txtNamaVaksin.Text.Trim());
                    cmd.Parameters.AddWithValue("@stok", (int)nudStokVaksin.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Vaksin berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVaksin();
                    LoadVaksinComboBox();
                    LoadDashboardData();
                    txtNamaVaksin.Clear();
                    nudStokVaksin.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHapusVaksin_Click(object sender, EventArgs e)
        {
            if (bsVaksin.Current == null)
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus vaksin ini?\nData jadwal terkait juga akan dihapus!", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRowView row = (DataRowView)bsVaksin.Current;
                    int id = (int)row["vaksin_id"];

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("sp_DeleteVaksin", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vaksin_id", id);
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Vaksin berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadVaksin();
                        LoadVaksinComboBox();
                        LoadDashboardData();
                        txtNamaVaksin.Clear();
                        nudStokVaksin.Value = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}