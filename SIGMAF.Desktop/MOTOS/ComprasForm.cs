using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Desktop.DB;
using SIGMAF.Domain.MOTOS;
using SIGMAF.Infrastructure;
using SIGMAF_LoadingDemo;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class ComprasForm : Form
    {
        private List<CatalogoModel> resultado = new List<CatalogoModel>();
        private List<ProveedorModel> ProveedoresLista = new List<ProveedorModel>();
        //  private BindingList<IngresoTallerDetalleDTO> Data = new BindingList<IngresoTallerDetalleDTO>();
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

                    cmbProveedor.DataSource = ProveedoresLista;
                    cmbProveedor.DisplayMember = "Nombre";
                    cmbProveedor.ValueMember = "ProveedorId";
                    cmbProveedor.SelectedIndex = -1;
                    cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;

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
            long idServicio = long.Parse(filaOrigen.Cells["IdCatalogo"].Value?.ToString() ?? "0");
            var nombreServicio = filaOrigen.Cells["Nombre"].Value?.ToString();

            //if (Data.Any(p => p.CatTrabajoRealizadoId == idServicio))
            //{
            //    MessageBox.Show("Este servicio ya fue agregado.", "Moto FIX LUZ");
            //    return;
            //}
            /* Data.Add(new IngresoTallerDetalleDTO()
             {
                 CatTrabajoRealizadoId = (long)idServicio,
                 TrabajoRealizado = nombreServicio ?? "",
                 StatusTrabajoRealizado = true,
                 IngresoTallerDetalleId = 0
             });*/
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
