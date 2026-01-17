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
            panel1 = new Panel();
            btnNuevaCompra = new Button();
            lblTotalProducto = new Label();
            label3 = new Label();
            lsvInventario = new ListView();
            panel1.SuspendLayout();
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
            panel1.TabIndex = 6;
            // 
            // btnNuevaCompra
            // 
            btnNuevaCompra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevaCompra.Image = Properties.Resources.icon_plus;
            btnNuevaCompra.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevaCompra.Location = new Point(1471, 0);
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
            lblTotalProducto.Location = new Point(3221, 19);
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
            label3.Size = new Size(264, 20);
            label3.TabIndex = 0;
            label3.Text = "Listado inventarios repuestos motos";
            // 
            // lsvInventario
            // 
            lsvInventario.Dock = DockStyle.Fill;
            lsvInventario.FullRowSelect = true;
            lsvInventario.GridLines = true;
            lsvInventario.Location = new Point(0, 56);
            lsvInventario.Name = "lsvInventario";
            lsvInventario.Size = new Size(914, 544);
            lsvInventario.TabIndex = 7;
            lsvInventario.UseCompatibleStateImageBehavior = false;
            lsvInventario.View = View.Details;
            // 
            // InventarioRepuestoMotoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(914, 600);
            Controls.Add(lsvInventario);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InventarioRepuestoMotoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Inventario repuestos motos";
            WindowState = FormWindowState.Maximized;
            FormClosing += InventarioRepuestoMotoForm_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnNuevaCompra;
        private Label lblTotalProducto;
        private Label label3;
        private ListView lsvInventario;
    }
}