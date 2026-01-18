namespace SIGMAF.Desktop.MOTOS
{
    partial class ListarComprasForm
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
            btnNuevaCompra = new Button();
            lblTotalProducto = new Label();
            label3 = new Label();
            lsvListadoCompras = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editarCompraFacturaToolStripMenuItem = new ToolStripMenuItem();
            aplicarCompraFacturaToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnNuevaCompra);
            panel1.Controls.Add(lblTotalProducto);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 56);
            panel1.TabIndex = 5;
            // 
            // btnNuevaCompra
            // 
            btnNuevaCompra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevaCompra.Image = Properties.Resources.icon_plus;
            btnNuevaCompra.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevaCompra.Location = new Point(757, 0);
            btnNuevaCompra.Name = "btnNuevaCompra";
            btnNuevaCompra.Size = new Size(154, 56);
            btnNuevaCompra.TabIndex = 2;
            btnNuevaCompra.Text = "Nueva compra";
            btnNuevaCompra.TextAlign = ContentAlignment.MiddleRight;
            btnNuevaCompra.UseVisualStyleBackColor = true;
            btnNuevaCompra.Click += btnNuevaCompra_Click;
            // 
            // lblTotalProducto
            // 
            lblTotalProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalProducto.AutoSize = true;
            lblTotalProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProducto.Location = new Point(2507, 19);
            lblTotalProducto.Name = "lblTotalProducto";
            lblTotalProducto.Size = new Size(61, 20);
            lblTotalProducto.TabIndex = 1;
            lblTotalProducto.Text = "Total: 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 18);
            label3.Name = "label3";
            label3.Size = new Size(220, 20);
            label3.TabIndex = 0;
            label3.Text = "Listado de compras (Facturas)";
            // 
            // lsvListadoCompras
            // 
            lsvListadoCompras.ContextMenuStrip = contextMenuStrip1;
            lsvListadoCompras.Dock = DockStyle.Fill;
            lsvListadoCompras.FullRowSelect = true;
            lsvListadoCompras.GridLines = true;
            lsvListadoCompras.Location = new Point(0, 56);
            lsvListadoCompras.Name = "lsvListadoCompras";
            lsvListadoCompras.Size = new Size(914, 544);
            lsvListadoCompras.TabIndex = 6;
            lsvListadoCompras.UseCompatibleStateImageBehavior = false;
            lsvListadoCompras.View = View.Details;
            lsvListadoCompras.DrawColumnHeader += lsvListadoCompras_DrawColumnHeader;
            lsvListadoCompras.DrawItem += lsvListadoCompras_DrawItem;
            lsvListadoCompras.DrawSubItem += lsvListadoCompras_DrawSubItem;
            lsvListadoCompras.MouseDown += lsvListadoCompras_MouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editarCompraFacturaToolStripMenuItem, aplicarCompraFacturaToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(206, 70);
            // 
            // editarCompraFacturaToolStripMenuItem
            // 
            editarCompraFacturaToolStripMenuItem.Name = "editarCompraFacturaToolStripMenuItem";
            editarCompraFacturaToolStripMenuItem.Size = new Size(205, 22);
            editarCompraFacturaToolStripMenuItem.Text = "Editar compra (Factura)";
            editarCompraFacturaToolStripMenuItem.Click += editarCompraFacturaToolStripMenuItem_Click;
            // 
            // aplicarCompraFacturaToolStripMenuItem
            // 
            aplicarCompraFacturaToolStripMenuItem.Name = "aplicarCompraFacturaToolStripMenuItem";
            aplicarCompraFacturaToolStripMenuItem.Size = new Size(205, 22);
            aplicarCompraFacturaToolStripMenuItem.Text = "Aplicar compra (Factura)";
            aplicarCompraFacturaToolStripMenuItem.Click += aplicarCompraFacturaToolStripMenuItem_Click;
            // 
            // ListarComprasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(914, 600);
            Controls.Add(lsvListadoCompras);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ListarComprasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listado de compras";
            WindowState = FormWindowState.Maximized;
            FormClosing += ListarComprasForm_FormClosing;
            Load += ListarComprasForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTotalProducto;
        private Label label3;
        private ListView lsvListadoCompras;
        private Button btnNuevaCompra;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editarCompraFacturaToolStripMenuItem;
        private ToolStripMenuItem aplicarCompraFacturaToolStripMenuItem;
    }
}