namespace SIGMAF.Desktop
{
    partial class MenuForm
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
            components = new System.ComponentModel.Container();
            menuPrincipalStrip = new MenuStrip();
            motosToolStripMenuItem = new ToolStripMenuItem();
            movimientosVentasToolStripMenuItem = new ToolStripMenuItem();
            consultasToolStripMenuItem = new ToolStripMenuItem();
            flowMenu = new FlowLayoutPanel();
            panelRibbon = new Panel();
            panelInferior = new Panel();
            picAnimacion = new PictureBox();
            label1 = new Label();
            timerAnimacion = new System.Windows.Forms.Timer(components);
            menuPrincipalStrip.SuspendLayout();
            panelRibbon.SuspendLayout();
            panelInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnimacion).BeginInit();
            SuspendLayout();
            // 
            // menuPrincipalStrip
            // 
            menuPrincipalStrip.Items.AddRange(new ToolStripItem[] { motosToolStripMenuItem, movimientosVentasToolStripMenuItem, consultasToolStripMenuItem });
            menuPrincipalStrip.Location = new Point(0, 0);
            menuPrincipalStrip.Name = "menuPrincipalStrip";
            menuPrincipalStrip.Padding = new Padding(7, 2, 0, 2);
            menuPrincipalStrip.Size = new Size(1328, 28);
            menuPrincipalStrip.TabIndex = 0;
            menuPrincipalStrip.Text = "menuStrip1";
            // 
            // motosToolStripMenuItem
            // 
            motosToolStripMenuItem.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            motosToolStripMenuItem.Name = "motosToolStripMenuItem";
            motosToolStripMenuItem.Size = new Size(70, 24);
            motosToolStripMenuItem.Text = "MOTOS";
            motosToolStripMenuItem.Click += inicioToolStripMenuItem_Click;
            // 
            // movimientosVentasToolStripMenuItem
            // 
            movimientosVentasToolStripMenuItem.Name = "movimientosVentasToolStripMenuItem";
            movimientosVentasToolStripMenuItem.Size = new Size(89, 24);
            movimientosVentasToolStripMenuItem.Text = "Movimientos";
            movimientosVentasToolStripMenuItem.Click += movimientosVentasToolStripMenuItem_Click;
            // 
            // consultasToolStripMenuItem
            // 
            consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            consultasToolStripMenuItem.Size = new Size(71, 24);
            consultasToolStripMenuItem.Text = "Consultas";
            // 
            // flowMenu
            // 
            flowMenu.BackColor = Color.Transparent;
            flowMenu.Dock = DockStyle.Fill;
            flowMenu.Location = new Point(0, 0);
            flowMenu.Name = "flowMenu";
            flowMenu.Padding = new Padding(8);
            flowMenu.Size = new Size(1328, 100);
            flowMenu.TabIndex = 1;
            flowMenu.WrapContents = false;
            // 
            // panelRibbon
            // 
            panelRibbon.BackColor = Color.FromArgb(225, 235, 245);
            panelRibbon.Controls.Add(flowMenu);
            panelRibbon.Dock = DockStyle.Top;
            panelRibbon.Location = new Point(0, 28);
            panelRibbon.Name = "panelRibbon";
            panelRibbon.Size = new Size(1328, 100);
            panelRibbon.TabIndex = 2;
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
            panelInferior.TabIndex = 4;
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
            // timerAnimacion
            // 
            timerAnimacion.Interval = 50;
            timerAnimacion.Tick += timerAnimacion_Tick;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1328, 634);
            Controls.Add(panelInferior);
            Controls.Add(panelRibbon);
            Controls.Add(menuPrincipalStrip);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IsMdiContainer = true;
            MainMenuStrip = menuPrincipalStrip;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Integral de Gestión de Motos y Fitness (SIGMAF)";
            WindowState = FormWindowState.Maximized;
            Load += MenuForm_Load;
            menuPrincipalStrip.ResumeLayout(false);
            menuPrincipalStrip.PerformLayout();
            panelRibbon.ResumeLayout(false);
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAnimacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuPrincipalStrip;
        private ToolStripMenuItem motosToolStripMenuItem;
        private ToolStripMenuItem movimientosVentasToolStripMenuItem;
        private ToolStripMenuItem consultasToolStripMenuItem;
        private FlowLayoutPanel flowMenu;
        private Panel panelRibbon;
        private Panel panelInferior;
        private Label label1;
        private PictureBox picAnimacion;
        private System.Windows.Forms.Timer timerAnimacion;
    }
}