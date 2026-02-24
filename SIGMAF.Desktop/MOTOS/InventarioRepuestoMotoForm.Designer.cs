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
            label1 = new Label();
            txtBuscarProducto = new TextBox();
            btnNuevaCompra = new Button();
            lblTotalProducto = new Label();
            label3 = new Label();
            lsvInventario = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            actualizarDisponibleToolStripMenuItem = new ToolStripMenuItem();
            actualizarStockToolStripMenuItem = new ToolStripMenuItem();
            actualizarPrecioCompraToolStripMenuItem = new ToolStripMenuItem();
            actualizarPrecioVentaToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtBuscarProducto);
            panel1.Controls.Add(btnNuevaCompra);
            panel1.Controls.Add(lblTotalProducto);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(897, 73);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 5);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 4;
            label1.Text = "Busqueda de producto";
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(12, 35);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(308, 27);
            txtBuscarProducto.TabIndex = 3;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // btnNuevaCompra
            // 
            btnNuevaCompra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevaCompra.Image = Properties.Resources.icon_plus;
            btnNuevaCompra.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevaCompra.Location = new Point(1454, 0);
            btnNuevaCompra.Name = "btnNuevaCompra";
            btnNuevaCompra.Size = new Size(154, 56);
            btnNuevaCompra.TabIndex = 2;
            btnNuevaCompra.Text = "Nueva compra";
            btnNuevaCompra.TextAlign = ContentAlignment.MiddleRight;
            btnNuevaCompra.UseVisualStyleBackColor = true;
            // 
            // lblTotalProducto
            // 
            lblTotalProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalProducto.AutoSize = true;
            lblTotalProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProducto.Location = new Point(3204, 19);
            lblTotalProducto.Name = "lblTotalProducto";
            lblTotalProducto.Size = new Size(61, 20);
            lblTotalProducto.TabIndex = 1;
            lblTotalProducto.Text = "Total: 0";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(621, 28);
            label3.Name = "label3";
            label3.Size = new Size(264, 20);
            label3.TabIndex = 0;
            label3.Text = "Listado inventarios repuestos motos";
            // 
            // lsvInventario
            // 
            lsvInventario.ContextMenuStrip = contextMenuStrip1;
            lsvInventario.Dock = DockStyle.Fill;
            lsvInventario.FullRowSelect = true;
            lsvInventario.GridLines = true;
            lsvInventario.Location = new Point(0, 73);
            lsvInventario.Name = "lsvInventario";
            lsvInventario.Size = new Size(897, 565);
            lsvInventario.TabIndex = 7;
            lsvInventario.UseCompatibleStateImageBehavior = false;
            lsvInventario.View = View.Details;
            lsvInventario.DrawColumnHeader += lsvInventario_DrawColumnHeader;
            lsvInventario.DrawItem += lsvInventario_DrawItem;
            lsvInventario.DrawSubItem += lsvInventario_DrawSubItem;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { actualizarDisponibleToolStripMenuItem, actualizarStockToolStripMenuItem, actualizarPrecioCompraToolStripMenuItem, actualizarPrecioVentaToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(207, 92);
            // 
            // actualizarDisponibleToolStripMenuItem
            // 
            actualizarDisponibleToolStripMenuItem.Name = "actualizarDisponibleToolStripMenuItem";
            actualizarDisponibleToolStripMenuItem.Size = new Size(206, 22);
            actualizarDisponibleToolStripMenuItem.Text = "Actualizar Disponible";
            actualizarDisponibleToolStripMenuItem.Click += actualizarDisponibleToolStripMenuItem_Click;
            // 
            // actualizarStockToolStripMenuItem
            // 
            actualizarStockToolStripMenuItem.Name = "actualizarStockToolStripMenuItem";
            actualizarStockToolStripMenuItem.Size = new Size(206, 22);
            actualizarStockToolStripMenuItem.Text = "Actualizar Stock";
            actualizarStockToolStripMenuItem.Click += actualizarStockToolStripMenuItem_Click;
            // 
            // actualizarPrecioCompraToolStripMenuItem
            // 
            actualizarPrecioCompraToolStripMenuItem.Name = "actualizarPrecioCompraToolStripMenuItem";
            actualizarPrecioCompraToolStripMenuItem.Size = new Size(206, 22);
            actualizarPrecioCompraToolStripMenuItem.Text = "Actualizar precio compra";
            actualizarPrecioCompraToolStripMenuItem.Click += actualizarPrecioCompraToolStripMenuItem_Click;
            // 
            // actualizarPrecioVentaToolStripMenuItem
            // 
            actualizarPrecioVentaToolStripMenuItem.Name = "actualizarPrecioVentaToolStripMenuItem";
            actualizarPrecioVentaToolStripMenuItem.Size = new Size(206, 22);
            actualizarPrecioVentaToolStripMenuItem.Text = "Actualizar  precio venta";
            actualizarPrecioVentaToolStripMenuItem.Click += actualizarPrecioVentaToolStripMenuItem_Click;
            // 
            // InventarioRepuestoMotoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(897, 638);
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
        private Button btnNuevaCompra;
        private Label lblTotalProducto;
        private Label label3;
        private ListView lsvInventario;
        private TextBox txtBuscarProducto;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem actualizarDisponibleToolStripMenuItem;
        private ToolStripMenuItem actualizarStockToolStripMenuItem;
        private ToolStripMenuItem actualizarPrecioCompraToolStripMenuItem;
        private ToolStripMenuItem actualizarPrecioVentaToolStripMenuItem;
    }
}