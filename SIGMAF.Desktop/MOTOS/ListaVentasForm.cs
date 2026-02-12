using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Domain.MOTOS;
using SIGMAF_LoadingDemo;
using System.Globalization;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class ListaVentasForm : Form
    {
        CompraServicio api;
        public ListaVentasForm()
        {
            InitializeComponent();
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            if (chWAMA.Checked == false && chALTALIER.Checked == false)
            {
                MessageBox.Show("Necesita seleccionar una o ambas sucursales", "ADIMINISTRACIÓN");
                return;
            }
            await CargarData();
        }
        private async Task CargarData()
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


                    parameters.Add("FechaInicio", dataFechaInicio.Value.ToString("yyyy-MM-dd", new CultureInfo("es-ES")));
                    parameters.Add("FechaFin", dateFechaFinal.Value.ToString("yyyy-MM-dd", new CultureInfo("es-ES")));
                    parameters.Add("Sucursal", chALTALIER.Checked && chWAMA.Checked ? "TODO" : chWAMA.Checked ? "WAMA" : "ALTALIER");
                    var listado = await api.ListadoVentaRepuestoAsync(parameters);


                    CargarListView(listado);
                }
                finally
                {
                    loading.Close();
                    this.Enabled = true;
                    this.UseWaitCursor = false;
                }
            }


        }

        public void CargarListView(List<ListadoVentasDTO> data)
        {
            lsvListadoVentas.Items.Clear();
            lsvListadoVentas.BeginUpdate();

            foreach (var itemCat in data)
            {
                var item = new ListViewItem(itemCat.IdVenta);
                item.SubItems.Add(itemCat.NombreProducto);
                item.SubItems.Add(itemCat.Cantidad);
                item.SubItems.Add(itemCat.Precio);
                item.SubItems.Add(itemCat.Total);
                item.SubItems.Add(itemCat.EstadoAplicado == "1" ? "Procesado en el inventario" : "");
                item.SubItems.Add(itemCat.NombreUsuario);
                item.SubItems.Add(Convert.ToDateTime(itemCat.FechaCreacion).ToString("dd/MM/yyyy hh:mm tt"));
                lsvListadoVentas.Items.Add(item);

            }
            lsvListadoVentas.EndUpdate();
            lsvListadoVentas.Invalidate();
            lsvListadoVentas.Refresh();
        }
        private void ListaVentasForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
            api = new CompraServicio();
            chWAMA.Checked = true;

            lsvListadoVentas.Columns.Clear();
            lsvListadoVentas.View = View.Details;
            lsvListadoVentas.FullRowSelect = true;
            lsvListadoVentas.OwnerDraw = true;

            lsvListadoVentas.Columns.Add("IdVenta", 0);
            lsvListadoVentas.Columns.Add("Producto", 500);
            lsvListadoVentas.Columns.Add("Cantidad", 100);
            lsvListadoVentas.Columns.Add("Precio", 100);
            lsvListadoVentas.Columns.Add("Total", 100);
            lsvListadoVentas.Columns.Add("Aplicado", 200);
            lsvListadoVentas.Columns.Add("Usuario", 200);
            lsvListadoVentas.Columns.Add("Fecha venta", 200);
            btnRefrescar_Click(null, null);
        }

        private async void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            using (RegistrarVentaForm form = new RegistrarVentaForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    await CargarData();
                }
            }
        }

        private void lsvListadoVentas_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var backBrush = new SolidBrush(SystemColors.Control))
            using (var borderPen = new Pen(SystemColors.ControlDark))
            using (var headerFont = new Font(lsvListadoVentas.Font, FontStyle.Bold))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                e.Graphics.DrawRectangle(borderPen, e.Bounds);

                // Texto en negrita
                TextRenderer.DrawText(
                    e.Graphics,
                    e.Header.Text,
                    headerFont,
                    e.Bounds,
                    Color.Black,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis
                );
            }
        }

        private void lsvListadoVentas_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lsvListadoVentas_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
}
