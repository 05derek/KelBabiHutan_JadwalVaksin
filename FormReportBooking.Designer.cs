using System.Drawing;
using System.Windows.Forms;

namespace UCP_1_Revisi
{
    partial class FormReportBooking
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvReport;
        private Label lblTotal;
        private DateTimePicker dtpMulai;
        private DateTimePicker dtpSelesai;
        private Button btnFilter;
        private Button btnRefresh;
        private Button btnClose;
        private Label lblMulai;
        private Label lblSelesai;

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
            dgvReport = new DataGridView();
            lblTotal = new Label();
            dtpMulai = new DateTimePicker();
            dtpSelesai = new DateTimePicker();
            btnFilter = new Button();
            btnRefresh = new Button();
            btnClose = new Button();
            lblMulai = new Label();
            lblSelesai = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();

            // lblMulai
            lblMulai.Text = "Mulai:";
            lblMulai.Location = new Point(12, 15);
            lblMulai.Size = new Size(50, 25);

            // dtpMulai
            dtpMulai.Location = new Point(65, 12);
            dtpMulai.Size = new Size(150, 27);
            dtpMulai.Format = DateTimePickerFormat.Short;
            dtpMulai.Value = DateTime.Now.AddDays(-30);

            // lblSelesai
            lblSelesai.Text = "Selesai:";
            lblSelesai.Location = new Point(225, 15);
            lblSelesai.Size = new Size(60, 25);

            // dtpSelesai
            dtpSelesai.Location = new Point(290, 12);
            dtpSelesai.Size = new Size(150, 27);
            dtpSelesai.Format = DateTimePickerFormat.Short;
            dtpSelesai.Value = DateTime.Now;

            // btnFilter
            btnFilter.Text = "🔍 Filter";
            btnFilter.Location = new Point(450, 10);
            btnFilter.Size = new Size(90, 32);
            btnFilter.BackColor = Color.FromArgb(52, 152, 219);
            btnFilter.ForeColor = Color.White;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Click += btnFilter_Click;

            // btnRefresh
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.Location = new Point(550, 10);
            btnRefresh.Size = new Size(90, 32);
            btnRefresh.BackColor = Color.FromArgb(46, 204, 113);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Click += btnRefresh_Click;

            // btnClose
            btnClose.Text = "❌ Tutup";
            btnClose.Location = new Point(650, 10);
            btnClose.Size = new Size(90, 32);
            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += btnClose_Click;

            // lblTotal
            lblTotal.Text = "Total Data: 0";
            lblTotal.Location = new Point(12, 55);
            lblTotal.Size = new Size(200, 25);
            lblTotal.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // dgvReport
            dgvReport.Location = new Point(12, 85);
            dgvReport.Size = new Size(780, 350);
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.ReadOnly = true;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowTemplate.Height = 30;

            // FormReportBooking
            ClientSize = new Size(810, 460);
            Text = "📊 Laporan Booking Vaksin";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Controls.Add(lblMulai);
            Controls.Add(dtpMulai);
            Controls.Add(lblSelesai);
            Controls.Add(dtpSelesai);
            Controls.Add(btnFilter);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            Controls.Add(lblTotal);
            Controls.Add(dgvReport);

            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}