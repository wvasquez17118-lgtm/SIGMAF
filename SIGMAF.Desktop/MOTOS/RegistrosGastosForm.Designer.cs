namespace SIGMAF.Desktop.MOTOS
{
    partial class RegistrosGastosForm
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
            groupBox1 = new GroupBox();
            chEsCostoFijo = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            txtCosto = new TextBox();
            txtDescripcion = new TextBox();
            panel4 = new Panel();
            btnNuevo = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnCancelar = new Button();
            lstGastos = new ListView();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel4.SuspendLayout();
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
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(317, 25);
            label1.TabIndex = 0;
            label1.Text = "Registros de gastos fijos o variantes";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(lstGastos, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 60);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1100, 502);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chEsCostoFijo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCosto);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(panel4);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(394, 496);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // chEsCostoFijo
            // 
            chEsCostoFijo.AutoSize = true;
            chEsCostoFijo.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chEsCostoFijo.Location = new Point(10, 190);
            chEsCostoFijo.Name = "chEsCostoFijo";
            chEsCostoFijo.Size = new Size(144, 29);
            chEsCostoFijo.TabIndex = 17;
            chEsCostoFijo.Text = "Es costo fijo?";
            chEsCostoFijo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 109);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 16;
            label2.Text = "Costo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 28);
            label3.Name = "label3";
            label3.Size = new Size(116, 25);
            label3.TabIndex = 15;
            label3.Text = "Descripcion";
            // 
            // txtCosto
            // 
            txtCosto.Enabled = false;
            txtCosto.Location = new Point(10, 137);
            txtCosto.Multiline = true;
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(356, 35);
            txtCosto.TabIndex = 14;
            txtCosto.TextChanged += txtProducto_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Enabled = false;
            txtDescripcion.Location = new Point(10, 56);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(356, 35);
            txtDescripcion.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnNuevo);
            panel4.Controls.Add(btnEliminar);
            panel4.Controls.Add(btnGuardar);
            panel4.Controls.Add(btnEditar);
            panel4.Controls.Add(btnCancelar);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(3, 285);
            panel4.Name = "panel4";
            panel4.Size = new Size(388, 208);
            panel4.TabIndex = 12;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = SystemColors.ControlText;
            btnNuevo.Image = Properties.Resources.icon_new;
            btnNuevo.ImageAlign = ContentAlignment.TopCenter;
            btnNuevo.Location = new Point(19, 21);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(156, 55);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "NUEVO";
            btnNuevo.TextAlign = ContentAlignment.BottomCenter;
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Image = Properties.Resources.icon_delete;
            btnEliminar.ImageAlign = ContentAlignment.TopCenter;
            btnEliminar.Location = new Point(125, 143);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(156, 55);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.TextAlign = ContentAlignment.BottomCenter;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Enabled = false;
            btnGuardar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Image = Properties.Resources.icon_save;
            btnGuardar.ImageAlign = ContentAlignment.TopCenter;
            btnGuardar.Location = new Point(219, 82);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(156, 55);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.TextAlign = ContentAlignment.BottomCenter;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Enabled = false;
            btnEditar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.Image = Properties.Resources.icon_edit;
            btnEditar.ImageAlign = ContentAlignment.TopCenter;
            btnEditar.Location = new Point(219, 21);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(156, 55);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "EDITAR";
            btnEditar.TextAlign = ContentAlignment.BottomCenter;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Enabled = false;
            btnCancelar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Image = Properties.Resources.icon_cancel;
            btnCancelar.ImageAlign = ContentAlignment.TopCenter;
            btnCancelar.Location = new Point(19, 82);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(156, 55);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.TextAlign = ContentAlignment.BottomCenter;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // lstGastos
            // 
            lstGastos.Dock = DockStyle.Fill;
            lstGastos.FullRowSelect = true;
            lstGastos.GridLines = true;
            lstGastos.Location = new Point(403, 3);
            lstGastos.Name = "lstGastos";
            lstGastos.Size = new Size(694, 496);
            lstGastos.TabIndex = 1;
            lstGastos.UseCompatibleStateImageBehavior = false;
            lstGastos.View = View.Details;
            // 
            // RegistrosGastosForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(1100, 562);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F);
            Margin = new Padding(4);
            Name = "RegistrosGastosForm";
            Text = "Registros de gastos fijos o bariantes";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private ListView lstGastos;
        private Panel panel4;
        private Button btnNuevo;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnCancelar;
        private Label label2;
        private Label label3;
        private TextBox txtCosto;
        private TextBox txtDescripcion;
        private CheckBox chEsCostoFijo;
    }
}