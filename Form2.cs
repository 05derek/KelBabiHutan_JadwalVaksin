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
           
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}

