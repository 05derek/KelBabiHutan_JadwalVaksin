using System.Drawing;
using System.Windows.Forms;

namespace UCP_1_Revisi
{
    partial class FormJadwalVaksin
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabControlMain;
        private TabPage tabDashboard;
        private TabPage tabJadwal;
        private TabPage tabVaksin;
        private Panel panelBottom;
        private Button btnLogout;
        private Button btnImportExcel;
        private Button btnReport;
        private Button btnCetak;

        private Panel panelDashboard;
        private Label lblWelcome;
        private FlowLayoutPanel flowLayoutPanelStats;
        private Label lblTotalVaksin, lblTotalJadwal, lblTotalBooking, lblKuotaTersedia;
        private DataGridView dgvRingkasan;

        private Panel panelInputJadwal;
        private ComboBox cmbVaksinJadwal;
        private DateTimePicker dtpTanggalJadwal;
        private ComboBox cmbWaktuJadwal;
        private NumericUpDown nudKuotaJadwal;
        private DataGridView dgvJadwal;
        private FlowLayoutPanel flowLayoutPanelJadwal;
        private Button btnTambahJadwal, btnUpdateJadwal, btnHapusJadwal, btnRefreshJadwal;

        private Panel panelInputVaksin;
        private TextBox txtNamaVaksin;
        private NumericUpDown nudStokVaksin;
        private DataGridView dgvVaksin;
        private FlowLayoutPanel flowLayoutPanelVaksin;
        private Button btnTambahVaksin, btnUpdateVaksin, btnHapusVaksin, btnRefreshVaksin;

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
            tabControlMain = new TabControl();
            tabDashboard = new TabPage();
            tabJadwal = new TabPage();
            tabVaksin = new TabPage();
            panelBottom = new Panel();
            btnLogout = new Button();

            SetupDashboardTabDesigner();
            SetupJadwalTabDesigner();
            SetupVaksinTabDesigner();

            tabControlMain.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();

            tabControlMain.Controls.Add(tabDashboard);
            tabControlMain.Controls.Add(tabJadwal);
            tabControlMain.Controls.Add(tabVaksin);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Font = new Font("Segoe UI", 10F);
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1500, 813);
            tabControlMain.TabIndex = 0;

            tabDashboard.Location = new Point(4, 37);
            tabDashboard.Name = "tabDashboard";
            tabDashboard.Size = new Size(1492, 772);
            tabDashboard.TabIndex = 0;
            tabDashboard.Text = "📊 Dashboard";

            tabJadwal.Location = new Point(4, 37);
            tabJadwal.Name = "tabJadwal";
            tabJadwal.Size = new Size(1492, 772);
            tabJadwal.TabIndex = 1;
            tabJadwal.Text = "📅 Kelola Jadwal";

            tabVaksin.Location = new Point(4, 37);
            tabVaksin.Name = "tabVaksin";
            tabVaksin.Size = new Size(1492, 772);
            tabVaksin.TabIndex = 2;
            tabVaksin.Text = "💉 Kelola Vaksin";

            panelBottom.BackColor = Color.FromArgb(44, 62, 80);
            panelBottom.Controls.Add(btnLogout);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 813);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1500, 62);
            panelBottom.TabIndex = 1;

            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1350, 10);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(125, 44);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "🚪 Logout";
            btnLogout.UseVisualStyleBackColor = false;

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1500, 875);
            Controls.Add(tabControlMain);
            Controls.Add(panelBottom);
            Name = "FormJadwalVaksin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🏥 Dashboard Admin Vaksinasi";
            WindowState = FormWindowState.Maximized;

            tabControlMain.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetupDashboardTabDesigner()
        {
            this.panelDashboard = new Panel();
            this.panelDashboard.Dock = DockStyle.Fill;
            this.panelDashboard.Padding = new Padding(15);
            this.tabDashboard.Controls.Add(this.panelDashboard);

            this.lblWelcome = new Label();
            this.lblWelcome.Text = "👋 Selamat Datang di Dashboard Admin Vaksinasi";
            this.lblWelcome.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblWelcome.Dock = DockStyle.Top;
            this.lblWelcome.Height = 50;
            this.lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            this.panelDashboard.Controls.Add(this.lblWelcome);

            this.flowLayoutPanelStats = new FlowLayoutPanel();
            this.flowLayoutPanelStats.Dock = DockStyle.Top;
            this.flowLayoutPanelStats.Height = 130;
            this.flowLayoutPanelStats.Padding = new Padding(5);
            this.panelDashboard.Controls.Add(this.flowLayoutPanelStats);

            CreateStatCardDesigner(this.flowLayoutPanelStats, "💉 Total Vaksin", ref this.lblTotalVaksin, Color.FromArgb(52, 152, 219));
            CreateStatCardDesigner(this.flowLayoutPanelStats, "📅 Total Jadwal", ref this.lblTotalJadwal, Color.FromArgb(46, 204, 113));
            CreateStatCardDesigner(this.flowLayoutPanelStats, "📋 Total Booking", ref this.lblTotalBooking, Color.FromArgb(231, 76, 60));
            CreateStatCardDesigner(this.flowLayoutPanelStats, "✅ Kuota Tersedia", ref this.lblKuotaTersedia, Color.FromArgb(155, 89, 182));

            this.dgvRingkasan = new DataGridView();
            this.dgvRingkasan.Dock = DockStyle.Fill;
            this.dgvRingkasan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRingkasan.BackgroundColor = Color.White;
            this.dgvRingkasan.BorderStyle = BorderStyle.None;
            this.dgvRingkasan.ReadOnly = true;
            this.dgvRingkasan.AllowUserToAddRows = false;
            this.dgvRingkasan.RowHeadersVisible = false;
            this.dgvRingkasan.RowTemplate.Height = 30;
            this.panelDashboard.Controls.Add(this.dgvRingkasan);
        }

        private void CreateStatCardDesigner(FlowLayoutPanel parent, string title, ref Label valueLabel, Color color)
        {
            Panel card = new Panel();
            card.Size = new Size(260, 110);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(3, 3, 10, 3);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 10F);
            lblTitle.ForeColor = Color.Gray;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 35;
            lblTitle.Padding = new Padding(10, 15, 0, 0);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            card.Controls.Add(lblTitle);

            valueLabel = new Label();
            valueLabel.Text = "0";
            valueLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            valueLabel.ForeColor = color;
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.TextAlign = ContentAlignment.MiddleCenter;
            card.Controls.Add(valueLabel);

            parent.Controls.Add(card);
        }

        private void SetupJadwalTabDesigner()
        {
            this.panelInputJadwal = new Panel();
            this.panelInputJadwal.Dock = DockStyle.Top;
            this.panelInputJadwal.Height = 65;
            this.panelInputJadwal.BackColor = Color.FromArgb(240, 242, 245);
            this.panelInputJadwal.Padding = new Padding(15, 10, 15, 10);
            this.tabJadwal.Controls.Add(this.panelInputJadwal);

            Label lblVaksin = new Label();
            lblVaksin.Text = "Vaksin:";
            lblVaksin.Location = new Point(20, 20);
            lblVaksin.Size = new Size(60, 25);
            this.panelInputJadwal.Controls.Add(lblVaksin);

            this.cmbVaksinJadwal = new ComboBox();
            this.cmbVaksinJadwal.Location = new Point(80, 18);
            this.cmbVaksinJadwal.Size = new Size(200, 27);
            this.cmbVaksinJadwal.DropDownStyle = ComboBoxStyle.DropDownList;
            this.panelInputJadwal.Controls.Add(this.cmbVaksinJadwal);

            Label lblTanggal = new Label();
            lblTanggal.Text = "Tanggal:";
            lblTanggal.Location = new Point(295, 20);
            lblTanggal.Size = new Size(70, 25);
            this.panelInputJadwal.Controls.Add(lblTanggal);

            this.dtpTanggalJadwal = new DateTimePicker();
            this.dtpTanggalJadwal.Location = new Point(370, 18);
            this.dtpTanggalJadwal.Size = new Size(150, 27);
            this.dtpTanggalJadwal.Format = DateTimePickerFormat.Short;
            this.panelInputJadwal.Controls.Add(this.dtpTanggalJadwal);

            Label lblWaktu = new Label();
            lblWaktu.Text = "Waktu:";
            lblWaktu.Location = new Point(535, 20);
            lblWaktu.Size = new Size(60, 25);
            this.panelInputJadwal.Controls.Add(lblWaktu);

            this.cmbWaktuJadwal = new ComboBox();
            this.cmbWaktuJadwal.Location = new Point(595, 18);
            this.cmbWaktuJadwal.Size = new Size(120, 27);
            this.cmbWaktuJadwal.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbWaktuJadwal.Items.AddRange(new object[] { "08:00", "10:00", "13:00", "15:00" });
            this.panelInputJadwal.Controls.Add(this.cmbWaktuJadwal);

            Label lblKuota = new Label();
            lblKuota.Text = "Kuota:";
            lblKuota.Location = new Point(730, 20);
            lblKuota.Size = new Size(60, 25);
            this.panelInputJadwal.Controls.Add(lblKuota);

            this.nudKuotaJadwal = new NumericUpDown();
            this.nudKuotaJadwal.Location = new Point(790, 18);
            this.nudKuotaJadwal.Size = new Size(100, 27);
            this.nudKuotaJadwal.Minimum = 1;
            this.nudKuotaJadwal.Maximum = 100;
            this.nudKuotaJadwal.Value = 25;
            this.panelInputJadwal.Controls.Add(this.nudKuotaJadwal);

            this.dgvJadwal = new DataGridView();
            this.dgvJadwal.Dock = DockStyle.Fill;
            this.dgvJadwal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJadwal.BackgroundColor = Color.White;
            this.dgvJadwal.BorderStyle = BorderStyle.None;
            this.dgvJadwal.ReadOnly = true;
            this.dgvJadwal.AllowUserToAddRows = false;
            this.dgvJadwal.RowHeadersVisible = false;
            this.dgvJadwal.RowTemplate.Height = 30;
            this.dgvJadwal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvJadwal.DataSource = this.bsJadwal;
            this.tabJadwal.Controls.Add(this.dgvJadwal);

            this.flowLayoutPanelJadwal = new FlowLayoutPanel();
            this.flowLayoutPanelJadwal.Dock = DockStyle.Bottom;
            this.flowLayoutPanelJadwal.Height = 48;
            this.flowLayoutPanelJadwal.BackColor = Color.FromArgb(240, 242, 245);
            this.flowLayoutPanelJadwal.Padding = new Padding(15, 8, 15, 8);
            this.tabJadwal.Controls.Add(this.flowLayoutPanelJadwal);

            this.btnTambahJadwal = CreateButtonDesigner("➕ Tambah", Color.FromArgb(46, 204, 113));
            this.btnUpdateJadwal = CreateButtonDesigner("✏️ Update", Color.FromArgb(52, 152, 219));
            this.btnHapusJadwal = CreateButtonDesigner("🗑️ Hapus", Color.FromArgb(231, 76, 60));
            this.btnRefreshJadwal = CreateButtonDesigner("🔄 Refresh", Color.FromArgb(149, 165, 166));

            this.flowLayoutPanelJadwal.Controls.Add(this.btnTambahJadwal);
            this.flowLayoutPanelJadwal.Controls.Add(this.btnUpdateJadwal);
            this.flowLayoutPanelJadwal.Controls.Add(this.btnHapusJadwal);
            this.flowLayoutPanelJadwal.Controls.Add(this.btnRefreshJadwal);
        }

        private void SetupVaksinTabDesigner()
        {
            this.panelInputVaksin = new Panel();
            this.panelInputVaksin.Dock = DockStyle.Top;
            this.panelInputVaksin.Height = 65;
            this.panelInputVaksin.BackColor = Color.FromArgb(240, 242, 245);
            this.panelInputVaksin.Padding = new Padding(15, 10, 15, 10);
            this.tabVaksin.Controls.Add(this.panelInputVaksin);

            Label lblNama = new Label();
            lblNama.Text = "Nama Vaksin:";
            lblNama.Location = new Point(20, 20);
            lblNama.Size = new Size(100, 25);
            this.panelInputVaksin.Controls.Add(lblNama);

            this.txtNamaVaksin = new TextBox();
            this.txtNamaVaksin.Location = new Point(125, 18);
            this.txtNamaVaksin.Size = new Size(300, 27);
            this.txtNamaVaksin.PlaceholderText = "Masukkan nama vaksin";
            this.panelInputVaksin.Controls.Add(this.txtNamaVaksin);

            Label lblStok = new Label();
            lblStok.Text = "Stok:";
            lblStok.Location = new Point(440, 20);
            lblStok.Size = new Size(50, 25);
            this.panelInputVaksin.Controls.Add(lblStok);

            this.nudStokVaksin = new NumericUpDown();
            this.nudStokVaksin.Location = new Point(495, 18);
            this.nudStokVaksin.Size = new Size(120, 27);
            this.nudStokVaksin.Minimum = 0;
            this.nudStokVaksin.Maximum = 9999;
            this.nudStokVaksin.Value = 100;
            this.panelInputVaksin.Controls.Add(this.nudStokVaksin);

            this.dgvVaksin = new DataGridView();
            this.dgvVaksin.Dock = DockStyle.Fill;
            this.dgvVaksin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVaksin.BackgroundColor = Color.White;
            this.dgvVaksin.BorderStyle = BorderStyle.None;
            this.dgvVaksin.ReadOnly = true;
            this.dgvVaksin.AllowUserToAddRows = false;
            this.dgvVaksin.RowHeadersVisible = false;
            this.dgvVaksin.RowTemplate.Height = 30;
            this.dgvVaksin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvVaksin.DataSource = this.bsVaksin;
            this.tabVaksin.Controls.Add(this.dgvVaksin);

            this.flowLayoutPanelVaksin = new FlowLayoutPanel();
            this.flowLayoutPanelVaksin.Dock = DockStyle.Bottom;
            this.flowLayoutPanelVaksin.Height = 48;
            this.flowLayoutPanelVaksin.BackColor = Color.FromArgb(240, 242, 245);
            this.flowLayoutPanelVaksin.Padding = new Padding(15, 8, 15, 8);
            this.tabVaksin.Controls.Add(this.flowLayoutPanelVaksin);

            this.btnTambahVaksin = CreateButtonDesigner("➕ Tambah", Color.FromArgb(46, 204, 113));
            this.btnUpdateVaksin = CreateButtonDesigner("✏️ Update", Color.FromArgb(52, 152, 219));
            this.btnHapusVaksin = CreateButtonDesigner("🗑️ Hapus", Color.FromArgb(231, 76, 60));
            this.btnRefreshVaksin = CreateButtonDesigner("🔄 Refresh", Color.FromArgb(149, 165, 166));

            this.btnImportExcel = new Button();
            this.btnImportExcel.Text = "📤 Import Excel";
            this.btnImportExcel.Size = new Size(110, 30);
            this.btnImportExcel.FlatStyle = FlatStyle.Flat;
            this.btnImportExcel.ForeColor = Color.White;
            this.btnImportExcel.BackColor = Color.FromArgb(52, 152, 219);
            this.btnImportExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            this.btnReport = new Button();
            this.btnReport.Text = "📊 Report";
            this.btnReport.Size = new Size(110, 30);
            this.btnReport.FlatStyle = FlatStyle.Flat;
            this.btnReport.ForeColor = Color.White;
            this.btnReport.BackColor = Color.FromArgb(155, 89, 182);
            this.btnReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            this.btnCetak = new Button();
            this.btnCetak.Text = "🖨️ Cetak";
            this.btnCetak.Size = new Size(110, 30);
            this.btnCetak.FlatStyle = FlatStyle.Flat;
            this.btnCetak.ForeColor = Color.White;
            this.btnCetak.BackColor = Color.FromArgb(241, 196, 15);
            this.btnCetak.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            this.flowLayoutPanelVaksin.Controls.Add(this.btnTambahVaksin);
            this.flowLayoutPanelVaksin.Controls.Add(this.btnUpdateVaksin);
            this.flowLayoutPanelVaksin.Controls.Add(this.btnHapusVaksin);
            this.flowLayoutPanelVaksin.Controls.Add(this.btnRefreshVaksin);
            this.flowLayoutPanelVaksin.Controls.Add(this.btnImportExcel);
            this.flowLayoutPanelVaksin.Controls.Add(this.btnReport);
            this.flowLayoutPanelVaksin.Controls.Add(this.btnCetak);
        }

        private Button CreateButtonDesigner(string text, Color color)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Size = new Size(110, 30);
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.BackColor = color;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            return btn;
        }
    }
}