using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Desktop.Constantes;
using SIGMAF.Desktop.DB;
using SIGMAF.Domain.MOTOS;
using SIGMAF.Infrastructure;
using SIGMAF_LoadingDemo;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class RegistrarVentaForm : Form 
    {
        private List<CatalogoConInventarioModel> resultado = new List<CatalogoConInventarioModel>();
        CatalogoService apiConInventario = new CatalogoService();
        int catalogoId = 0;
        decimal preciocompraproductoFactura = 0;
        public RegistrarVentaForm()
        {
            InitializeComponent();
        }
  
        private void RegistrarVentaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormularioAbierto = false;
        }

        private async void RegistrarVentaForm_Load(object sender, EventArgs e)
        {
            catalogoId = 0;
            preciocompraproductoFactura = 0;
            // Fuerza un cambio de tamaño para que se reajusten los controles
            lblFechaTitulo.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            SqliteDatabase.Initialize(AppServices.ConnectionString);
            CatalogoService api = new CatalogoService();

            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
            using (var loading = new FrmLoading())
            {
                loading.StartPosition = FormStartPosition.CenterScreen;
                loading.TopMost = true;

                this.Enabled = false;
                this.UseWaitCursor = true;
                loading.UseWaitCursor = true;

                loading.Show(this);

                try
                {
                    ConfiguracionGridProductos();

                    resultado = AppServices.CatalogoConInventario.ListarTodos();
                    if (!resultado.Any())
                    {
                        resultado = await apiConInventario.ObtenerCatalogosConInventarioMotoAsync();
                    }


                    dataGridProductosCatalogos.DataSource = resultado;

                    var tiposFactura = new List<ComboItem>
                    {
                        new ComboItem { Id = "CR",  Value = "Crédito" },
                        new ComboItem { Id = "CO",  Value = "Contado" },
                        new ComboItem { Id = "FIA", Value = "Fiado" }
                    };



                }
                finally
                {
                    loading.Close();
                    this.Enabled = true;
                    this.UseWaitCursor = false;
                }
            }
        }


        private void ConfiguracionGridProductos()
        {
            dataGridProductosCatalogos.AutoGenerateColumns = false;
            dataGridProductosCatalogos.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn
            {
                Name = "CatalogoId",
                DataPropertyName = "CatalogoId",
                Visible = false
            };

            // Trabajo
            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "NombreProducto",
                HeaderText = "Producto",
                DataPropertyName = "NombreProducto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            // Descripción (se expande)
            var colDescripcion = new DataGridViewTextBoxColumn
            {
                Name = "DescripcionProducto",
                HeaderText = "Descripcion",
                DataPropertyName = "DescripcionProducto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };


            // Precio Venta (se expande)
            var colPrecioVenta = new DataGridViewTextBoxColumn
            {
                Name = "PrecioVenta",
                HeaderText = "Precio venta",
                DataPropertyName = "PrecioVenta",
                Width = 150
            };

            // Stock Minimo (se expande)
            var colStockMinimo = new DataGridViewTextBoxColumn
            {
                Name = "StockMinimo",
                HeaderText = "Sock Minimo",
                DataPropertyName = "StockMinimo",
                Width = 150
            };

            // Stock Disponible (se expande)
            var colStockDisponible = new DataGridViewTextBoxColumn
            {
                Name = "StockDisponible",
                HeaderText = "Disponible",
                DataPropertyName = "StockDisponible",
                Width = 150
            };

            // Precio compra facturado
            var colPrecioCompraFacturado = new DataGridViewTextBoxColumn
            {
                Name = "PrecioCompra",
                HeaderText = "Precio compra",
                DataPropertyName = "PrecioCompra",
                Width = 150,
                Visible= true,
            };

            // Botón Agregar
            var colAgregar = new DataGridViewButtonColumn
            {
                Name = "Agregar",
                HeaderText = "",
                Text = "+ Agregar",                       // mostramos el + como texto
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            // Colores del botón
            colAgregar.FlatStyle = FlatStyle.Flat;
            colAgregar.DefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80);       // Verde (#4CAF50)
            colAgregar.DefaultCellStyle.ForeColor = Color.White;                       // Texto blanco
            colAgregar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(56, 142, 60); // Verde más oscuro al seleccionar
            colAgregar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridProductosCatalogos.Columns.AddRange(colId, colNombre, colDescripcion, colPrecioVenta, colStockMinimo, colStockDisponible, colPrecioCompraFacturado, colAgregar);
            //dataGridProductosCatalogos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            // Trabajo y Descripción se estiran
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Mitad y mitad (50 / 50)
            colNombre.FillWeight = 50;
            colDescripcion.FillWeight = 50;

            // Agregar: ancho fijo, sin estirarse
            colAgregar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colAgregar.Width = 90;   // o el que estés usando

            dataGridProductosCatalogos.ReadOnly = true;
            dataGridProductosCatalogos.EditMode = DataGridViewEditMode.EditProgrammatically;

            // 👉 Que siempre seleccione la fila completa
            dataGridProductosCatalogos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // (opcional) Solo una fila a la vez
            dataGridProductosCatalogos.MultiSelect = false;

            // (opcional) que no puedan agregar/eliminar filas desde el grid
            dataGridProductosCatalogos.AllowUserToAddRows = false;
            dataGridProductosCatalogos.AllowUserToDeleteRows = false;

            dataGridProductosCatalogos.EnableHeadersVisualStyles = false; // importante
            dataGridProductosCatalogos.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridProductosCatalogos.Font, FontStyle.Bold);
        }

        private void dataGridProductosCatalogos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Solo reaccionar si se hizo click en la columna Agregar
            if (dataGridProductosCatalogos.Columns[e.ColumnIndex].Name != "Agregar")
                return;

            DataGridViewRow filaOrigen = dataGridProductosCatalogos.Rows[e.RowIndex];

            // Tomamos el Id y el nombre del servicio (ajusta los nombres de columnas si son otros)
            catalogoId = int.Parse(filaOrigen.Cells["CatalogoId"].Value?.ToString() ?? "0");
            preciocompraproductoFactura = decimal.Parse(filaOrigen.Cells["PrecioCompra"].Value?.ToString() ?? "0");
            var nombreServicio = filaOrigen.Cells["NombreProducto"].Value?.ToString();
            string PrecioVenta = filaOrigen.Cells["PrecioVenta"].Value?.ToString() ?? "";
            string StockDisponible = filaOrigen.Cells["StockDisponible"].Value?.ToString() ?? "";

            txtDisponible.Text = StockDisponible;
            txtNombreProducto.Text = nombreServicio;
            txtPrecio.Text = PrecioVenta;

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (catalogoId == 0)
            {
                MessageBox.Show("Debe seleccionar un producto es requerido", "Advertencia");
                return;
            }
            else if (string.IsNullOrEmpty(txtCantidadAVender?.Text))
            {
                MessageBox.Show("Debe ingresar una cantidad a vender es requerido", "Advertencia");
                txtCantidadAVender?.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtTotal?.Text))
            {
                MessageBox.Show("Debe ingresar un total a vender es requerido", "Advertencia");
                txtTotal?.Focus();
                return;
            }


            DialogResult r = MessageBox.Show(ConstantesMensajes.MensajeConfirmacionGuardar + " \n \n \n Producto = " + txtNombreProducto.Text, ConstantesMensajes.MensajeTituloConfirmacionGuardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {

                using (var loading = new FrmLoading())
                {
                    loading.StartPosition = FormStartPosition.CenterScreen;
                    loading.TopMost = true;

                    this.Enabled = false;
                    this.UseWaitCursor = true;
                    loading.UseWaitCursor = true;

                    loading.Show(this);

                    try
                    {
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        parameters.Add("IdVenta", "0");
                        parameters.Add("NombreProducto", txtNombreProducto.Text ?? "");
                        parameters.Add("Cantidad", txtCantidadAVender.Text ?? "0");
                        parameters.Add("Precio", txtPrecio.Text ?? "0");
                        parameters.Add("Total", txtTotal.Text ?? "0");
                        parameters.Add("IdUsuario", "6");
                        parameters.Add("Descripcion", "");
                        parameters.Add("DescripcionEliminado", "");
                        parameters.Add("Accion", "NUEVO");
                        parameters.Add("IdCatalogoProducto", catalogoId.ToString());
                        parameters.Add("Sucursal", "WAMA");
                        parameters.Add("PrecioCompra", preciocompraproductoFactura.ToString());

                        CompraServicio compraServicio = new CompraServicio();
                        var resultado = await compraServicio.GuardarVentaRepuestoAsync(parameters);
                        if (resultado.Estado)
                        {
                            MessageBox.Show(ConstantesMensajes.MensajeTituloGuardadoCorrectamente, "WAMA");
                            catalogoId = 0;
                            preciocompraproductoFactura = 0;
                            txtPrecio.Clear();
                            txtTotal.Clear();
                            txtCantidadAVender.Clear();
                            txtDisponible.Clear();
                            txtNombreProducto.Clear();
                            dataGridProductosCatalogos.ClearSelection();
                            dataGridProductosCatalogos.CurrentCell = null;
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show(resultado.Mensaje, "WAMA");
                        }
                    }
                    finally
                    {
                        loading.Close();
                        this.Enabled = true;
                        this.UseWaitCursor = false;
                    }
                }
            }
        }

        private void txtCantidadAVender_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite control (Backspace, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Permite dígitos 0-9
            if (char.IsDigit(e.KeyChar))
                return;

            // (Opcional) Permitir signo negativo solo al inicio y solo una vez
            if (e.KeyChar == '-' && ((TextBox)sender).SelectionStart == 0 && !((TextBox)sender).Text.Contains("-"))
                return;

            // Bloquea todo lo demás
            e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (resultado.Any())
            {
                if (textBox1.Text.Length == 0)
                {
                    dataGridProductosCatalogos.DataSource = resultado;
                }
                else
                {
                    string texto = textBox1.Text.Trim().ToLower();
                    dataGridProductosCatalogos.DataSource = resultado.Where(p => p.NombreProducto.Trim().ToLower().Contains(texto)).ToList();
                }
            }
        }       
    }
}
