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
                        lsvResultadoOperacion.Items.Clear();
                        MessageBox.Show("No se pudo obtener la informacion del estado de resultado.", "ADMINISTRACION");
                        return;
                    }

                    var costosFijos = data.gastosfijos
                        .Select(x => x.ToVm())
                        .OrderByDescending(x => x.GastoFijoFmt)
                        .ToList();

                    var ventas = data.ventas
                        .Select(x => x.ToVm())
                        .ToList();

                    CargarCostosFijos(costosFijos);
                    CargarResultadoOperacion(costosFijos, ventas);
                }
                finally
                {
                    LoadingHelper.Cerrar(this, loading);
                }
            }
        }

        private void CargarCostosFijos(List<CostoFijoEstadoResultadoDTO> costosFijos)
        {
            lstCostosFijos.Items.Clear();
            lstCostosFijos.BeginUpdate();

            foreach (var costo in costosFijos)
            {
                var item = new ListViewItem(costo.nombre_gasto);
                item.SubItems.Add(costo.GastoFijoTexto);
                lstCostosFijos.Items.Add(item);
            }

            decimal totalCostosFijos = costosFijos.Sum(x => x.GastoFijoFmt);
            var itemTotal = new ListViewItem("TOTAL")
            {
                Font = new Font(lstCostosFijos.Font, FontStyle.Bold)
            };
            itemTotal.SubItems.Add($"C$ {NumberHelper.ToMiles(totalCostosFijos, _culture)}");
            lstCostosFijos.Items.Add(itemTotal);

            lstCostosFijos.EndUpdate();
            lstCostosFijos.Invalidate();
            lstCostosFijos.Refresh();
        }

        private void CargarResultadoOperacion(List<CostoFijoEstadoResultadoDTO> costosFijos, List<GanaciasMotoDTO> ventas)
        {
            decimal totalVentas = ventas.Sum(x => x.TotalFmt);
            decimal costoProductos = ventas.Sum(x => x.PrecioCompraFmt * x.CantidadFmt);
            decimal gananciaBruta = ventas.Sum(x => x.GananciaTotalFmt);
            decimal totalCostosFijos = costosFijos.Sum(x => x.GastoFijoFmt);
            decimal resultadoNeto = gananciaBruta - totalCostosFijos;
            long unidadesVendidas = ventas.Sum(x => x.CantidadFmt);

            lsvResultadoOperacion.Items.Clear();
            lsvResultadoOperacion.BeginUpdate();

            AgregarResultadoOperacion("UNIDADES VENDIDAS", unidadesVendidas.ToString("N0", _culture));
            AgregarResultadoOperacion("TOTAL VENTAS", totalVentas);
            AgregarResultadoOperacion("COSTO PRODUCTOS", costoProductos);
            AgregarResultadoOperacion("GANANCIA BRUTA", gananciaBruta, destacar: true);
            AgregarResultadoOperacion("COSTOS FIJOS", totalCostosFijos);
            AgregarResultadoOperacion("RESULTADO NETO", resultadoNeto, destacar: true, resaltar: true);

            lsvResultadoOperacion.EndUpdate();
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
    }
}
