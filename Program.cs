using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCP_1_Revisi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Pilih form mana yang ingin dijalankan pertama kali saat aplikasi dibuka
            // Jika Form revisi kamu bernama FormAwal:
            Application.Run(new FormAwal());

            // Atau jika ingin tetap menggunakan Form4 dari repo lama:
            // Application.Run(new Form4());
        }
    }
}