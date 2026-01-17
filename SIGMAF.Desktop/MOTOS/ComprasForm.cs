using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Desktop.Constantes;
using SIGMAF.Desktop.DB;
using SIGMAF.Desktop.Helpers;
using SIGMAF.Domain.MOTOS;
using SIGMAF.Infrastructure;
using SIGMAF_LoadingDemo;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class ComprasForm : Form
    {
        private List<CatalogoModel> resultado = new List<CatalogoModel>();
        private List<ProveedorModel> ProveedoresLista = new List<ProveedorModel>();
        private BindingList<IngresoTallerDetalleDTO> Data = new BindingList<IngresoTallerDetalleDTO>();
        private BindingSource bsRealizados = new BindingSource();


        public long compraid = 0;
        public bool PermiteGuardar = true;
        public string Titulo = "";
        CompraServicio apiCompra = new CompraServicio();

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
        }

        private async void ComprasForm_Load(object sender, EventArgs e)
        {
            if (!PermiteGuardar)
            {
                btnGuardar.Enabled = false;
            }
            lblTituloCompra.Text = string.IsNullOrEmpty(Titulo) ? "Crear nueva factura detalles de compras" : Titulo; 
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
                    ConfigurarFormatoGrid();
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

                    if (compraid > 0)
                    {
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        parameters.Add("id",compraid.ToString());
                        var resultadoDetalle = await apiCompra.ObtenerCompraMaestroDetallePorIdAsync(parameters);

                        if (resultadoDetalle != null)
                        {
                            txtDescuento.Text = NumberHelper.ToDecimal(resultadoDetalle.Compra.Descuento).ToString().Replace(".00", "");
                            txtSubTotal.Text = NumberHelper.ToDecimal(resultadoDetalle.Compra.SubTotal).ToString().Replace(".00", "");
                            txtTotal.Text = NumberHelper.ToDecimal(resultadoDetalle.Compra.Total).ToString().Replace(".00","");

                            cmbTipoFactura.SelectedValue = resultadoDetalle.Compra.TipoFactura;
                            cmbProveedor.SelectedValue = resultadoDetalle.Compra.ProveedorId;

                            var detalle = (from resul in resultadoDetalle.Detalle.ToList()
                             join prod in resultado on resul.CatalogoId equals prod.IdCatalogo
                             select new IngresoTallerDetalleDTO
                             {
                                 CompraDetalleId = NumberHelper.ToLong(resul.CompraDetalleId),
                                 CompraId = NumberHelper.ToLong(resul.CompraId),
                                 CatalogoId = int.Parse(resul.CatalogoId),
                                 Producto = prod.Nombre,
                                 Descripcion = resul.Descripcion??"",
                                 Cantidad = int.Parse(resul.Cantidad.Replace(".00","")),
                                 PrecioCompra = NumberHelper.ToDecimal(resul.PrecioCompra),
                                 PrecioVenta = NumberHelper.ToDecimal(resul.PrecioVenta),
                                 Total = NumberHelper.ToDecimal(resul.PrecioCompra) * int.Parse(resul.Cantidad.Replace(".00", "0")),
                             }).ToList();

                            foreach (var x in detalle) Data.Add(x);
                            CargarCompra();
                        }
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
        private void CargarCompra()
        {
            // ...cargar filas en dataGridProductosComprados...

            // Aplico formato por si las columnas se recrearon
            ConfigurarFormatoGrid();

            // Recalculo totales para asegurar coherencia
            for (int i = 0; i < dataGridProductosComprados.Rows.Count; i++)
            {
                if (!dataGridProductosComprados.Rows[i].IsNewRow)
                    RecalcularFila(i);
            }

            RecalcularTotales();
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


            var colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Total";
            colTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTotal.FillWeight = 120;
            colTotal.ReadOnly = true;
            colTotal.DefaultCellStyle.Format = "N2";
            dataGridProductosComprados.Columns.Add(colTotal);


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

            HookEventosGrid();
        }

        private void HookEventosGrid()
        {
            dataGridProductosComprados.CellEndEdit += Grid_CellEndEdit;
            dataGridProductosComprados.RowsRemoved += (s, e) => RecalcularTotales();
            dataGridProductosComprados.RowsAdded += (s, e) => RecalcularTotales();

            // Evita errores cuando el usuario escribe letras donde va número
            dataGridProductosComprados.DataError += (s, e) => { e.ThrowException = false; };
        }
        private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridProductosComprados.Columns[e.ColumnIndex].Name;

            if (colName == "Cantidad" || colName == "PrecioCompra" || colName == "PrecioVenta")
            {
                RecalcularFila(e.RowIndex);
                RecalcularTotales();
            }
        }

        private void RecalcularFila(int rowIndex)
        {
            var row = dataGridProductosComprados.Rows[rowIndex];
            if (row.IsNewRow) return;

            int cantidad = GetInt(row, "Cantidad");
            decimal precioCompra = GetDecimal(row, "PrecioCompra");
            decimal precioVenta = GetDecimal(row, "PrecioVenta");

            // ✅ Decide cuál total quieres:
            // TotalCosto = cantidad * precioCompra (lo típico en compras)

            // Si quieres total a precio venta, usa:
            // decimal totalFila = cantidad * precioVenta;

            row.Cells["Total"].Value = cantidad * precioCompra;
        }
        private void RecalcularTotales()
        {
            int totalProductos = 0;
            decimal sumaTotalPrecio = 0m;

            foreach (DataGridViewRow row in dataGridProductosComprados.Rows)
            {
                if (row.IsNewRow) continue;

                int cantidad = GetInt(row, "Cantidad");
                decimal totalFila = GetDecimal(row, "Total"); // ya calculado

                totalProductos += cantidad;
                sumaTotalPrecio += totalFila;
            }

            // ✅ Cambia estos nombres por los tuyos:
            lblTotalProductos.Text = totalProductos.ToString();

            lblSumaTotalPrecio.Text = $"C$ {sumaTotalPrecio:N2}";
        }

        private int GetInt(DataGridViewRow row, string colName)
        {
            var txt = row.Cells[colName].Value?.ToString();
            return int.TryParse(txt, NumberStyles.Any, CultureInfo.CurrentCulture, out int v) ? v : 0;
        }

        private decimal GetDecimal(DataGridViewRow row, string colName)
        {
            var txt = row.Cells[colName].Value?.ToString();
            return decimal.TryParse(txt, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal v) ? v : 0m;
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
        private void ConfigurarFormatoGrid()
        {
            // Cantidad: entero sin decimales
            var colCant = dataGridProductosComprados.Columns["Cantidad"];
            if (colCant != null)
            {
                colCant.DefaultCellStyle.Format = "N0"; // 1,000
                colCant.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // PrecioCompra: 2 decimales con separador de miles
            var colPrecioCompra = dataGridProductosComprados.Columns["PrecioCompra"];
            if (colPrecioCompra != null)
            {
                colPrecioCompra.DefaultCellStyle.Format = "N2"; // 1,000.00
                colPrecioCompra.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // PrecioVenta
            var colPrecioVenta = dataGridProductosComprados.Columns["PrecioVenta"];
            if (colPrecioVenta != null)
            {
                colPrecioVenta.DefaultCellStyle.Format = "N2";
                colPrecioVenta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Total
            var colTotal = dataGridProductosComprados.Columns["Total"];
            if (colTotal != null)
            {
                colTotal.DefaultCellStyle.Format = "N2";
                colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var detalles = new List<IngresoTallerDetalleDTO>();
            if (cmbProveedor.SelectedValue?.ToString() == "")
            {
                MessageBox.Show("Seleccionar el proveedor es requerido.", "Advertencia");
                cmbProveedor.Focus();
                return;
            }
            else if (cmbTipoFactura.SelectedValue?.ToString() == "")
            {
                MessageBox.Show("Seleccionar el tipo factura es requerido.", "Advertencia");
                cmbTipoFactura.Focus();
                return;
            }
            else if (txtSubTotal.Text == "")
            {
                MessageBox.Show("Debe ingresar subtotal es requerido.", "Advertencia");
                txtSubTotal.Focus();
                return;
            }
            else if (txtDescuento.Text == "")
            {
                MessageBox.Show("Debe ingresar descuento es requerido.", "Advertencia");
                txtDescuento.Focus();
                return;
            }
            else if (txtTotal.Text == "")
            {
                MessageBox.Show("Debe ingresar total es requerido.", "Advertencia");
                txtTotal.Focus();
                return;
            }
            else if (!TryGetDetallesFromGrid(out detalles))
                return;


            DialogResult r = MessageBox.Show(ConstantesMensajes.MensajeConfirmacionGuardar, ConstantesMensajes.MensajeTituloConfirmacionGuardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        var compra = new MotoComprasDTO()
                        {
                            CompraId = compraid,
                            Fecha = dateFechaCompra.Value,
                            TipoFactura = cmbTipoFactura.SelectedValue?.ToString() ?? "CO",
                            ProveedorId = int.Parse(cmbProveedor?.SelectedValue?.ToString() ?? "0"),
                            SubTotal = decimal.Parse(txtSubTotal.Text),
                            Descuento = decimal.Parse(txtDescuento.Text),
                            Total = decimal.Parse(txtTotal.Text),
                            Observacion = "",
                            Estado = 1
                        };
                        Dictionary<string, string> parameters = new Dictionary<string, string>();

                        var options = new JsonSerializerOptions
                        {
                            WriteIndented = true,
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase // id, name, isActive
                        };

                        parameters.Add("Compra", JsonSerializer.Serialize(compra, options));
                        parameters.Add("Detalle", JsonSerializer.Serialize(detalles, options));
                        var resultado = await apiCompra.GuardarCompraRepuestoAsync(parameters);
                        if (resultado.Estado)
                        {
                            MessageBox.Show(ConstantesMensajes.MensajeTituloGuardadoCorrectamente, "ADMINISTRACIÓN");                            
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show(resultado.Mensaje, "ADMINISTRACIÓN");
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


        private bool TryGetDetallesFromGrid(out List<IngresoTallerDetalleDTO> detalles)
        {
            detalles = new List<IngresoTallerDetalleDTO>();

            // Si el usuario está editando una celda, fuerza a que termine la edición
            dataGridProductosComprados.EndEdit();

            foreach (DataGridViewRow row in dataGridProductosComprados.Rows)
            {
                if (row.IsNewRow) continue;

                // Si tienes filas "vacías" por alguna razón, puedes saltarlas así:
                // if (row.Cells["CatalogoId"].Value == null) continue;

                int cantidad = GetInt(row, "Cantidad");
                decimal precioCompra = GetDecimal(row, "PrecioCompra");
                decimal precioVenta = GetDecimal(row, "PrecioVenta");
                decimal total = GetDecimal(row, "Total");

                // ✅ Validaciones de no-cero
                if (cantidad <= 0 || precioCompra <= 0 || precioVenta <= 0 || total <= 0)
                {
                    string producto = row.Cells["Producto"].Value?.ToString() ?? "(sin nombre)";
                    MessageBox.Show(
                        $"Revisa el producto: {producto}\n" +
                        $"No se permite Cantidad / PrecioCompra / PrecioVenta / Total en 0.\n\n" +
                        $"Cantidad: {cantidad}\nPrecio Compra: {precioCompra}\nPrecio Venta: {precioVenta}\nTotal: {total}",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    // Opcional: enfocar la fila con problema
                    dataGridProductosComprados.ClearSelection();
                    row.Selected = true;
                    dataGridProductosComprados.CurrentCell = row.Cells["Cantidad"];
                    dataGridProductosComprados.FirstDisplayedScrollingRowIndex = row.Index;

                    return false;
                }

                // ✅ Armar objeto
                var item = new IngresoTallerDetalleDTO
                {
                    CompraDetalleId = GetInt(row, "CompraDetalleId"),
                    CompraId = GetInt(row, "CompraId"),
                    CatalogoId = GetInt(row, "CatalogoId"),
                    Producto = row.Cells["Producto"].Value?.ToString() ?? "",
                    Cantidad = cantidad,
                    PrecioCompra = precioCompra,
                    PrecioVenta = precioVenta,
                    Total = total
                };

                detalles.Add(item);
            }

            // Validación extra: al menos 1 detalle
            if (detalles.Count == 0)
            {
                MessageBox.Show("Debes agregar al menos un producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void dataGridProductosComprados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridProductosComprados.Columns[e.ColumnIndex].Name != "Eliminar") return;

            dataGridProductosComprados.EndEdit();
            dataGridProductosComprados.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (MessageBox.Show("¿Seguro desea eliminar el registro?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            bsRealizados.RemoveAt(e.RowIndex);
            RecalcularTotales();
        }

        private void txtSubTotal_KeyPress(object sender, KeyPressEventArgs e)
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
    }

    public class ComboItem
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
