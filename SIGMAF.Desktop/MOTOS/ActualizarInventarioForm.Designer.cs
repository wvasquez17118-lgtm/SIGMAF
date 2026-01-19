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
            panel1.Size = new Size(542, 67);
            panel1.TabIndex = 4;
            // 
            // lblTotalProducto
            // 
            lblTotalProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalProducto.AutoSize = true;
            lblTotalProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProducto.Location = new Point(1473, 25);
            lblTotalProducto.Name = "lblTotalProducto";
            lblTotalProducto.Size = new Size(61, 20);
            lblTotalProducto.TabIndex = 1;
            lblTotalProducto.Text = "Total: 0";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(21, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(247, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Actualizar producto del inventario";
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Image = Properties.Resources.icon_save;
            btnGuardar.ImageAlign = ContentAlignment.TopCenter;
            btnGuardar.Location = new Point(0, 462);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(542, 73);
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
            label1.Size = new Size(135, 20);
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
            txtNombreProducto.Size = new Size(514, 45);
            txtNombreProducto.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 155);
            label2.Name = "label2";
            label2.Size = new Size(147, 20);
            label2.TabIndex = 14;
            label2.Text = "Cantidad disponible";
            // 
            // txtCantidadDisponible
            // 
            txtCantidadDisponible.Enabled = false;
            txtCantidadDisponible.Location = new Point(14, 179);
            txtCantidadDisponible.Margin = new Padding(3, 4, 3, 4);
            txtCantidadDisponible.Multiline = true;
            txtCantidadDisponible.Name = "txtCantidadDisponible";
            txtCantidadDisponible.Size = new Size(514, 45);
            txtCantidadDisponible.TabIndex = 13;
            txtCantidadDisponible.KeyPress += txtCantidadDisponible_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(15, 228);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 16;
            label4.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.Enabled = false;
            txtStock.Location = new Point(14, 252);
            txtStock.Margin = new Padding(3, 4, 3, 4);
            txtStock.Multiline = true;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(514, 45);
            txtStock.TabIndex = 15;
            txtStock.KeyPress += txtCantidadDisponible_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 301);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 18;
            label5.Text = "Precio compra";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.Enabled = false;
            txtPrecioCompra.Location = new Point(14, 325);
            txtPrecioCompra.Margin = new Padding(3, 4, 3, 4);
            txtPrecioCompra.Multiline = true;
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(514, 45);
            txtPrecioCompra.TabIndex = 17;
            txtPrecioCompra.KeyPress += txtCantidadDisponible_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(15, 374);
            label6.Name = "label6";
            label6.Size = new Size(95, 20);
            label6.TabIndex = 20;
            label6.Text = "Precio venta";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Enabled = false;
            txtPrecioVenta.Location = new Point(14, 398);
            txtPrecioVenta.Margin = new Padding(3, 4, 3, 4);
            txtPrecioVenta.Multiline = true;
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(514, 45);
            txtPrecioVenta.TabIndex = 19;
            txtPrecioVenta.KeyPress += txtCantidadDisponible_KeyPress;
            // 
            // ActualizarInventarioForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(542, 535);
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
    }
}