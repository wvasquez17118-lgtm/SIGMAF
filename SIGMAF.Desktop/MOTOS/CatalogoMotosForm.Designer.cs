namespace SIGMAF.Desktop.MOTOS
{
    partial class CatalogoMotosForm
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
            panel3 = new Panel();
            lsvCatalogos = new ListView();
            panel2 = new Panel();
            label6 = new Label();
            txtDescripcion = new TextBox();
            panel5 = new Panel();
            cmbCategoriaProducto = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            panel4 = new Panel();
            btnNuevo = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            label1 = new Label();
            txtProducto = new TextBox();
            txtCodigo = new TextBox();
            btnBuscar = new Button();
            txtBusqueda = new TextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
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
            panel1.Size = new Size(1138, 50);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // lblTotalProducto
            // 
            lblTotalProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalProducto.AutoSize = true;
            lblTotalProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProducto.Location = new Point(1016, 15);
            lblTotalProducto.Name = "lblTotalProducto";
            lblTotalProducto.Size = new Size(61, 20);
            lblTotalProducto.TabIndex = 1;
            lblTotalProducto.Text = "Total: 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 15);
            label3.Name = "label3";
            label3.Size = new Size(244, 20);
            label3.TabIndex = 0;
            label3.Text = "Catalogos de productos de motos";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lsvCatalogos);
            panel3.Location = new Point(415, 50);
            panel3.Name = "panel3";
            panel3.Size = new Size(723, 693);
            panel3.TabIndex = 5;
            // 
            // lsvCatalogos
            // 
            lsvCatalogos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lsvCatalogos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lsvCatalogos.FullRowSelect = true;
            lsvCatalogos.GridLines = true;
            lsvCatalogos.Location = new Point(14, 13);
            lsvCatalogos.Name = "lsvCatalogos";
            lsvCatalogos.Size = new Size(695, 661);
            lsvCatalogos.TabIndex = 0;
            lsvCatalogos.UseCompatibleStateImageBehavior = false;
            lsvCatalogos.View = View.Details;
            lsvCatalogos.DoubleClick += lsvCatalogos_DoubleClick;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtDescripcion);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtProducto);
            panel2.Controls.Add(txtCodigo);
            panel2.Controls.Add(btnBuscar);
            panel2.Controls.Add(txtBusqueda);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(392, 693);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(19, 294);
            label6.Name = "label6";
            label6.Size = new Size(90, 20);
            label6.TabIndex = 17;
            label6.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Enabled = false;
            txtDescripcion.Location = new Point(20, 317);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(356, 45);
            txtDescripcion.TabIndex = 16;
            // 
            // panel5
            // 
            panel5.Controls.Add(cmbCategoriaProducto);
            panel5.Location = new Point(19, 124);
            panel5.Name = "panel5";
            panel5.Size = new Size(356, 42);
            panel5.TabIndex = 15;
            // 
            // cmbCategoriaProducto
            // 
            cmbCategoriaProducto.Dock = DockStyle.Fill;
            cmbCategoriaProducto.Enabled = false;
            cmbCategoriaProducto.FlatStyle = FlatStyle.Flat;
            cmbCategoriaProducto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCategoriaProducto.FormattingEnabled = true;
            cmbCategoriaProducto.IntegralHeight = false;
            cmbCategoriaProducto.Location = new Point(0, 0);
            cmbCategoriaProducto.Name = "cmbCategoriaProducto";
            cmbCategoriaProducto.Size = new Size(356, 29);
            cmbCategoriaProducto.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 97);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 14;
            label5.Text = "Categoria";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(19, 49);
            label4.Name = "label4";
            label4.Size = new Size(352, 45);
            label4.TabIndex = 12;
            label4.Text = "Detalles del producto";
            // 
            // panel4
            // 
            panel4.Controls.Add(btnNuevo);
            panel4.Controls.Add(btnEliminar);
            panel4.Controls.Add(btnGuardar);
            panel4.Controls.Add(btnEditar);
            panel4.Controls.Add(btnCancelar);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 483);
            panel4.Name = "panel4";
            panel4.Size = new Size(390, 208);
            panel4.TabIndex = 11;
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
            btnNuevo.Click += btnNuevo_Click;
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
            btnEditar.Click += btnEditar_Click;
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
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(19, 232);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 5;
            label2.Text = "Producto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 171);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 4;
            label1.Text = "Codigo";
            // 
            // txtProducto
            // 
            txtProducto.Enabled = false;
            txtProducto.Location = new Point(20, 256);
            txtProducto.Multiline = true;
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(356, 35);
            txtProducto.TabIndex = 3;
            // 
            // txtCodigo
            // 
            txtCodigo.Enabled = false;
            txtCodigo.Location = new Point(19, 193);
            txtCodigo.Multiline = true;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(356, 35);
            txtCodigo.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Image = Properties.Resources.icon_search;
            btnBuscar.Location = new Point(328, 11);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(47, 35);
            btnBuscar.TabIndex = 1;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(19, 11);
            txtBusqueda.Multiline = true;
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(303, 35);
            txtBusqueda.TabIndex = 0;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // CatalogoMotosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 232, 242);
            ClientSize = new Size(1138, 743);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CatalogoMotosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catalogos productos motos";
            WindowState = FormWindowState.Maximized;
            FormClosing += CatalogoMotosForm_FormClosing;
            Load += CatalogoMotosForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label3;
        private Panel panel3;
        private ListView lsvCatalogos;
        private Panel panel2;
        private Button btnBuscar;
        private TextBox txtBusqueda;
        private TextBox txtProducto;
        private TextBox txtCodigo;
        private Label label2;
        private Label label1;
        private Button btnNuevo;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnCancelar;
        private Panel panel4;
        private Label label4;
        private Label lblTotalProducto;
        private Label label5;
        private ComboBox cmbCategoriaProducto;
        private Panel panel5;
        private Label label6;
        private TextBox txtDescripcion;
    }
}