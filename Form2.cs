using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private SqlConnection conn; // Declare the connection field

        public Form2()
        {
            InitializeComponent();
        }

        private void Koneksi()
        {
            conn = new SqlConnection("Server=DEREK-PC\\DEREKGANTENG;Database=BookingVaksinDB;Trusted_Connection=True;");
            conn.Open();
        }

        // Ganti isi button1_Click pada Form2 Anda menjadi seperti ini:
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Username dan Password wajib diisi!");
                return;
            }

            try
            {
                Koneksi();

                string query = "SELECT user_id FROM Users WHERE username = @Username AND password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int userId = Convert.ToInt32(result);

                        MessageBox.Show("Login Berhasil!");

                        // 👉 Pindah ke Form3 + kirim user_id
                        Form3 f3 = new Form3(userId);
                        f3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 regisForm = new Form1();
            regisForm.Show();
            this.Hide();
        }
    }
}

