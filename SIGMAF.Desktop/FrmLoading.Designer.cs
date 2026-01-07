namespace SIGMAF_LoadingDemo
{
    partial class FrmLoading
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.Label lblEstado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMain = new Panel();
            lblEstado = new Label();
            lblModulo = new Label();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(lblEstado);
            panelMain.Controls.Add(lblModulo);
            panelMain.Controls.Add(lblSubtitulo);
            panelMain.Controls.Add(lblTitulo);
            panelMain.Location = new Point(40, 30);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(24);
            panelMain.Size = new Size(520, 200);
            panelMain.TabIndex = 0;
            panelMain.Paint += panelMain_Paint;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F);
            lblEstado.ForeColor = Color.FromArgb(84, 110, 122);
            lblEstado.Location = new Point(28, 152);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(111, 15);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Cargando sistema...";
            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.Font = new Font("Segoe UI", 9.5F);
            lblModulo.ForeColor = Color.FromArgb(90, 120, 140);
            lblModulo.Location = new Point(26, 116);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(214, 17);
            lblModulo.TabIndex = 2;
            lblModulo.Text = "Módulos: MOTOS · GYM · Reportes";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = Color.FromArgb(55, 71, 79);
            lblSubtitulo.Location = new Point(24, 72);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(317, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema Integral de Gestión de Motos y Fitness";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(25, 118, 210);
            lblTitulo.Location = new Point(20, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(119, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "SIGMAF";
            // 
            // FrmLoading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(600, 261);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLoading";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SIGMAF – Loading";
            Load += FrmLoading_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
