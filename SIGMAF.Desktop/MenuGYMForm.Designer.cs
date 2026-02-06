namespace SIGMAF.Desktop
{
    partial class MenuGYMForm
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
            menuPrincipalStrip = new MenuStrip();
            motosToolStripMenuItem = new ToolStripMenuItem();
            sALIRToolStripMenuItem = new ToolStripMenuItem();
            panelInferior = new Panel();
            picAnimacion = new PictureBox();
            label1 = new Label();
            panelRibbon = new Panel();
            flowMenu = new FlowLayoutPanel();
            menuPrincipalStrip.SuspendLayout();
            panelInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnimacion).BeginInit();
            panelRibbon.SuspendLayout();
            SuspendLayout();
            // 
            // menuPrincipalStrip
            // 
            menuPrincipalStrip.Items.AddRange(new ToolStripItem[] { motosToolStripMenuItem, sALIRToolStripMenuItem });
            menuPrincipalStrip.Location = new Point(0, 0);
            menuPrincipalStrip.Name = "menuPrincipalStrip";
            menuPrincipalStrip.Padding = new Padding(7, 2, 0, 2);
            menuPrincipalStrip.Size = new Size(1328, 29);
            menuPrincipalStrip.TabIndex = 7;
            menuPrincipalStrip.Text = "menuStrip1";
            // 
            // motosToolStripMenuItem
            // 
            motosToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            motosToolStripMenuItem.Name = "motosToolStripMenuItem";
            motosToolStripMenuItem.Size = new Size(77, 25);
            motosToolStripMenuItem.Text = "MOTOS";
            // 
            // sALIRToolStripMenuItem
            // 
            sALIRToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sALIRToolStripMenuItem.Name = "sALIRToolStripMenuItem";
            sALIRToolStripMenuItem.Size = new Size(65, 25);
            sALIRToolStripMenuItem.Text = "SALIR";
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.FromArgb(225, 235, 245);
            panelInferior.Controls.Add(picAnimacion);
            panelInferior.Controls.Add(label1);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 595);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(1328, 39);
            panelInferior.TabIndex = 9;
            // 
            // picAnimacion
            // 
            picAnimacion.Image = Properties.Resources.icon_moto_ida;
            picAnimacion.Location = new Point(779, 4);
            picAnimacion.Name = "picAnimacion";
            picAnimacion.Size = new Size(35, 32);
            picAnimacion.TabIndex = 1;
            picAnimacion.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 4);
            label1.Name = "label1";
            label1.Size = new Size(409, 20);
            label1.TabIndex = 0;
            label1.Text = "Bienvenido al sistema: WALTER JAVIER VASQUEZ GONZALEZ";
            // 
            // panelRibbon
            // 
            panelRibbon.BackColor = Color.FromArgb(225, 235, 245);
            panelRibbon.Controls.Add(flowMenu);
            panelRibbon.Dock = DockStyle.Top;
            panelRibbon.Location = new Point(0, 29);
            panelRibbon.Name = "panelRibbon";
            panelRibbon.Size = new Size(1328, 100);
            panelRibbon.TabIndex = 10;
            // 
            // flowMenu
            // 
            flowMenu.BackColor = Color.Transparent;
            flowMenu.Dock = DockStyle.Fill;
            flowMenu.Location = new Point(0, 0);
            flowMenu.Name = "flowMenu";
            flowMenu.Padding = new Padding(8);
            flowMenu.Size = new Size(1328, 100);
            flowMenu.TabIndex = 2;
            flowMenu.WrapContents = false;
            // 
            // MenuGYMForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1328, 634);
            Controls.Add(panelRibbon);
            Controls.Add(menuPrincipalStrip);
            Controls.Add(panelInferior);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IsMdiContainer = true;
            Margin = new Padding(4);
            Name = "MenuGYMForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Integral de Gestión Fitness (SIGMAF)";
            WindowState = FormWindowState.Maximized;
            menuPrincipalStrip.ResumeLayout(false);
            menuPrincipalStrip.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAnimacion).EndInit();
            panelRibbon.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuPrincipalStrip;
        private ToolStripMenuItem motosToolStripMenuItem;
        private ToolStripMenuItem sALIRToolStripMenuItem;
        private Panel panelInferior;
        private PictureBox picAnimacion;
        private Label label1;
        private Panel panelRibbon;
        private FlowLayoutPanel flowMenu;
    }
}