using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private int userId; // Field to store the user_id

        // Constructor that accepts user_id as a parameter
        public Form3(int userId)
        {
            InitializeComponent();
            this.userId = userId; // Assign the passed user_id to the field
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
