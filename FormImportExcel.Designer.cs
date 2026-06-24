using System.Drawing;
using System.Windows.Forms;

namespace UCP_1_Revisi
{
    partial class FormImportExcel
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtFilePath;
        private Button btnPilihFile;
        private Button btnImport;
        private Button btnClose;
        private DataGridView dgvPreview;
        private Label lblTotalData;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtFilePath = new TextBox();
            btnPilihFile = new Button();
            btnImport = new Button();
            btnClose = new Button();
            dgvPreview = new DataGridView();
            lblTotalData = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
            SuspendLayout();

            txtFilePath.Location = new Point(12, 12);
            txtFilePath.Size = new Size(450, 27);
            txtFilePath.ReadOnly = true;
            txtFilePath.PlaceholderText = "Pilih file Excel...";

            btnPilihFile.Text = "📂 Pilih File";
            btnPilihFile.Location = new Point(470, 10);
            btnPilihFile.Size = new Size(110, 32);
            btnPilihFile.BackColor = Color.FromArgb(52, 152, 219);
            btnPilihFile.ForeColor = Color.White;
            btnPilihFile.FlatStyle = FlatStyle.Flat;
            btnPilihFile.Click += btnPilihFile_Click;

            btnImport.Text = "⬆️ Import";
            btnImport.Location = new Point(590, 10);
            btnImport.Size = new Size(100, 32);
            btnImport.BackColor = Color.FromArgb(46, 204, 113);
            btnImport.ForeColor = Color.White;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Click += btnImport_Click;

            btnClose.Text = "❌ Tutup";
            btnClose.Location = new Point(700, 10);
            btnClose.Size = new Size(90, 32);
            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += btnClose_Click;

            dgvPreview.Location = new Point(12, 55);
            dgvPreview.Size = new Size(780, 350);
            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPreview.ReadOnly = true;
            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.RowHeadersVisible = false;

            lblTotalData.Text = "Total data: 0";
            lblTotalData.Location = new Point(12, 415);
            lblTotalData.Size = new Size(200, 25);

            ClientSize = new Size(810, 460);
            Text = "📤 Import Data Vaksin dari Excel";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Controls.Add(txtFilePath);
            Controls.Add(btnPilihFile);
            Controls.Add(btnImport);
            Controls.Add(btnClose);
            Controls.Add(dgvPreview);
            Controls.Add(lblTotalData);

            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}