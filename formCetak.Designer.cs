using System.Drawing;
using System.Windows.Forms;

namespace UCP_1_Revisi
{
    partial class formCetak
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCetak;
        private Label lblTotal;
        private Button btnPrintPreview;
        private Button btnPrint;
        private Button btnRefresh;
        private Button btnClose;
        private Button btnFilter;
        private DateTimePicker dtpMulai;
        private DateTimePicker dtpSelesai;
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
            dgvCetak = new DataGridView();
            lblTotal = new Label();
            btnPrintPreview = new Button();
            btnPrint = new Button();
            btnRefresh = new Button();
            btnClose = new Button();
            btnFilter = new Button();
            dtpMulai = new DateTimePicker();
            dtpSelesai = new DateTimePicker();
            lblMulai = new Label();
            lblSelesai = new Label();

            ((System.ComponentModel.ISupportInitialize)dgvCetak).BeginInit();
            SuspendLayout();

            lblMulai.Text = "Mulai:";
            lblMulai.Location = new Point(12, 15);
            lblMulai.Size = new Size(50, 25);

            dtpMulai.Location = new Point(65, 12);
            dtpMulai.Size = new Size(150, 27);
            dtpMulai.Format = DateTimePickerFormat.Short;
            dtpMulai.Value = DateTime.Now.AddDays(-30);

            lblSelesai.Text = "Selesai:";
            lblSelesai.Location = new Point(225, 15);
            lblSelesai.Size = new Size(60, 25);

            dtpSelesai.Location = new Point(290, 12);
            dtpSelesai.Size = new Size(150, 27);
            dtpSelesai.Format = DateTimePickerFormat.Short;
            dtpSelesai.Value = DateTime.Now;

            btnFilter.Text = "🔍 Filter";
            btnFilter.Location = new Point(450, 10);
            btnFilter.Size = new Size(90, 32);
            btnFilter.BackColor = Color.FromArgb(52, 152, 219);
            btnFilter.ForeColor = Color.White;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Click += btnFilter_Click;

            btnPrintPreview.Text = "📄 Print Preview";
            btnPrintPreview.Location = new Point(550, 10);
            btnPrintPreview.Size = new Size(110, 32);
            btnPrintPreview.BackColor = Color.FromArgb(155, 89, 182);
            btnPrintPreview.ForeColor = Color.White;
            btnPrintPreview.FlatStyle = FlatStyle.Flat;
            btnPrintPreview.Click += btnPrintPreview_Click;

            btnPrint.Text = "🖨️ Print";
            btnPrint.Location = new Point(670, 10);
            btnPrint.Size = new Size(90, 32);
            btnPrint.BackColor = Color.FromArgb(46, 204, 113);
            btnPrint.ForeColor = Color.White;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Click += btnPrint_Click;

            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.Location = new Point(770, 10);
            btnRefresh.Size = new Size(90, 32);
            btnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Click += btnRefresh_Click;

            btnClose.Text = "❌ Tutup";
            btnClose.Location = new Point(870, 10);
            btnClose.Size = new Size(90, 32);
            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += btnClose_Click;

            lblTotal.Text = "Total Data: 0";
            lblTotal.Location = new Point(12, 55);
            lblTotal.Size = new Size(250, 25);

            dgvCetak.Location = new Point(12, 85);
            dgvCetak.Size = new Size(950, 350);
            dgvCetak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCetak.ReadOnly = true;
            dgvCetak.AllowUserToAddRows = false;
            dgvCetak.RowHeadersVisible = false;
            dgvCetak.RowTemplate.Height = 30;

            ClientSize = new Size(980, 460);
            Text = "🖨️ Cetak Laporan Booking Vaksin";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Controls.Add(lblMulai);
            Controls.Add(dtpMulai);
            Controls.Add(lblSelesai);
            Controls.Add(dtpSelesai);
            Controls.Add(btnFilter);
            Controls.Add(btnPrintPreview);
            Controls.Add(btnPrint);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            Controls.Add(lblTotal);
            Controls.Add(dgvCetak);

            ((System.ComponentModel.ISupportInitialize)dgvCetak).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}