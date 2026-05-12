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
           
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
           


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

