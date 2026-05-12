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
            
        }
    }
}
