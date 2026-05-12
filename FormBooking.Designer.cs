namespace UCP_1_Revisi
{
    partial class FormBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBoxVaksin = new ComboBox();
            comboBoxWaktu = new ComboBox();
            dateTimePicker = new DateTimePicker();
            btnSimpan = new Button();
            btnUpdate = new Button();
            btnHapus = new Button();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btninjection = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 116);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Vaksin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(260, 118);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 1;
            label2.Text = "Tanggal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(435, 119);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 2;
            label3.Text = "Waktu";
            // 
            // comboBoxVaksin
            // 
            comboBoxVaksin.FormattingEnabled = true;
            comboBoxVaksin.Location = new Point(82, 155);
            comboBoxVaksin.Name = "comboBoxVaksin";
            comboBoxVaksin.Size = new Size(151, 28);
            comboBoxVaksin.TabIndex = 3;
            comboBoxVaksin.SelectedIndexChanged += comboBoxVaksin_SelectedIndexChanged;
            // 
            // comboBoxWaktu
            // 
            comboBoxWaktu.FormattingEnabled = true;
            comboBoxWaktu.Items.AddRange(new object[] { "08:00:00", "10:00:00", "13:00:00", "15:00:00" });
            comboBoxWaktu.Location = new Point(435, 155);
            comboBoxWaktu.Name = "comboBoxWaktu";
            comboBoxWaktu.Size = new Size(151, 28);
            comboBoxWaktu.TabIndex = 4;
            comboBoxWaktu.SelectedIndexChanged += comboBoxWaktu_SelectedIndexChanged;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(260, 156);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(153, 27);
            dateTimePicker.TabIndex = 5;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(655, 52);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(94, 29);
            btnSimpan.TabIndex = 6;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(655, 100);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnHapus
            // 
            btnHapus.Location = new Point(655, 154);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(94, 29);
            btnHapus.TabIndex = 8;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = true;
            btnHapus.Click += btnHapus_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 221);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(730, 241);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 52);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 10;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnBack_Click;
            // 
            // btninjection
            // 
            btninjection.Location = new Point(128, 52);
            btninjection.Name = "btninjection";
            btninjection.Size = new Size(94, 29);
            btninjection.TabIndex = 11;
            btninjection.Text = "injection";
            btninjection.UseVisualStyleBackColor = true;
            btninjection.Click += btninjection_Click;
            // 
            // FormBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 496);
            Controls.Add(btninjection);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(btnHapus);
            Controls.Add(btnUpdate);
            Controls.Add(btnSimpan);
            Controls.Add(dateTimePicker);
            Controls.Add(comboBoxWaktu);
            Controls.Add(comboBoxVaksin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormBooking";
            Text = "FormBooking";
            Load += FormBooking_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxVaksin;
        private ComboBox comboBoxWaktu;
        private DateTimePicker dateTimePicker;
        private Button btnSimpan;
        private Button btnUpdate;
        private Button btnHapus;
        private DataGridView dataGridView1;
        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btninjection;
    }
}