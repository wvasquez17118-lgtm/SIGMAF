namespace SIGMAF.Desktop.MOTOS
{
    partial class SincronizacionForm
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
            panel1 = new Panel();
            lblTotalProducto = new Label();
            label3 = new Label();
            btnSincronizar = new Button();
            panel2 = new Panel();
            ChDescargarCatalogo = new CheckBox();
            panel3 = new Panel();
            label1 = new Label();
            dateFechaSincronizacion = new DateTimePicker();
            chActualizarInventarioVenta = new CheckBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(lblTotalProducto);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(772, 60);
            panel1.TabIndex = 4;
            // 
            // lblTotalProducto
            // 
            lblTotalProducto.AutoSize = true;
            lblTotalProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProducto.Location = new Point(1015, 19);
            lblTotalProducto.Name = "lblTotalProducto";
            lblTotalProducto.Size = new Size(61, 20);
            lblTotalProducto.TabIndex = 1;
            lblTotalProducto.Text = "Total: 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 19);
            label3.Name = "label3";
            label3.Size = new Size(201, 20);
            label3.TabIndex = 0;
            label3.Text = "Sincronizar de sistema local";
            // 
            // btnSincronizar
            // 
            btnSincronizar.Enabled = false;
            btnSincronizar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSincronizar.Image = Properties.Resources.icon_sincronizarguardar;
            btnSincronizar.ImageAlign = ContentAlignment.TopCenter;
            btnSincronizar.Location = new Point(214, 280);
            btnSincronizar.Name = "btnSincronizar";
            btnSincronizar.Size = new Size(276, 60);
            btnSincronizar.TabIndex = 5;
            btnSincronizar.Text = "SINCRONIZAR";
            btnSincronizar.TextAlign = ContentAlignment.BottomCenter;
            btnSincronizar.UseVisualStyleBackColor = true;
            btnSincronizar.Click += btnSincronizar_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(ChDescargarCatalogo);
            panel2.Location = new Point(18, 77);
            panel2.Name = "panel2";
            panel2.Size = new Size(309, 178);
            panel2.TabIndex = 6;
            // 
            // ChDescargarCatalogo
            // 
            ChDescargarCatalogo.AutoSize = true;
            ChDescargarCatalogo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ChDescargarCatalogo.Location = new Point(38, 72);
            ChDescargarCatalogo.Name = "ChDescargarCatalogo";
            ChDescargarCatalogo.Size = new Size(237, 24);
            ChDescargarCatalogo.TabIndex = 0;
            ChDescargarCatalogo.Text = "Descargar catalogo productos";
            ChDescargarCatalogo.UseVisualStyleBackColor = true;
            ChDescargarCatalogo.CheckedChanged += ChDescargarCatalogo_CheckedChanged;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(dateFechaSincronizacion);
            panel3.Controls.Add(chActualizarInventarioVenta);
            panel3.Location = new Point(433, 77);
            panel3.Name = "panel3";
            panel3.Size = new Size(309, 178);
            panel3.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 36);
            label1.Name = "label1";
            label1.Size = new Size(195, 20);
            label1.TabIndex = 3;
            label1.Text = "Fecha actualizar inventario";
            // 
            // dateFechaSincronizacion
            // 
            dateFechaSincronizacion.Location = new Point(21, 59);
            dateFechaSincronizacion.Name = "dateFechaSincronizacion";
            dateFechaSincronizacion.Size = new Size(268, 27);
            dateFechaSincronizacion.TabIndex = 2;
            // 
            // chActualizarInventarioVenta
            // 
            chActualizarInventarioVenta.AutoSize = true;
            chActualizarInventarioVenta.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chActualizarInventarioVenta.Location = new Point(21, 128);
            chActualizarInventarioVenta.Name = "chActualizarInventarioVenta";
            chActualizarInventarioVenta.Size = new Size(268, 24);
            chActualizarInventarioVenta.TabIndex = 1;
            chActualizarInventarioVenta.Text = "Actualizar inventario con la ventas";
            chActualizarInventarioVenta.UseVisualStyleBackColor = true;
            chActualizarInventarioVenta.CheckedChanged += chActualizarInventarioVenta_CheckedChanged;
            // 
            // SincronizacionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(772, 354);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(btnSincronizar);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SincronizacionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sincronización";
            TopMost = true;
            FormClosing += SincronizacionForm_FormClosing;
            Load += SincronizacionForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTotalProducto;
        private Label label3;
        private Button btnSincronizar;
        private Panel panel2;
        private Panel panel3;
        private CheckBox ChDescargarCatalogo;
        private CheckBox chActualizarInventarioVenta;
        private DateTimePicker dateFechaSincronizacion;
        private Label label1;
    }
}