namespace SIGMAF.Desktop.MOTOS
{
    partial class ListaVentasForm
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
            btnNuevaVenta = new Button();
            chALTALIER = new CheckBox();
            chWAMA = new CheckBox();
            btnRefrescar = new Button();
            label1 = new Label();
            dateFechaFinal = new DateTimePicker();
            dataFechaInicio = new DateTimePicker();
            lblFechaTitulo = new Label();
            lblTotalProducto = new Label();
            label3 = new Label();
            lsvListadoVentas = new ListView();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnNuevaVenta);
            panel1.Controls.Add(chALTALIER);
            panel1.Controls.Add(chWAMA);
            panel1.Controls.Add(btnRefrescar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateFechaFinal);
            panel1.Controls.Add(dataFechaInicio);
            panel1.Controls.Add(lblFechaTitulo);
            panel1.Controls.Add(lblTotalProducto);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1047, 62);
            panel1.TabIndex = 6;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevaVenta.Image = Properties.Resources.icon_plus;
            btnNuevaVenta.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevaVenta.Location = new Point(890, 4);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(154, 56);
            btnNuevaVenta.TabIndex = 11;
            btnNuevaVenta.Text = "Nueva venta";
            btnNuevaVenta.TextAlign = ContentAlignment.MiddleRight;
            btnNuevaVenta.UseVisualStyleBackColor = true;
            btnNuevaVenta.Click += btnNuevaVenta_Click;
            // 
            // chALTALIER
            // 
            chALTALIER.AutoSize = true;
            chALTALIER.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chALTALIER.Location = new Point(298, 17);
            chALTALIER.Name = "chALTALIER";
            chALTALIER.Size = new Size(96, 24);
            chALTALIER.TabIndex = 10;
            chALTALIER.Text = "ALTALIER";
            chALTALIER.UseVisualStyleBackColor = true;
            // 
            // chWAMA
            // 
            chWAMA.AutoSize = true;
            chWAMA.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chWAMA.Location = new Point(214, 17);
            chWAMA.Name = "chWAMA";
            chWAMA.Size = new Size(78, 24);
            chWAMA.TabIndex = 9;
            chWAMA.Text = "WAMA";
            chWAMA.UseVisualStyleBackColor = true;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefrescar.Image = Properties.Resources.icon_sincronizarguardar;
            btnRefrescar.Location = new Point(785, 3);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(96, 59);
            btnRefrescar.TabIndex = 8;
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(596, 22);
            label1.Name = "label1";
            label1.Size = new Size(21, 20);
            label1.TabIndex = 5;
            label1.Text = "--";
            // 
            // dateFechaFinal
            // 
            dateFechaFinal.Format = DateTimePickerFormat.Short;
            dateFechaFinal.Location = new Point(623, 17);
            dateFechaFinal.Name = "dateFechaFinal";
            dateFechaFinal.Size = new Size(156, 27);
            dateFechaFinal.TabIndex = 4;
            // 
            // dataFechaInicio
            // 
            dataFechaInicio.Format = DateTimePickerFormat.Short;
            dataFechaInicio.Location = new Point(434, 17);
            dataFechaInicio.Name = "dataFechaInicio";
            dataFechaInicio.Size = new Size(156, 27);
            dataFechaInicio.TabIndex = 3;
            // 
            // lblFechaTitulo
            // 
            lblFechaTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFechaTitulo.AutoSize = true;
            lblFechaTitulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaTitulo.Location = new Point(1597, 13);
            lblFechaTitulo.Name = "lblFechaTitulo";
            lblFechaTitulo.Size = new Size(143, 20);
            lblFechaTitulo.TabIndex = 2;
            lblFechaTitulo.Text = "Fecha: 09/01/2026";
            // 
            // lblTotalProducto
            // 
            lblTotalProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalProducto.AutoSize = true;
            lblTotalProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProducto.Location = new Point(3354, 19);
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
            label3.Size = new Size(131, 20);
            label3.TabIndex = 0;
            label3.Text = "Listado de ventas";
            // 
            // lsvListadoVentas
            // 
            lsvListadoVentas.Dock = DockStyle.Fill;
            lsvListadoVentas.FullRowSelect = true;
            lsvListadoVentas.GridLines = true;
            lsvListadoVentas.Location = new Point(0, 62);
            lsvListadoVentas.Name = "lsvListadoVentas";
            lsvListadoVentas.Size = new Size(1047, 538);
            lsvListadoVentas.TabIndex = 7;
            lsvListadoVentas.UseCompatibleStateImageBehavior = false;
            lsvListadoVentas.View = View.Details;
            lsvListadoVentas.DrawColumnHeader += lsvListadoVentas_DrawColumnHeader;
            lsvListadoVentas.DrawItem += lsvListadoVentas_DrawItem;
            lsvListadoVentas.DrawSubItem += lsvListadoVentas_DrawSubItem;
            // 
            // ListaVentasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(1047, 600);
            Controls.Add(lsvListadoVentas);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ListaVentasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listado de ventas";
            Load += ListaVentasForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblFechaTitulo;
        private Label lblTotalProducto;
        private Label label3;
        private ListView lsvListadoVentas;
        private DateTimePicker dataFechaInicio;
        private DateTimePicker dateFechaFinal;
        private Label label1;
        private Button btnRefrescar;
        private CheckBox chALTALIER;
        private CheckBox chWAMA;
        private Button btnNuevaVenta;
    }
}