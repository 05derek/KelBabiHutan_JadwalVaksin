using Microsoft.Data.SqlClient;

namespace UCP_1_Revisi
{
    public partial class FormAwal : Form
    {
        string koneksi =
            "Data Source=DEREK-PC\\DEREKGANTENG;" +
            "Initial Catalog=db_vaksin;" +
            "Integrated Security=True; TrustServerCertificate=True;";

        public FormAwal()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            SqlConnection conn =
            new SqlConnection(koneksi);

            FormSignUp daftar = new FormSignUp();
            daftar.Show();

            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(koneksi))
            {
                try
                {
                    // Query untuk mengambil role berdasarkan username dan password
                    string query = "SELECT role FROM users WHERE username=@username AND password=@password";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Sesuaikan 'textBox1' dan 'textBox2' dengan nama Name di Properties
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString().Trim();
                        MessageBox.Show("Role yang terbaca:'" + role + "'");

                        // Pengecekan Hak Akses
                        if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
                        {
                            // MEMBUKA FORM JADWAL (ADMIN)
                            FormAdmin adminForm = new FormAdmin();
                            adminForm.Show();
                        }
                        else
                        {
                            // MEMBUKA FORM BOOKING (USER)
                            FormBooking bookingForm = new FormBooking();
                            bookingForm.Show();
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
