using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Desktop.DB;
using SIGMAF.Domain.MOTOS;
using SIGMAF.Infrastructure;
using SIGMAF_LoadingDemo;
using System.ComponentModel;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class ComprasForm : Form
    {
        private List<CatalogoModel> resultado = new List<CatalogoModel>();
        private List<ProveedorModel> ProveedoresLista = new List<ProveedorModel>();
        private BindingList<IngresoTallerDetalleDTO> Data = new BindingList<IngresoTallerDetalleDTO>();
        private BindingSource bsRealizados = new BindingSource();

        CatalogoService api = new CatalogoService();
        public ComprasForm()
        {
            InitializeComponent();
        }

        private void ComprasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormularioAbierto = false;
        }

        private void CargarGridDetalle()
        {
            Data.Clear();
            bsRealizados.DataSource = Data;
            dataGridProductosComprados.DataSource = bsRealizados;
            //var dataResultadoGuardado = 
            //foreach (var x in dataResultadoGuardado) Data.Add(x);
        }

        private async void ComprasForm_Load(object sender, EventArgs e)
        {
            // Fuerza un cambio de tamaño para que se reajusten los controles

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
                    ConfigurarGridProductoComprados();
                    CargarGridDetalle();

                    resultado = AppServices.Catalogos.ListarTodos();
                    if (!resultado.Any())
                    {
                        resultado = await api.ObtenerCatalogoAsync();
                    }

                    ProveedoresLista = AppServices.Proveedores.ListarTodos();

                    if (!ProveedoresLista.Any())
                    {
                        ProveedoresLista = await api.ObtenerProveedoresAsync();
                    }
                    dataGridProductosCatalogos.DataSource = resultado;

                    var tiposFactura = new List<ComboItem>
                    {
                        new ComboItem { Id = "CR",  Value = "Crédito" },
                        new ComboItem { Id = "CO",  Value = "Contado" },
                        new ComboItem { Id = "FIA", Value = "Fiado" }
                    };

                    cmbProveedor.DataSource = ProveedoresLista;
                    cmbProveedor.DisplayMember = "Nombre";
                    cmbProveedor.ValueMember = "ProveedorId";
                    cmbProveedor.SelectedIndex = -1;
                    cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;


                    cmbTipoFactura.DataSource = tiposFactura;
                    cmbTipoFactura.DisplayMember = "Value"; // lo que se ve
                    cmbTipoFactura.ValueMember = "Id";

                    cmbTipoFactura.SelectedIndex = -1;
                    cmbTipoFactura.DropDownStyle = ComboBoxStyle.DropDownList;

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
                Name = "Nombre",
                HeaderText = "Producto",
                DataPropertyName = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            // Descripción (se expande)
            var colDescripcion = new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                HeaderText = "Descripcion",
                DataPropertyName = "Descripcion",
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

            dataGridProductosCatalogos.Columns.AddRange(colId, colNombre, colDescripcion, colAgregar);
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


        private void ConfigurarGridProductoComprados()
        { 
            dataGridProductosComprados.AutoGenerateColumns = false;
            dataGridProductosComprados.AllowUserToAddRows = false;
            dataGridProductosComprados.AllowUserToDeleteRows = false;
            dataGridProductosComprados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProductosComprados.MultiSelect = false;


            var colIdDetalle = new DataGridViewTextBoxColumn();
            colIdDetalle.Name = "CompraDetalleId";
            colIdDetalle.HeaderText = "CompraDetalleId";
            colIdDetalle.DataPropertyName = "CompraDetalleId";
            colIdDetalle.Visible = false;
            dataGridProductosComprados.Columns.Add(colIdDetalle);
                      
            var colId = new DataGridViewTextBoxColumn();
            colId.Name = "CompraId";
            colId.HeaderText = "CompraId";
            colId.DataPropertyName = "CompraId";
            colId.Visible = false;
            dataGridProductosComprados.Columns.Add(colId);

 
            var colCatalogoId = new DataGridViewTextBoxColumn();
            colCatalogoId.Name = "CatalogoId";
            colCatalogoId.HeaderText = "CatalogoId";
            colCatalogoId.DataPropertyName = "CatalogoId";
            colCatalogoId.Visible = false;
            dataGridProductosComprados.Columns.Add(colCatalogoId);


            var colProducto = new DataGridViewTextBoxColumn();
            colProducto.Name = "Producto";
            colProducto.HeaderText = "Producto";
            colProducto.DataPropertyName = "Producto";
            colProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProducto.FillWeight = 500;
            colProducto.ReadOnly = true;
            dataGridProductosComprados.Columns.Add(colProducto);

            var colCantidad = new DataGridViewTextBoxColumn();
            colCantidad.Name = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCantidad.FillWeight = 100;
            colCantidad.ReadOnly = false;      // 👈 sí se edita
            dataGridProductosComprados.Columns.Add(colCantidad);

          
            var colPrecioCompra = new DataGridViewTextBoxColumn();
            colPrecioCompra.Name = "PrecioCompra";
            colPrecioCompra.HeaderText = "Precio Compra";
            colPrecioCompra.DataPropertyName = "PrecioCompra";
            colPrecioCompra.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrecioCompra.FillWeight = 100;
            colPrecioCompra.ReadOnly = false;      // 👈 sí se edita
            dataGridProductosComprados.Columns.Add(colPrecioCompra);

            var colPrecioVenta = new DataGridViewTextBoxColumn();
            colPrecioVenta.Name = "PrecioVenta";
            colPrecioVenta.HeaderText = "Precio Venta";
            colPrecioVenta.DataPropertyName = "PrecioVenta";
            colPrecioVenta.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrecioVenta.FillWeight = 100;
            colPrecioCompra.ReadOnly = false;      // 👈 sí se edita
            dataGridProductosComprados.Columns.Add(colPrecioVenta);

            // --- Columna 4: Icono eliminar ---
            var colEliminar = new DataGridViewImageColumn();
            colEliminar.Name = "Eliminar";
            colEliminar.HeaderText = "";
            colEliminar.Width = 40;
            colEliminar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colEliminar.Image = Properties.Resources.icon_delete; // agrega tu PNG a Recursos
            dataGridProductosComprados.Columns.Add(colEliminar);

            // Grid en general: se permite editar, pero solo en las columnas que NO son ReadOnly
            dataGridProductosComprados.ReadOnly = false;

            // Por si acaso, fuerza que solo Descripcion y Aplicar sean editables
            foreach (DataGridViewColumn col in dataGridProductosComprados.Columns)
                col.ReadOnly = true;

            dataGridProductosComprados.Columns["Cantidad"].ReadOnly = false;
            dataGridProductosComprados.Columns["PrecioCompra"].ReadOnly = false;
            dataGridProductosComprados.Columns["PrecioVenta"].ReadOnly = false;

            dataGridProductosComprados.EnableHeadersVisualStyles = false; // importante
            dataGridProductosComprados.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridProductosComprados.Font, FontStyle.Bold);
        }

        private void txtFiltrarProductos_TextChanged(object sender, EventArgs e)
        {
            if (resultado.Any())
            {
                if (txtFiltrarProductos.Text.Length == 0)
                {
                    dataGridProductosCatalogos.DataSource = resultado;
                }
                else
                {
                    string texto = txtFiltrarProductos.Text.Trim().ToLower();
                    dataGridProductosCatalogos.DataSource = resultado.Where(p => p.Nombre.Trim().ToLower().Contains(texto)).ToList();
                }
            }

        }

        private void dataGridProductosCatalogos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Solo reaccionar si se hizo click en la columna Agregar
            if (dataGridProductosCatalogos.Columns[e.ColumnIndex].Name != "Agregar")
                return;

            DataGridViewRow filaOrigen = dataGridProductosCatalogos.Rows[e.RowIndex];

            // Tomamos el Id y el nombre del servicio (ajusta los nombres de columnas si son otros)
            int catalogoId = int.Parse(filaOrigen.Cells["IdCatalogo"].Value?.ToString() ?? "0");
            var nombreServicio = filaOrigen.Cells["Nombre"].Value?.ToString();

            if (Data.Any(p => p.CatalogoId == catalogoId))
            {
                MessageBox.Show("Este producto ya fue agregado.", "Advertencia");
                return;
            }
            Data.Add(new IngresoTallerDetalleDTO()
            {
                CatalogoId = catalogoId,
                Producto = nombreServicio ?? "",
                PrecioCompra = 0,
                PrecioVenta = 0,
            });
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }

    public class ComboItem
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
