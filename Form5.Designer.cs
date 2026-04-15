using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    partial class Form5
    {
        private DataGridView dataGridView1;

        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.dgvbooking = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbooking)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(593, 334);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 37);
            this.button4.TabIndex = 0;
            this.button4.Text = "Booking";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvbooking
            // 
            this.dgvbooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbooking.Location = new System.Drawing.Point(43, 29);
            this.dgvbooking.Name = "dgvbooking";
            this.dgvbooking.RowHeadersWidth = 51;
            this.dgvbooking.RowTemplate.Height = 24;
            this.dgvbooking.Size = new System.Drawing.Size(631, 283);
            this.dgvbooking.TabIndex = 1;
            this.dgvbooking.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbooking_CellContentClick);
            // 
            // Form5
            // 
            this.ClientSize = new System.Drawing.Size(722, 402);
            this.Controls.Add(this.dgvbooking);
            this.Controls.Add(this.button4);
            this.Name = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.dgvbooking)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dgvbooking;
    }
}