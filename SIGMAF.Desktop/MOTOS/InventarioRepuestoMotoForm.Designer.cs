namespace SIGMAF.Desktop.MOTOS
{
    partial class InventarioRepuestoMotoForm
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
            panel1 = new Panel();
            btnRefrescar = new Button();
            chkStockMinimo = new CheckBox();
            label1 = new Label();
            txtBuscarProducto = new TextBox();
            lblTotalProductos = new Label();
            lblAlertaStock = new Label();
            lsvInventario = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            actualizarDisponibleToolStripMenuItem = new ToolStripMenuItem();
            productosCon1DisponibleWamaToolStripMenuItem = new ToolStripMenuItem();
            productosCon1DisponibleAltalierToolStripMenuItem = new ToolStripMenuItem();
            productosSinPrecioVentaToolStripMenuItem = new ToolStripMenuItem();
            productosSinPrecioCompraToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnRefrescar);
            panel1.Controls.Add(chkStockMinimo);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtBuscarProducto);
            panel1.Controls.Add(lblTotalProductos);
            panel1.Controls.Add(lblAlertaStock);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1120, 73);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefrescar.Image = Properties.Resources.icon_sincronizarguardar;
            btnRefrescar.Location = new Point(1021, 5);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(96, 58);
            btnRefrescar.TabIndex = 8;
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // chkStockMinimo
            // 
            chkStockMinimo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkStockMinimo.AutoSize = true;
            chkStockMinimo.Location = new Point(811, 25);
            chkStockMinimo.Name = "chkStockMinimo";
            chkStockMinimo.Size = new Size(204, 29);
            chkStockMinimo.TabIndex = 9;
            chkStockMinimo.Text = "Disponible <= Stock";
            chkStockMinimo.UseVisualStyleBackColor = true;
            chkStockMinimo.CheckedChanged += chkStockMinimo_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 5);
            label1.Name = "label1";
            label1.Size = new Size(206, 25);
            label1.TabIndex = 4;
            label1.Text = "Busqueda de producto";
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(12, 35);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(273, 32);
            txtBuscarProducto.TabIndex = 3;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // lblTotalProductos
            // 
            lblTotalProductos.AutoSize = true;
            lblTotalProductos.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProductos.Location = new Point(291, 42);
            lblTotalProductos.Name = "lblTotalProductos";
            lblTotalProductos.Size = new Size(165, 25);
            lblTotalProductos.TabIndex = 10;
            lblTotalProductos.Text = "Total productos: 0";
            // 
            // lblAlertaStock
            // 
            lblAlertaStock.AutoSize = true;
            lblAlertaStock.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAlertaStock.ForeColor = Color.Red;
            lblAlertaStock.Location = new Point(510, 42);
            lblAlertaStock.Name = "lblAlertaStock";
            lblAlertaStock.Size = new Size(259, 25);
            lblAlertaStock.TabIndex = 11;
            lblAlertaStock.Text = "Productos bajo stock bodega";
            lblAlertaStock.Visible = false;
            // 
            // lsvInventario
            // 
            lsvInventario.ContextMenuStrip = contextMenuStrip1;
            lsvInventario.Dock = DockStyle.Fill;
            lsvInventario.FullRowSelect = true;
            lsvInventario.GridLines = true;
            lsvInventario.Location = new Point(0, 73);
            lsvInventario.Name = "lsvInventario";
            lsvInventario.Size = new Size(1120, 565);
            lsvInventario.TabIndex = 7;
            lsvInventario.UseCompatibleStateImageBehavior = false;
            lsvInventario.View = View.Details;
            lsvInventario.DrawColumnHeader += lsvInventario_DrawColumnHeader;
            lsvInventario.DrawItem += lsvInventario_DrawItem;
            lsvInventario.DrawSubItem += lsvInventario_DrawSubItem;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { actualizarDisponibleToolStripMenuItem, productosCon1DisponibleWamaToolStripMenuItem, productosCon1DisponibleAltalierToolStripMenuItem, productosSinPrecioVentaToolStripMenuItem, productosSinPrecioCompraToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(373, 124);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // actualizarDisponibleToolStripMenuItem
            // 
            actualizarDisponibleToolStripMenuItem.Name = "actualizarDisponibleToolStripMenuItem";
            actualizarDisponibleToolStripMenuItem.Size = new Size(330, 24);
            actualizarDisponibleToolStripMenuItem.Text = "Actualizar registros";
            actualizarDisponibleToolStripMenuItem.Click += actualizarDisponibleToolStripMenuItem_Click;
            // 
            // productosCon1DisponibleWamaToolStripMenuItem
            // 
            productosCon1DisponibleWamaToolStripMenuItem.Name = "productosCon1DisponibleWamaToolStripMenuItem";
            productosCon1DisponibleWamaToolStripMenuItem.Size = new Size(330, 24);
            productosCon1DisponibleWamaToolStripMenuItem.Text = "Productos con 2 o menos disponibles en WAMA";
            productosCon1DisponibleWamaToolStripMenuItem.Click += productosCon1DisponibleWamaToolStripMenuItem_Click;
            // 
            // productosCon1DisponibleAltalierToolStripMenuItem
            // 
            productosCon1DisponibleAltalierToolStripMenuItem.Name = "productosCon1DisponibleAltalierToolStripMenuItem";
            productosCon1DisponibleAltalierToolStripMenuItem.Size = new Size(330, 24);
            productosCon1DisponibleAltalierToolStripMenuItem.Text = "Productos con 2 o menos disponibles en Altalier";
            productosCon1DisponibleAltalierToolStripMenuItem.Click += productosCon1DisponibleAltalierToolStripMenuItem_Click;
            // 
            // productosSinPrecioVentaToolStripMenuItem
            // 
            productosSinPrecioVentaToolStripMenuItem.Name = "productosSinPrecioVentaToolStripMenuItem";
            productosSinPrecioVentaToolStripMenuItem.Size = new Size(372, 24);
            productosSinPrecioVentaToolStripMenuItem.Text = "Productos sin precio venta WAMA o Altalier";
            productosSinPrecioVentaToolStripMenuItem.Click += productosSinPrecioVentaToolStripMenuItem_Click;
            // 
            // productosSinPrecioCompraToolStripMenuItem
            // 
            productosSinPrecioCompraToolStripMenuItem.Name = "productosSinPrecioCompraToolStripMenuItem";
            productosSinPrecioCompraToolStripMenuItem.Size = new Size(372, 24);
            productosSinPrecioCompraToolStripMenuItem.Text = "Productos sin precio compra";
            productosSinPrecioCompraToolStripMenuItem.Click += productosSinPrecioCompraToolStripMenuItem_Click;
            // 
            // InventarioRepuestoMotoForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(1120, 638);
            Controls.Add(lsvInventario);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InventarioRepuestoMotoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Inventario repuestos motos";
            WindowState = FormWindowState.Maximized;
            FormClosing += InventarioRepuestoMotoForm_FormClosing;
            Load += InventarioRepuestoMotoForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListView lsvInventario;
        private TextBox txtBuscarProducto;
        private Label lblTotalProductos;
        private Label lblAlertaStock;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem actualizarDisponibleToolStripMenuItem;
        private ToolStripMenuItem productosCon1DisponibleWamaToolStripMenuItem;
        private ToolStripMenuItem productosCon1DisponibleAltalierToolStripMenuItem;
        private ToolStripMenuItem productosSinPrecioVentaToolStripMenuItem;
        private ToolStripMenuItem productosSinPrecioCompraToolStripMenuItem;
        private CheckBox chkStockMinimo;
        private Button btnRefrescar;
    }
}
