using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UCP_1_Revisi
{
    partial class FormDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label lblTitle;
        private Label lblTotalVaksin, lblTotalJadwal, lblTotalBooking, lblKuotaTersedia;
        private Label lblTotalVaksinTitle, lblTotalJadwalTitle, lblTotalBookingTitle, lblKuotaTersediaTitle;
        private Chart chartVaksin;
        private ComboBox cmbChartType;
        private Button btnRefresh;
        private Button btnCetak;
        private Button btnDataVaksin;
        private DataGridView dgvData;
        private Panel panelStats;

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
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();

            panelTop = new Panel();
            lblTitle = new Label();
            panelStats = new Panel();
            chartVaksin = new Chart();
            cmbChartType = new ComboBox();
            btnRefresh = new Button();
            btnCetak = new Button();
            btnDataVaksin = new Button();
            dgvData = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)chartVaksin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();

            // Panel Top
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 60;
            panelTop.BackColor = Color.FromArgb(44, 62, 80);
            panelTop.Padding = new Padding(15, 10, 15, 10);

            lblTitle.Text = "📊 DASHBOARD DATA VAKSIN";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // Panel Stats
            panelStats.Dock = DockStyle.Top;
            panelStats.Height = 100;
            panelStats.BackColor = Color.FromArgb(240, 242, 245);
            panelStats.Padding = new Padding(10);

            // Card 1
            Panel card1 = CreateStatCard("💉 Total Vaksin", ref lblTotalVaksinTitle, ref lblTotalVaksin, Color.FromArgb(52, 152, 219));
            panelStats.Controls.Add(card1);

            // Card 2
            Panel card2 = CreateStatCard("📅 Total Jadwal", ref lblTotalJadwalTitle, ref lblTotalJadwal, Color.FromArgb(46, 204, 113));
            card2.Left = 220;
            panelStats.Controls.Add(card2);

            // Card 3
            Panel card3 = CreateStatCard("📋 Total Booking", ref lblTotalBookingTitle, ref lblTotalBooking, Color.FromArgb(231, 76, 60));
            card3.Left = 440;
            panelStats.Controls.Add(card3);

            // Card 4
            Panel card4 = CreateStatCard("✅ Kuota Tersedia", ref lblKuotaTersediaTitle, ref lblKuotaTersedia, Color.FromArgb(155, 89, 182));
            card4.Left = 660;
            panelStats.Controls.Add(card4);

            // Chart
            chartArea1.Name = "ChartArea1";
            chartVaksin.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Docking = Docking.Bottom;
            chartVaksin.Legends.Add(legend1);
            chartVaksin.Dock = DockStyle.Fill;
            chartVaksin.BackColor = Color.White;

            // Controls
            cmbChartType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChartType.Location = new Point(12, 12);
            cmbChartType.Size = new Size(150, 27);
            cmbChartType.SelectedIndexChanged += cmbChartType_SelectedIndexChanged;

            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.Location = new Point(170, 10);
            btnRefresh.Size = new Size(100, 32);
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Click += btnRefresh_Click;

            btnCetak.Text = "🖨️ Cetak";
            btnCetak.Location = new Point(280, 10);
            btnCetak.Size = new Size(100, 32);
            btnCetak.BackColor = Color.FromArgb(241, 196, 15);
            btnCetak.ForeColor = Color.White;
            btnCetak.FlatStyle = FlatStyle.Flat;
            btnCetak.Click += btnCetak_Click;

            btnDataVaksin.Text = "📋 Data Vaksin";
            btnDataVaksin.Location = new Point(390, 10);
            btnDataVaksin.Size = new Size(120, 32);
            btnDataVaksin.BackColor = Color.FromArgb(46, 204, 113);
            btnDataVaksin.ForeColor = Color.White;
            btnDataVaksin.FlatStyle = FlatStyle.Flat;
            btnDataVaksin.Click += btnDataVaksin_Click;

            // DataGridView
            dgvData.Dock = DockStyle.Bottom;
            dgvData.Height = 200;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.ReadOnly = true;
            dgvData.AllowUserToAddRows = false;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 30;
            dgvData.BackgroundColor = Color.White;
            dgvData.BorderStyle = BorderStyle.None;

            // Form
            this.ClientSize = new Size(1000, 700);
            this.Controls.Add(chartVaksin);
            this.Controls.Add(dgvData);
            this.Controls.Add(panelStats);
            this.Controls.Add(panelTop);
            this.Controls.Add(cmbChartType);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnCetak);
            this.Controls.Add(btnDataVaksin);
            this.Text = "📊 Dashboard Vaksinasi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(cmbChartType);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(btnCetak);
            panelTop.Controls.Add(btnDataVaksin);

            ((System.ComponentModel.ISupportInitialize)chartVaksin).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        private Panel CreateStatCard(string title, ref Label titleLabel, ref Label valueLabel, Color color)
        {
            Panel card = new Panel();
            card.Size = new Size(200, 80);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Padding = new Padding(5);

            titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.Font = new Font("Segoe UI", 9F);
            titleLabel.ForeColor = Color.Gray;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 25;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;

            valueLabel = new Label();
            valueLabel.Text = "0";
            valueLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            valueLabel.ForeColor = color;
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.TextAlign = ContentAlignment.MiddleCenter;

            card.Controls.Add(valueLabel);
            card.Controls.Add(titleLabel);
            return card;
        }
    }
}