namespace SIGMAF.Desktop.MOTOS
{
    partial class ComprasForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            dataGridProductosCatalogos = new DataGridView();
            txtFiltrarProductos = new TextBox();
            groupBox2 = new GroupBox();
            btnGuardar = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            groupBox3 = new GroupBox();
            cmbTipoFactura = new ComboBox();
            label4 = new Label();
            cmbProveedor = new ComboBox();
            label2 = new Label();
            dateFechaCompra = new DateTimePicker();
            label1 = new Label();
            groupBox4 = new GroupBox();
            txtTotal = new TextBox();
            label7 = new Label();
            txtDescuento = new TextBox();
            label6 = new Label();
            txtSubTotal = new TextBox();
            label5 = new Label();
            groupBox5 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            dataGridProductosComprados = new DataGridView();
            groupBox6 = new GroupBox();
            lblSumaTotalPrecio = new Label();
            lblTotalProductos = new Label();
            label9 = new Label();
            label8 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProductosCatalogos).BeginInit();
            groupBox2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProductosComprados).BeginInit();
            groupBox6.SuspendLayout();
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
            panel1.Size = new Size(978, 44);
            panel1.TabIndex = 4;
            // 
            // lblTotalProducto
            // 
            lblTotalProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalProducto.AutoSize = true;
            lblTotalProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProducto.Location = new Point(1793, 19);
            lblTotalProducto.Name = "lblTotalProducto";
            lblTotalProducto.Size = new Size(61, 20);
            lblTotalProducto.TabIndex = 1;
            lblTotalProducto.Text = "Total: 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 13);
            label3.Name = "label3";
            label3.Size = new Size(218, 20);
            label3.TabIndex = 0;
            label3.Text = "Agregar detalles de la compra";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox5, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 44);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(978, 586);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(972, 287);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridProductosCatalogos);
            groupBox1.Controls.Add(txtFiltrarProductos);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(480, 281);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Productos disponibles";
            // 
            // dataGridProductosCatalogos
            // 
            dataGridProductosCatalogos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridProductosCatalogos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProductosCatalogos.Location = new Point(12, 71);
            dataGridProductosCatalogos.Name = "dataGridProductosCatalogos";
            dataGridProductosCatalogos.Size = new Size(462, 204);
            dataGridProductosCatalogos.TabIndex = 1;
            dataGridProductosCatalogos.CellContentClick += dataGridProductosCatalogos_CellContentClick;
            // 
            // txtFiltrarProductos
            // 
            txtFiltrarProductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFiltrarProductos.Location = new Point(12, 26);
            txtFiltrarProductos.Name = "txtFiltrarProductos";
            txtFiltrarProductos.Size = new Size(462, 27);
            txtFiltrarProductos.TabIndex = 0;
            txtFiltrarProductos.TextChanged += txtFiltrarProductos_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnGuardar);
            groupBox2.Controls.Add(tableLayoutPanel3);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(489, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(480, 281);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle de la compra";
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnGuardar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Image = Properties.Resources.icon_save;
            btnGuardar.ImageAlign = ContentAlignment.TopCenter;
            btnGuardar.Location = new Point(0, 226);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(483, 55);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.TextAlign = ContentAlignment.BottomCenter;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel3.Controls.Add(groupBox4, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 23);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(474, 255);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmbTipoFactura);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(cmbProveedor);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(dateFechaCompra);
            groupBox3.Controls.Add(label1);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(231, 249);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            // 
            // cmbTipoFactura
            // 
            cmbTipoFactura.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTipoFactura.FormattingEnabled = true;
            cmbTipoFactura.Location = new Point(6, 153);
            cmbTipoFactura.Name = "cmbTipoFactura";
            cmbTipoFactura.Size = new Size(219, 28);
            cmbTipoFactura.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 130);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 4;
            label4.Text = "Tipo factura";
            // 
            // cmbProveedor
            // 
            cmbProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(6, 99);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(219, 28);
            cmbProveedor.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 76);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 2;
            label2.Text = "Proveedor";
            // 
            // dateFechaCompra
            // 
            dateFechaCompra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateFechaCompra.Location = new Point(6, 46);
            dateFechaCompra.Name = "dateFechaCompra";
            dateFechaCompra.Size = new Size(219, 27);
            dateFechaCompra.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Fecha";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtTotal);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(txtDescuento);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(txtSubTotal);
            groupBox4.Controls.Add(label5);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(240, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(231, 249);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTotal.Location = new Point(6, 154);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(219, 27);
            txtTotal.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 129);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 5;
            label7.Text = "Total";
            // 
            // txtDescuento
            // 
            txtDescuento.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescuento.Location = new Point(6, 100);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.Size = new Size(219, 27);
            txtDescuento.TabIndex = 4;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 78);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 3;
            label6.Text = "Descuento";
            // 
            // txtSubTotal
            // 
            txtSubTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSubTotal.Location = new Point(6, 48);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.Size = new Size(219, 27);
            txtSubTotal.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 23);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 1;
            label5.Text = "SubTotal";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(tableLayoutPanel4);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(3, 296);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(972, 287);
            groupBox5.TabIndex = 1;
            groupBox5.TabStop = false;
            groupBox5.Text = "Detalle  de productos de la compra";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78.125F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.875F));
            tableLayoutPanel4.Controls.Add(dataGridProductosComprados, 0, 0);
            tableLayoutPanel4.Controls.Add(groupBox6, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 23);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(966, 261);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // dataGridProductosComprados
            // 
            dataGridProductosComprados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProductosComprados.Dock = DockStyle.Fill;
            dataGridProductosComprados.Location = new Point(3, 3);
            dataGridProductosComprados.Name = "dataGridProductosComprados";
            dataGridProductosComprados.Size = new Size(748, 255);
            dataGridProductosComprados.TabIndex = 0;
            dataGridProductosComprados.CellClick += dataGridProductosComprados_CellClick;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lblSumaTotalPrecio);
            groupBox6.Controls.Add(lblTotalProductos);
            groupBox6.Controls.Add(label9);
            groupBox6.Controls.Add(label8);
            groupBox6.Dock = DockStyle.Fill;
            groupBox6.Location = new Point(757, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(206, 255);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            // 
            // lblSumaTotalPrecio
            // 
            lblSumaTotalPrecio.AutoSize = true;
            lblSumaTotalPrecio.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSumaTotalPrecio.Location = new Point(6, 124);
            lblSumaTotalPrecio.Name = "lblSumaTotalPrecio";
            lblSumaTotalPrecio.Size = new Size(96, 37);
            lblSumaTotalPrecio.TabIndex = 11;
            lblSumaTotalPrecio.Text = "C$  25";
            // 
            // lblTotalProductos
            // 
            lblTotalProductos.AutoSize = true;
            lblTotalProductos.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProductos.Location = new Point(39, 46);
            lblTotalProductos.Name = "lblTotalProductos";
            lblTotalProductos.Size = new Size(33, 37);
            lblTotalProductos.TabIndex = 10;
            lblTotalProductos.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(6, 104);
            label9.Name = "label9";
            label9.Size = new Size(132, 20);
            label9.TabIndex = 8;
            label9.Text = "Suma total precio";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 23);
            label8.Name = "label8";
            label8.Size = new Size(119, 20);
            label8.TabIndex = 6;
            label8.Text = "Total productos";
            // 
            // ComprasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(978, 630);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ComprasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compras";
            WindowState = FormWindowState.Maximized;
            FormClosing += ComprasForm_FormClosing;
            Load += ComprasForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProductosCatalogos).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridProductosComprados).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTotalProducto;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox1;
        private DataGridView dataGridProductosCatalogos;
        private TextBox txtFiltrarProductos;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnGuardar;
        private GroupBox groupBox3;
        private Label label1;
        private DateTimePicker dateFechaCompra;
        private ComboBox cmbProveedor;
        private Label label2;
        private ComboBox cmbTipoFactura;
        private Label label4;
        private GroupBox groupBox4;
        private TextBox txtSubTotal;
        private Label label5;
        private TextBox txtTotal;
        private Label label7;
        private TextBox txtDescuento;
        private Label label6;
        private GroupBox groupBox5;
        private TableLayoutPanel tableLayoutPanel4;
        private DataGridView dataGridProductosComprados;
        private GroupBox groupBox6;
        private Label label9;
        private Label label8;
        private Label lblTotalProductos;
        private Label lblSumaTotalPrecio;
    }
}