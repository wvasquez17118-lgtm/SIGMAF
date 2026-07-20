using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Desktop.Helpers;
using SIGMAF.Domain.MOTOS;
using System.Globalization;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class EstadoResultadoFinancieroForm : Form
    {
        private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("es-NI");

        public EstadoResultadoFinancieroForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void EstadoResultadoFinancieroForm_Load(object sender, EventArgs e)
        {
            lstCostosFijos.Columns.Clear();
            lstCostosFijos.View = View.Details;
            lstCostosFijos.FullRowSelect = true;
            lstCostosFijos.OwnerDraw = true;
            lstCostosFijos.Columns.Add("COSTO", 350);
            lstCostosFijos.Columns.Add("VALOR", 200);

            lvsCostosVariable.Columns.Clear();
            lvsCostosVariable.View = View.Details;
            lvsCostosVariable.FullRowSelect = true;
            lvsCostosVariable.OwnerDraw = true;
            lvsCostosVariable.Columns.Add("COSTO", 350);
            lvsCostosVariable.Columns.Add("VALOR", 200);

            lsvResultadoOperacion.Columns.Clear();
            lsvResultadoOperacion.View = View.Details;
            lsvResultadoOperacion.FullRowSelect = true;
            lsvResultadoOperacion.OwnerDraw = true;
            lsvResultadoOperacion.Columns.Add("OPERACION", 350);
            lsvResultadoOperacion.Columns.Add("RESULTADO", 200);

            await CargarDatosAsync();
        }

        private void dateFechaFinal_ValueChanged(object sender, EventArgs e)
        {

        }

        private async Task CargarDatosAsync()
        {
            using (var loading = LoadingHelper.Mostrar(this))
            {
                try
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>
                    {
                        { "FechaInicio", dateFechaInicio.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) },
                        { "FechaFin", dateFechaFinal.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) }
                    };

                    InventarioServicio api = new InventarioServicio();
                    EstadoResultadoFinancieroDTO? data = await api.ObtenerDatosParaEstadoResultadoAsync(parameters);

                    if (data == null)
                    {
                        lstCostosFijos.Items.Clear();
                        lvsCostosVariable.Items.Clear();
                        lsvResultadoOperacion.Items.Clear();
                        MessageBox.Show("No se pudo obtener la informacion del estado de resultado.", "ADMINISTRACION");
                        return;
                    }

                    var gastos = data.gastosfijos
                        .Select(x => x.ToVm())
                        .OrderByDescending(x => x.GastoFijoFmt)
                        .ToList();

                    var costosFijos = gastos
                        .Where(x => !EsCostoVariable(x))
                        .ToList();

                    var costosVariables = gastos
                        .Where(EsCostoVariable)
                        .ToList();

                    var ventas = data.ventas
                        .Select(x => x.ToVm())
                        .ToList();

                    CargarCostos(lstCostosFijos, costosFijos);
                    CargarCostos(lvsCostosVariable, costosVariables);
                    CargarResultadoOperacion(costosFijos, costosVariables, ventas);
                }
                finally
                {
                    LoadingHelper.Cerrar(this, loading);
                }
            }
        }

        private static bool EsCostoVariable(CostoFijoEstadoResultadoDTO costo)
        {
            string esVariable = costo.EsVariable.Trim();
            return esVariable.Equals("1", StringComparison.OrdinalIgnoreCase)
              /*  || esVariable.Equals("1", StringComparison.OrdinalIgnoreCase)
                || esVariable.Equals("si", StringComparison.OrdinalIgnoreCase)
                || esVariable.Equals("sí", StringComparison.OrdinalIgnoreCase)*/;
        }

        private void CargarCostos(ListView listView, List<CostoFijoEstadoResultadoDTO> costos)
        {
            listView.BeginUpdate();
            try
            {
                listView.Items.Clear();

                foreach (var costo in costos)
                {
                    var item = new ListViewItem(costo.nombre_gasto);
                    item.SubItems.Add(costo.GastoFijoTexto);
                    listView.Items.Add(item);
                }

                decimal totalCostos = costos.Sum(x => x.GastoFijoFmt);
                var itemTotal = new ListViewItem("TOTAL")
                {
                    Font = new Font(listView.Font, FontStyle.Bold)
                };
                itemTotal.SubItems.Add($"C$ {NumberHelper.ToMiles(totalCostos, _culture)}");
                listView.Items.Add(itemTotal);
            }
            finally
            {
                listView.EndUpdate();
            }
            listView.Invalidate();
            listView.Refresh();
        }

        private void CargarResultadoOperacion(
            List<CostoFijoEstadoResultadoDTO> costosFijos,
            List<CostoFijoEstadoResultadoDTO> costosVariables,
            List<GanaciasMotoDTO> ventas)
        {
            decimal totalVentas = ventas.Sum(x => x.TotalFmt);
            decimal costoProductos = ventas.Sum(x => x.PrecioCompraFmt * x.CantidadFmt);
            decimal gananciaBruta = ventas.Sum(x => x.GananciaTotalFmt);
            decimal totalCostosFijos = costosFijos.Sum(x => x.GastoFijoFmt);
            decimal totalCostosVariables = costosVariables.Sum(x => x.GastoFijoFmt);
            decimal totalGastos = totalCostosFijos + totalCostosVariables;
            decimal resultadoNeto = gananciaBruta - totalGastos;
            long unidadesVendidas = ventas.Sum(x => x.CantidadFmt);

            lsvResultadoOperacion.BeginUpdate();
            try
            {
                lsvResultadoOperacion.Items.Clear();

                AgregarResultadoOperacion("UNIDADES VENDIDAS", unidadesVendidas.ToString("N0", _culture));
                AgregarResultadoOperacion("TOTAL VENTAS", totalVentas);
                AgregarResultadoOperacion("COSTO PRODUCTOS", costoProductos);
                AgregarResultadoOperacion("GANANCIA BRUTA", gananciaBruta, destacar: true);
                AgregarResultadoOperacion("COSTOS FIJOS", totalCostosFijos);
                AgregarResultadoOperacion("COSTOS VARIABLES", totalCostosVariables);
                AgregarResultadoOperacion("TOTAL COSTOS FIJOS + VARIABLES", totalGastos, destacar: true);
                AgregarResultadoOperacion("RESULTADO NETO", resultadoNeto, destacar: true, resaltar: true);
            }
            finally
            {
                lsvResultadoOperacion.EndUpdate();
            }
            lsvResultadoOperacion.Invalidate();
            lsvResultadoOperacion.Refresh();
        }

        private void AgregarResultadoOperacion(string nombreOperacion, decimal resultado, bool destacar = false, bool resaltar = false)
        {
            AgregarResultadoOperacion(nombreOperacion, $"C$ {NumberHelper.ToMiles(resultado, _culture)}", destacar, resaltar);
        }

        private void AgregarResultadoOperacion(string nombreOperacion, string resultado, bool destacar = false, bool resaltar = false)
        {
            var item = new ListViewItem(nombreOperacion);
            item.SubItems.Add(resultado);

            if (destacar)
            {
                item.Font = new Font(lsvResultadoOperacion.Font, FontStyle.Bold);
            }

            if (resaltar)
            {
                item.BackColor = Color.FromArgb(25, 118, 210);
                item.ForeColor = Color.White;
                item.UseItemStyleForSubItems = true;
            }

            lsvResultadoOperacion.Items.Add(item);
        }

        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (sender is not ListView listView)
            {
                return;
            }

            using (var backBrush = new SolidBrush(SystemColors.Control))
            using (var borderPen = new Pen(SystemColors.ControlDark))
            using (var headerFont = new Font(listView.Font, FontStyle.Bold))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                e.Graphics.DrawRectangle(borderPen, e.Bounds);

                TextRenderer.DrawText(
                    e.Graphics,
                    e.Header?.Text ?? string.Empty,
                    headerFont,
                    e.Bounds,
                    Color.Black,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis
                );
            }
        }

        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
