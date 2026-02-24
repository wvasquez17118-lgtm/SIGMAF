namespace SIGMAF.Desktop.MOTOS
{
    partial class GananciasRepuestosForm
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
            label3 = new Label();
            lblTotalProducto = new Label();
            btnNuevaCompra = new Button();
            label1 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lsvData = new ListView();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            chWaMA = new CheckBox();
            chALTALIER = new CheckBox();
            btnRefrescar = new Button();
            dateFechaFinal = new DateTimePicker();
            label4 = new Label();
            dateFechaInicio = new DateTimePicker();
            label2 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnUnidades = new Button();
            btnGanancias = new Button();
            btnCostos = new Button();
            btnTotal = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1352, 28);
            label3.Name = "label3";
            label3.Size = new Size(264, 20);
            label3.TabIndex = 0;
            label3.Text = "Listado inventarios repuestos motos";
            // 
            // lblTotalProducto
            // 
            lblTotalProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalProducto.AutoSize = true;
            lblTotalProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProducto.Location = new Point(3935, 19);
            lblTotalProducto.Name = "lblTotalProducto";
            lblTotalProducto.Size = new Size(61, 20);
            lblTotalProducto.TabIndex = 1;
            lblTotalProducto.Text = "Total: 0";
            // 
            // btnNuevaCompra
            // 
            btnNuevaCompra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevaCompra.Image = Properties.Resources.icon_plus;
            btnNuevaCompra.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevaCompra.Location = new Point(2185, 0);
            btnNuevaCompra.Name = "btnNuevaCompra";
            btnNuevaCompra.Size = new Size(154, 56);
            btnNuevaCompra.TabIndex = 2;
            btnNuevaCompra.Text = "Nueva compra";
            btnNuevaCompra.TextAlign = ContentAlignment.MiddleRight;
            btnNuevaCompra.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(301, 20);
            label1.TabIndex = 3;
            label1.Text = "Ganancias de ventas de respuestos motos";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnNuevaCompra);
            panel1.Controls.Add(lblTotalProducto);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 37);
            panel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lsvData, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 37);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 38.4615364F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 38.46154F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.0769253F));
            tableLayoutPanel1.Size = new Size(914, 620);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // lsvData
            // 
            lsvData.Dock = DockStyle.Fill;
            lsvData.GridLines = true;
            lsvData.Location = new Point(3, 479);
            lsvData.Name = "lsvData";
            lsvData.Size = new Size(908, 138);
            lsvData.TabIndex = 0;
            lsvData.UseCompatibleStateImageBehavior = false;
            lsvData.View = View.Details;
            lsvData.DrawColumnHeader += lsvData_DrawColumnHeader;
            lsvData.DrawItem += lsvData_DrawItem;
            lsvData.DrawSubItem += lsvData_DrawSubItem;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(908, 232);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chWaMA);
            groupBox1.Controls.Add(chALTALIER);
            groupBox1.Controls.Add(btnRefrescar);
            groupBox1.Controls.Add(dateFechaFinal);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dateFechaInicio);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(902, 74);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // chWaMA
            // 
            chWaMA.AutoSize = true;
            chWaMA.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chWaMA.Location = new Point(158, 31);
            chWaMA.Name = "chWaMA";
            chWaMA.Size = new Size(78, 24);
            chWaMA.TabIndex = 12;
            chWaMA.Text = "WAMA";
            chWaMA.UseVisualStyleBackColor = true;
            // 
            // chALTALIER
            // 
            chALTALIER.AutoSize = true;
            chALTALIER.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chALTALIER.Location = new Point(237, 31);
            chALTALIER.Name = "chALTALIER";
            chALTALIER.Size = new Size(96, 24);
            chALTALIER.TabIndex = 11;
            chALTALIER.Text = "ALTALIER";
            chALTALIER.UseVisualStyleBackColor = true;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefrescar.Image = Properties.Resources.icon_sincronizarguardar;
            btnRefrescar.Location = new Point(806, 13);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(96, 58);
            btnRefrescar.TabIndex = 7;
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // dateFechaFinal
            // 
            dateFechaFinal.Anchor = AnchorStyles.Top;
            dateFechaFinal.Format = DateTimePickerFormat.Short;
            dateFechaFinal.Location = new Point(567, 26);
            dateFechaFinal.Name = "dateFechaFinal";
            dateFechaFinal.Size = new Size(131, 27);
            dateFechaFinal.TabIndex = 3;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(539, 31);
            label4.Name = "label4";
            label4.Size = new Size(21, 20);
            label4.TabIndex = 2;
            label4.Text = "--";
            // 
            // dateFechaInicio
            // 
            dateFechaInicio.Anchor = AnchorStyles.Top;
            dateFechaInicio.Format = DateTimePickerFormat.Short;
            dateFechaInicio.Location = new Point(399, 26);
            dateFechaInicio.Name = "dateFechaInicio";
            dateFechaInicio.Size = new Size(135, 27);
            dateFechaInicio.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(339, 31);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 0;
            label2.Text = "Desde:";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Controls.Add(btnUnidades, 3, 0);
            tableLayoutPanel3.Controls.Add(btnGanancias, 2, 0);
            tableLayoutPanel3.Controls.Add(btnCostos, 1, 0);
            tableLayoutPanel3.Controls.Add(btnTotal, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 83);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(902, 146);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // btnUnidades
            // 
            btnUnidades.BackColor = Color.DarkSeaGreen;
            btnUnidades.Dock = DockStyle.Fill;
            btnUnidades.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUnidades.ForeColor = Color.White;
            btnUnidades.Location = new Point(678, 3);
            btnUnidades.Name = "btnUnidades";
            btnUnidades.Size = new Size(221, 140);
            btnUnidades.TabIndex = 3;
            btnUnidades.Text = "Unidades\r\n\r0";
            btnUnidades.UseVisualStyleBackColor = false;
            // 
            // btnGanancias
            // 
            btnGanancias.BackColor = Color.MediumSeaGreen;
            btnGanancias.Dock = DockStyle.Fill;
            btnGanancias.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGanancias.ForeColor = Color.White;
            btnGanancias.Location = new Point(453, 3);
            btnGanancias.Name = "btnGanancias";
            btnGanancias.Size = new Size(219, 140);
            btnGanancias.TabIndex = 2;
            btnGanancias.Text = "Ganancias\r\n\r\nC$ 0";
            btnGanancias.UseVisualStyleBackColor = false;
            // 
            // btnCostos
            // 
            btnCostos.BackColor = Color.Crimson;
            btnCostos.Dock = DockStyle.Fill;
            btnCostos.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCostos.ForeColor = Color.White;
            btnCostos.Location = new Point(228, 3);
            btnCostos.Name = "btnCostos";
            btnCostos.Size = new Size(219, 140);
            btnCostos.TabIndex = 1;
            btnCostos.Text = "Costos\r\n\r\n0";
            btnCostos.UseVisualStyleBackColor = false;
            // 
            // btnTotal
            // 
            btnTotal.BackColor = SystemColors.MenuHighlight;
            btnTotal.Dock = DockStyle.Fill;
            btnTotal.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTotal.ForeColor = Color.White;
            btnTotal.Location = new Point(3, 3);
            btnTotal.Name = "btnTotal";
            btnTotal.Size = new Size(219, 140);
            btnTotal.TabIndex = 0;
            btnTotal.Text = "Total \r\n\r\n C$ 0";
            btnTotal.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel4.Controls.Add(panel2, 0, 0);
            tableLayoutPanel4.Controls.Add(panel3, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 241);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(908, 232);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(357, 226);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(366, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(539, 226);
            panel3.TabIndex = 1;
            // 
            // GananciasRepuestosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(914, 657);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GananciasRepuestosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estadistica ganancias repuestos";
            WindowState = FormWindowState.Maximized;
            FormClosing += GananciasRepuestosForm_FormClosing;
            Load += GananciasRepuestosForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Label lblTotalProducto;
        private Button btnNuevaCompra;
        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private ListView lsvData;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox1;
        private DateTimePicker dateFechaInicio;
        private Label label2;
        private DateTimePicker dateFechaFinal;
        private Label label4;
        private Button btnRefrescar;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnTotal;
        private Button btnUnidades;
        private Button btnGanancias;
        private Button btnCostos;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel2;
        private Panel panel3;
        private CheckBox chWaMA;
        private CheckBox chALTALIER;
    }
}