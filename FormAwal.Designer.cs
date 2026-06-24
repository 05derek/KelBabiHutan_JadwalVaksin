namespace UCP_1_Revisi
{
    partial class FormAwal
    {
        private System.ComponentModel.IContainer components = null;

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
            lblUsername = new Label();
            lblPassword = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnLogin = new Button();
            btnDaftar = new Button();
            SuspendLayout();

            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(345, 158);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 25);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";

            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(351, 228);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";

            textBox1.Location = new Point(474, 149);
            textBox1.Margin = new Padding(4, 4, 4, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 31);
            textBox1.TabIndex = 2;

            textBox2.Location = new Point(474, 219);
            textBox2.Margin = new Padding(4, 4, 4, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(155, 31);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;

            btnLogin.Location = new Point(428, 300);
            btnLogin.Margin = new Padding(4, 4, 4, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(118, 36);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;

            btnDaftar.Location = new Point(428, 362);
            btnDaftar.Margin = new Padding(4, 4, 4, 4);
            btnDaftar.Name = "btnDaftar";
            btnDaftar.Size = new Size(118, 36);
            btnDaftar.TabIndex = 5;
            btnDaftar.Text = "Daftar";
            btnDaftar.UseVisualStyleBackColor = true;
            btnDaftar.Click += btnDaftar_Click;

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(btnDaftar);
            Controls.Add(btnLogin);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormAwal";
            Text = "Form1";
            Load += FormAwal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblUsername;
        private Label lblPassword;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnLogin;
        private Button btnDaftar;
    }
}