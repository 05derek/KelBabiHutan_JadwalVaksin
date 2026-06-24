using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

namespace UCP_1_Revisi
{
    public partial class FormImportExcel : Form
    {
        private string connectionString = "Server=localhost;Database=db_vaksin;User Id=derek;Password=123;Encrypt=True;TrustServerCertificate=True;";
        private DataTable dtExcel = new DataTable();

        public FormImportExcel()
        {
            InitializeComponent();
        }

        private void btnPilihFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";
            ofd.Title = "Pilih File Excel Vaksin";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
                LoadExcelData(ofd.FileName);
            }
        }

        private void LoadExcelData(string filePath)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        dtExcel = result.Tables[0];
                        dgvPreview.DataSource = dtExcel;
                        lblTotalData.Text = $"Total data: {dtExcel.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load Excel: " + ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dtExcel.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diimport!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    int success = 0;
                    int failed = 0;

                    foreach (DataRow row in dtExcel.Rows)
                    {
                        try
                        {
                            string namaVaksin = row["nama_vaksin"].ToString();
                            int stok = Convert.ToInt32(row["stok"]);

                            if (!string.IsNullOrEmpty(namaVaksin))
                            {
                                SqlCommand cmd = new SqlCommand("sp_ImportVaksin", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@nama_vaksin", namaVaksin);
                                cmd.Parameters.AddWithValue("@stok", stok);
                                cmd.ExecuteNonQuery();
                                success++;
                            }
                        }
                        catch
                        {
                            failed++;
                        }
                    }

                    MessageBox.Show($"Import selesai!\nBerhasil: {success}\nGagal: {failed}",
                        "Hasil Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error import: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}