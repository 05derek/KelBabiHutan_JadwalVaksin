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
    public partial class FormSignUp : Form
    {
        string koneksi =
            "Data Source=DEREK-PC\\DEREKGANTENG;" +
            "Initial Catalog=db_vaksin;" +
            "Integrated Security=True; TrustServerCertificate=True;";

        public FormSignUp()
        {
            InitializeComponent();
            textBoxNIK.MaxLength = 16;
            textBox3.MaxLength = 13;
            textBox5.UseSystemPasswordChar = true;
        }

        private void textBoxNIK_TextChanged(object sender, EventArgs e)
        {
            string angka = new string(textBoxNIK.Text
        .Where(char.IsDigit)
        .ToArray());

            if (textBoxNIK.Text != angka)
            {
                int posisi = textBoxNIK.SelectionStart - 1;

                textBoxNIK.Text = angka;
                textBoxNIK.SelectionStart = Math.Max(posisi, 0);
            }


        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // VALIDASI NIK
            if (textBoxNIK.Text.Length != 16)
            {
                MessageBox.Show("NIK harus 16 digit!");
                textBoxNIK.Focus();
                return;
            }

            // VALIDASI NO HP
            if (textBox3.Text.Length < 11 ||
                textBox3.Text.Length > 13)
            {
                MessageBox.Show("Nomor HP harus 11 - 13 digit!");
                textBox3.Focus();
                return;
            }

           

            try
            {
                using (SqlConnection conn = new SqlConnection(koneksi))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // PARAMETER
                        cmd.Parameters.AddWithValue("@nik", textBoxNIK.Text);
                        cmd.Parameters.AddWithValue("@nama", textBox2.Text);
                        cmd.Parameters.AddWithValue("@no_hp", textBox3.Text);
                        cmd.Parameters.AddWithValue("@username", textBox4.Text);
                        cmd.Parameters.AddWithValue("@password", textBox5.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show(
                    "Pendaftaran berhasil!");

                // PINDAH KE LOGIN
                FormAwal login =
                    new FormAwal();

                login.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // hanya boleh angka
            textBox3.Text = new string(textBox3.Text
                .Where(char.IsDigit)
                .ToArray());

            // cursor tetap di belakang
            textBox3.SelectionStart = textBox3.Text.Length;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
