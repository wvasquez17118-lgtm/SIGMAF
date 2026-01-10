namespace SIGMAF.Desktop.MOTOS
{
    partial class RegistrarVentaForm
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
            lblFechaTitulo = new Label();
            lblTotalProducto = new Label();
            label3 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            dataGridProductosCatalogos = new DataGridView();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            groupBox3 = new GroupBox();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProductosCatalogos).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(lblFechaTitulo);
            panel1.Controls.Add(lblTotalProducto);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 44);
            panel1.TabIndex = 5;
            // 
            // lblFechaTitulo
            // 
            lblFechaTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFechaTitulo.AutoSize = true;
            lblFechaTitulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaTitulo.Location = new Point(750, 13);
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
            label3.Location = new Point(18, 13);
            label3.Name = "label3";
            label3.Size = new Size(162, 20);
            label3.TabIndex = 0;
            label3.Text = "Registrar nueva venta";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox3, 1, 0);
            tableLayoutPanel1.Controls.Add(button1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 44);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(914, 556);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridProductosCatalogos);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(608, 272);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Producto";
            // 
            // dataGridProductosCatalogos
            // 
            dataGridProductosCatalogos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridProductosCatalogos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProductosCatalogos.Location = new Point(6, 70);
            dataGridProductosCatalogos.Name = "dataGridProductosCatalogos";
            dataGridProductosCatalogos.Size = new Size(596, 196);
            dataGridProductosCatalogos.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(6, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(596, 27);
            textBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 281);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(608, 272);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle producto";
            // 
            // textBox4
            // 
            textBox4.Enabled = false;
            textBox4.Location = new Point(6, 201);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(532, 27);
            textBox4.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 178);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 4;
            label5.Text = "Disponible";
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(6, 134);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(532, 27);
            textBox3.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 111);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 2;
            label4.Text = "Precio producto";
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(6, 71);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(532, 27);
            textBox2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 0;
            label2.Text = "Producto";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox6);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(textBox5);
            groupBox3.Controls.Add(label6);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(617, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(294, 272);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Detalle venta";
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox6.Enabled = false;
            textBox6.Location = new Point(6, 123);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(282, 27);
            textBox6.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 100);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 4;
            label7.Text = "Total";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox5.Enabled = false;
            textBox5.Location = new Point(6, 58);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(282, 27);
            textBox5.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 35);
            label6.Name = "label6";
            label6.Size = new Size(123, 20);
            label6.TabIndex = 2;
            label6.Text = "Cantidad vender";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.Green;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.icon_save;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(617, 281);
            button1.Name = "button1";
            button1.Padding = new Padding(30, 0, 0, 0);
            button1.Size = new Size(294, 68);
            button1.TabIndex = 3;
            button1.Text = "REGISTRAR VENTA";
            button1.UseVisualStyleBackColor = false;
            // 
            // RegistrarVentaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(914, 600);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RegistrarVentaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar nueva venta";
            FormClosing += RegistrarVentaForm_FormClosing;
            Load += RegistrarVentaForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProductosCatalogos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTotalProducto;
        private Label label3;
        private Label lblFechaTitulo;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private DataGridView dataGridProductosCatalogos;
        private GroupBox groupBox2;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private GroupBox groupBox3;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox5;
        private Label label6;
        private Button button1;
    }
}