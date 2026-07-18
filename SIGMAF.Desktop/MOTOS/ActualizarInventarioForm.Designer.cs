namespace SIGMAF.Desktop.MOTOS
{
    partial class ActualizarInventarioForm
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
            lblTitulo = new Label();
            btnGuardar = new Button();
            label1 = new Label();
            txtNombreProducto = new TextBox();
            label2 = new Label();
            txtCantidadDisponible = new TextBox();
            label4 = new Label();
            txtStock = new TextBox();
            label5 = new Label();
            txtPrecioCompra = new TextBox();
            label6 = new Label();
            txtPrecioVenta = new TextBox();
            label3 = new Label();
            txtPrecioVentaAltalier = new TextBox();
            label7 = new Label();
            txtCantidadWAMA = new TextBox();
            txtCantidadAltalier = new TextBox();
            label8 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(lblTotalProducto);
            panel1.Controls.Add(lblTitulo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(562, 67);
            panel1.TabIndex = 4;
            // 
            // lblTotalProducto
            // 
            lblTotalProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalProducto.AutoSize = true;
            lblTotalProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProducto.Location = new Point(1493, 25);
            lblTotalProducto.Name = "lblTotalProducto";
            lblTotalProducto.Size = new Size(76, 25);
            lblTotalProducto.TabIndex = 1;
            lblTotalProducto.Text = "Total: 0";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(21, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(317, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Actualizar producto del inventario";
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Image = Properties.Resources.icon_save;
            btnGuardar.ImageAlign = ContentAlignment.TopCenter;
            btnGuardar.Location = new Point(0, 526);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(562, 73);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.TextAlign = ContentAlignment.BottomCenter;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 82);
            label1.Name = "label1";
            label1.Size = new Size(175, 25);
            label1.TabIndex = 12;
            label1.Text = "Nombre producto";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Enabled = false;
            txtNombreProducto.Location = new Point(14, 106);
            txtNombreProducto.Margin = new Padding(3, 4, 3, 4);
            txtNombreProducto.Multiline = true;
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(536, 35);
            txtNombreProducto.TabIndex = 11;
            txtNombreProducto.TextChanged += txtNombreProducto_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 147);
            label2.Name = "label2";
            label2.Size = new Size(165, 25);
            label2.TabIndex = 14;
            label2.Text = "Cantidad Bodega";
            // 
            // txtCantidadDisponible
            // 
            txtCantidadDisponible.Enabled = false;
            txtCantidadDisponible.Location = new Point(14, 174);
            txtCantidadDisponible.Margin = new Padding(3, 4, 3, 4);
            txtCantidadDisponible.Multiline = true;
            txtCantidadDisponible.Name = "txtCantidadDisponible";
            txtCantidadDisponible.Size = new Size(536, 35);
            txtCantidadDisponible.TabIndex = 13;
            txtCantidadDisponible.TextChanged += txtCantidadDisponible_TextChanged;
            txtCantidadDisponible.KeyPress += txtCantidadDisponible_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(15, 213);
            label4.Name = "label4";
            label4.Size = new Size(135, 25);
            label4.TabIndex = 16;
            label4.Text = "Stock Bodega";
            // 
            // txtStock
            // 
            txtStock.Enabled = false;
            txtStock.Location = new Point(14, 241);
            txtStock.Margin = new Padding(3, 4, 3, 4);
            txtStock.Multiline = true;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(536, 35);
            txtStock.TabIndex = 15;
            txtStock.TextChanged += txtStock_TextChanged;
            txtStock.KeyPress += txtCantidadDisponible_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 285);
            label5.Name = "label5";
            label5.Size = new Size(141, 25);
            label5.TabIndex = 18;
            label5.Text = "Precio compra";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.Enabled = false;
            txtPrecioCompra.Location = new Point(14, 316);
            txtPrecioCompra.Margin = new Padding(3, 4, 3, 4);
            txtPrecioCompra.Multiline = true;
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(536, 35);
            txtPrecioCompra.TabIndex = 17;
            txtPrecioCompra.KeyPress += txtCantidadDisponible_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(15, 374);
            label6.Name = "label6";
            label6.Size = new Size(189, 25);
            label6.TabIndex = 20;
            label6.Text = "Precio venta WAMA";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Enabled = false;
            txtPrecioVenta.Location = new Point(14, 398);
            txtPrecioVenta.Margin = new Padding(3, 4, 3, 4);
            txtPrecioVenta.Multiline = true;
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(222, 35);
            txtPrecioVenta.TabIndex = 19;
            txtPrecioVenta.KeyPress += txtCantidadDisponible_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(285, 374);
            label3.Name = "label3";
            label3.Size = new Size(210, 25);
            label3.TabIndex = 22;
            label3.Text = "Precio venta ALTALIER";
            // 
            // txtPrecioVentaAltalier
            // 
            txtPrecioVentaAltalier.Location = new Point(285, 398);
            txtPrecioVentaAltalier.Margin = new Padding(3, 4, 3, 4);
            txtPrecioVentaAltalier.Multiline = true;
            txtPrecioVentaAltalier.Name = "txtPrecioVentaAltalier";
            txtPrecioVentaAltalier.Size = new Size(265, 35);
            txtPrecioVentaAltalier.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(15, 451);
            label7.Name = "label7";
            label7.Size = new Size(159, 25);
            label7.TabIndex = 23;
            label7.Text = "Cantidad WAMA";
            // 
            // txtCantidadWAMA
            // 
            txtCantidadWAMA.Location = new Point(15, 480);
            txtCantidadWAMA.Margin = new Padding(3, 4, 3, 4);
            txtCantidadWAMA.Multiline = true;
            txtCantidadWAMA.Name = "txtCantidadWAMA";
            txtCantidadWAMA.Size = new Size(222, 35);
            txtCantidadWAMA.TabIndex = 24;
            txtCantidadWAMA.TextChanged += txtCantidadWAMA_TextChanged;
            // 
            // txtCantidadAltalier
            // 
            txtCantidadAltalier.Location = new Point(285, 480);
            txtCantidadAltalier.Margin = new Padding(3, 4, 3, 4);
            txtCantidadAltalier.Multiline = true;
            txtCantidadAltalier.Name = "txtCantidadAltalier";
            txtCantidadAltalier.Size = new Size(265, 35);
            txtCantidadAltalier.TabIndex = 26;
            txtCantidadAltalier.TextChanged += txtCantidadAltalier_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(285, 451);
            label8.Name = "label8";
            label8.Size = new Size(180, 25);
            label8.TabIndex = 25;
            label8.Text = "Cantidad ALTALIER";
            // 
            // ActualizarInventarioForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(562, 602);
            Controls.Add(txtCantidadAltalier);
            Controls.Add(label8);
            Controls.Add(txtCantidadWAMA);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(txtPrecioVentaAltalier);
            Controls.Add(label6);
            Controls.Add(txtPrecioVenta);
            Controls.Add(label5);
            Controls.Add(txtPrecioCompra);
            Controls.Add(label4);
            Controls.Add(txtStock);
            Controls.Add(label2);
            Controls.Add(txtCantidadDisponible);
            Controls.Add(label1);
            Controls.Add(txtNombreProducto);
            Controls.Add(btnGuardar);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ActualizarInventarioForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizar inventario";
            Load += ActualizarInventarioForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTotalProducto;
        private Label lblTitulo;
        private Button btnGuardar;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        public TextBox txtNombreProducto;
        public TextBox txtStock;
        public TextBox txtPrecioCompra;
        public TextBox txtPrecioVenta;
        public TextBox txtCantidadDisponible;
        private Label label3;
        public TextBox txtPrecioVentaAltalier;
        private Label label7;
        public TextBox txtCantidadWAMA;
        public TextBox txtCantidadAltalier;
        private Label label8;
    }
}