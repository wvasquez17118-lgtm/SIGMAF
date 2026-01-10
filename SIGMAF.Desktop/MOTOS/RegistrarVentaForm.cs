using SIGMAF.ApiClient.ApiRestMoto;
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
                Name = "IdCatalogo",
                DataPropertyName = "IdCatalogo",
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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            // Stock Minimo (se expande)
            var colStockMinimo= new DataGridViewTextBoxColumn
            {
                Name = "StockMinimo",
                HeaderText = "Sock Minimo",
                DataPropertyName = "StockMinimo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            // Stock Disponible (se expande)
            var colStockDisponible = new DataGridViewTextBoxColumn
            {
                Name = "StockDisponible",
                HeaderText = "Disponible",
                DataPropertyName = "StockDisponible",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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

            dataGridProductosCatalogos.Columns.AddRange(colId, colNombre, colPrecioVenta, colStockMinimo, colStockDisponible, colDescripcion, colAgregar);
            dataGridProductosCatalogos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



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
    }
}
