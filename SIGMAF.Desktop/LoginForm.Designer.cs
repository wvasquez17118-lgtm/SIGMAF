namespace SIGMAF_MenuDemo
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panelCard;

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
            panelCard = new Panel();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            lblUsuario = new Label();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.BorderStyle = BorderStyle.FixedSingle;
            panelCard.Controls.Add(btnLogin);
            panelCard.Controls.Add(txtPassword);
            panelCard.Controls.Add(txtUsuario);
            panelCard.Controls.Add(lblPassword);
            panelCard.Controls.Add(lblUsuario);
            panelCard.Controls.Add(lblSubtitulo);
            panelCard.Controls.Add(lblTitulo);
            panelCard.Location = new Point(46, 40);
            panelCard.Margin = new Padding(3, 4, 3, 4);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(594, 354);
            panelCard.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(52, 152, 219);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(33, 290);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(526, 42);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "   INICIAR SESIÓN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(33, 226);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(525, 44);
            txtPassword.TabIndex = 1;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(33, 153);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Multiline = true;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(525, 44);
            txtUsuario.TabIndex = 0;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(30, 201);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(92, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(30, 127);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(67, 20);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario:";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtitulo.Location = new Point(30, 73);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(413, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema Integral de Gestión de Motos y Actividad Fisica (SIGMAF)";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(27, 27);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(104, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "SIGMAF";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 52, 54);
            ClientSize = new Size(686, 427);
            Controls.Add(panelCard);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SIGMAF – Sistema Integral de Gestión de Motos y Fitness";
            Load += LoginForm_Load;
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }
    }
}
