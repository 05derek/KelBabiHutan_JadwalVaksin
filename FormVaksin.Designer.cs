namespace UCP_1_Revisi
{
    partial class FormVaksin
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            btnTambah = new Button();
            btnUbah = new Button();
            btnHapus = new Button();
            btnKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(147, 76);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Vaksin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(435, 73);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 1;
            label2.Text = "Stok";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Sinovac", "Pfizer", "Moderna", "AstraZeneca" });
            comboBox1.Location = new Point(237, 73);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 28);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(525, 73);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(81, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 194);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(746, 228);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnTambah
            // 
            btnTambah.Location = new Point(132, 133);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(94, 29);
            btnTambah.TabIndex = 5;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnUbah
            // 
            btnUbah.Location = new Point(368, 133);
            btnUbah.Name = "btnUbah";
            btnUbah.Size = new Size(94, 29);
            btnUbah.TabIndex = 6;
            btnUbah.Text = "Ubah";
            btnUbah.UseVisualStyleBackColor = true;
            btnUbah.Click += btnUbah_Click;
            // 
            // btnHapus
            // 
            btnHapus.Location = new Point(605, 133);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(94, 29);
            btnHapus.TabIndex = 7;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = true;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(12, 12);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(94, 29);
            btnKembali.TabIndex = 8;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // FormVaksin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKembali);
            Controls.Add(btnHapus);
            Controls.Add(btnUbah);
            Controls.Add(btnTambah);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormVaksin";
            Text = "FormVaksin";
            Load += FormVaksin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button btnTambah;
        private Button btnUbah;
        private Button btnHapus;
        private Button btnKembali;
    }
}