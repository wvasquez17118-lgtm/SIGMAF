namespace SIGMAF.Desktop.MOTOS
{
    partial class EstadoResultadoFinancieroForm
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
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            lstCostosFijos = new ListView();
            groupBox3 = new GroupBox();
            lsvResultadoOperacion = new ListView();
            groupBox1 = new GroupBox();
            btnRefrescar = new Button();
            dateFechaFinal = new DateTimePicker();
            label4 = new Label();
            dateFechaInicio = new DateTimePicker();
            label2 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 60);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(347, 25);
            label1.TabIndex = 0;
            label1.Text = "Estado de resultado financiero mensual";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 60);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1100, 502);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(groupBox2, 0, 0);
            tableLayoutPanel2.Controls.Add(groupBox3, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 103);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1094, 396);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstCostosFijos);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(541, 390);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Costos Fijos";
            // 
            // lstCostosFijos
            // 
            lstCostosFijos.Dock = DockStyle.Fill;
            lstCostosFijos.FullRowSelect = true;
            lstCostosFijos.GridLines = true;
            lstCostosFijos.Location = new Point(3, 28);
            lstCostosFijos.Name = "lstCostosFijos";
            lstCostosFijos.Size = new Size(535, 359);
            lstCostosFijos.TabIndex = 1;
            lstCostosFijos.UseCompatibleStateImageBehavior = false;
            lstCostosFijos.View = View.Details;
            lstCostosFijos.DrawColumnHeader += ListView_DrawColumnHeader;
            lstCostosFijos.DrawItem += ListView_DrawItem;
            lstCostosFijos.DrawSubItem += ListView_DrawSubItem;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lsvResultadoOperacion);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(550, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(541, 390);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Resultado operaciones";
            // 
            // lsvResultadoOperacion
            // 
            lsvResultadoOperacion.Dock = DockStyle.Fill;
            lsvResultadoOperacion.FullRowSelect = true;
            lsvResultadoOperacion.GridLines = true;
            lsvResultadoOperacion.Location = new Point(3, 28);
            lsvResultadoOperacion.Name = "lsvResultadoOperacion";
            lsvResultadoOperacion.Size = new Size(535, 359);
            lsvResultadoOperacion.TabIndex = 2;
            lsvResultadoOperacion.UseCompatibleStateImageBehavior = false;
            lsvResultadoOperacion.View = View.Details;
            lsvResultadoOperacion.DrawColumnHeader += ListView_DrawColumnHeader;
            lsvResultadoOperacion.DrawItem += ListView_DrawItem;
            lsvResultadoOperacion.DrawSubItem += ListView_DrawSubItem;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRefrescar);
            groupBox1.Controls.Add(dateFechaFinal);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dateFechaInicio);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1094, 94);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtrar";
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Top;
            btnRefrescar.Image = Properties.Resources.icon_sincronizarguardar;
            btnRefrescar.Location = new Point(731, 30);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(96, 58);
            btnRefrescar.TabIndex = 12;
            btnRefrescar.UseVisualStyleBackColor = true;
            // 
            // dateFechaFinal
            // 
            dateFechaFinal.Anchor = AnchorStyles.Top;
            dateFechaFinal.Format = DateTimePickerFormat.Short;
            dateFechaFinal.Location = new Point(594, 44);
            dateFechaFinal.Name = "dateFechaFinal";
            dateFechaFinal.Size = new Size(131, 32);
            dateFechaFinal.TabIndex = 11;
            dateFechaFinal.ValueChanged += dateFechaFinal_ValueChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(560, 50);
            label4.Name = "label4";
            label4.Size = new Size(28, 25);
            label4.TabIndex = 10;
            label4.Text = "--";
            // 
            // dateFechaInicio
            // 
            dateFechaInicio.Anchor = AnchorStyles.Top;
            dateFechaInicio.Format = DateTimePickerFormat.Short;
            dateFechaInicio.Location = new Point(419, 44);
            dateFechaInicio.Name = "dateFechaInicio";
            dateFechaInicio.Size = new Size(135, 32);
            dateFechaInicio.TabIndex = 9;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(342, 44);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 8;
            label2.Text = "Desde:";
            // 
            // EstadoResultadoFinancieroForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(1100, 562);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F);
            Margin = new Padding(4);
            Name = "EstadoResultadoFinancieroForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estado resultado financiero";
            WindowState = FormWindowState.Maximized;
            Load += EstadoResultadoFinancieroForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox1;
        private Button btnRefrescar;
        private DateTimePicker dateFechaFinal;
        private Label label4;
        private DateTimePicker dateFechaInicio;
        private Label label2;
        private GroupBox groupBox2;
        private ListView lstCostosFijos;
        private GroupBox groupBox3;
        private ListView lsvResultadoOperacion;
    }
}
