using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Domain.MOTOS;
using SIGMAF_LoadingDemo;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class GananciasRepuestosForm : Form
    {
        public GananciasRepuestosForm()
        {
            InitializeComponent();
        }
        private PlotView _plot;

        private void GananciasRepuestosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormularioAbierto = false;
        }
        private void lsvData_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var backBrush = new SolidBrush(SystemColors.Control))
            using (var borderPen = new Pen(SystemColors.ControlDark))
            using (var headerFont = new Font(lsvData.Font, FontStyle.Bold))
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

        private void lsvData_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lsvData_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void GananciasRepuestosForm_Load(object sender, EventArgs e)
        {
            chWaMA.Checked = true;
            btnCostos.Text = "Costos " +
                "\n" +
                "\n" +
                "0";
            _plot = new PlotView { Dock = DockStyle.Fill, BackColor = Color.White };
            panel3.Controls.Clear();
            panel3.Controls.Add(_plot);


            lsvData.Columns.Clear();
            lsvData.View = View.Details;
            lsvData.FullRowSelect = true;
            lsvData.OwnerDraw = true;

            lsvData.Columns.Add("IDCatalogo", 0);
            lsvData.Columns.Add("Producto", 500);
            lsvData.Columns.Add("Cantidad", 200);
            lsvData.Columns.Add("Precio Compra", 200);
            lsvData.Columns.Add("Precio Venta", 200);
            lsvData.Columns.Add("Precio Ganancia Unitario", 200);
            lsvData.Columns.Add("Precio Ganancia Total", 200);

            btnRefrescar_Click(null, null);
          
        }
        public void RenderGananciaPorCategoria(List<CatResumen> items)
        {
            if (items == null) items = new List<CatResumen>();

            // 1) DIBUJAR DONA (OxyPlot)
            var model = new PlotModel
            {
                PlotAreaBorderThickness = new OxyThickness(0),
                Padding = new OxyThickness(0),
                PlotMargins = new OxyThickness(0),
            };

            double total = items.Sum(x => (double)x.Ganancia);
            if (total <= 0) total = 1;

            var pie = new PieSeries
            {
                InnerDiameter = 0.60,           // dona
                StrokeThickness = 1,
                AngleSpan = 360,
                StartAngle = 0,

                OutsideLabelFormat = string.Empty,  // sin texto afuera
                InsideLabelFormat = "{2:0.0}%",     // porcentaje
                InsideLabelColor = OxyColors.White,
                //  InsideLabelFontSize = 12,
                FontSize = 15,

                // esto ayuda a que se vea grande/centrado
                Diameter = 0.95
            };

            foreach (var it in items)
            {
                pie.Slices.Add(new PieSlice(it.Nombre, (double)it.Ganancia) { Fill = it.Color });
            }

            model.Series.Add(pie);
            _plot.Model = model;
            _plot.InvalidatePlot(true);

            // 2) LISTA IZQUIERDA (como tu ejemplo)
            PintarListaIzquierda(items);
        }

        private void PintarListaIzquierda(List<CatResumen> items)
        {
            panel2.Controls.Clear();

            // título
            var lblTitle = new Label
            {
                Text = "Ganancia por categoría",
                Dock = DockStyle.Top,
                Height = 24,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel2.Controls.Add(lblTitle);

            // tabla
            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                ColumnCount = 3,
                Padding = new Padding(0, 6, 6, 6)
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55)); // nombre
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); // unidades
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30)); // ganancia

            // filas dinámicas (+1 para TOTAL al final)
            tbl.RowCount = items.Count + 1;

            int row = 0;
            foreach (var it in items)
            {
                // Col 0: ● Nombre
                tbl.Controls.Add(MakeDotText(it.Color, it.Nombre), 0, row);

                // Col 1: unidades
                tbl.Controls.Add(new Label
                {
                    Text = it.Unidades.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 14, FontStyle.Regular)
                }, 1, row);

                // Col 2: C$ ganancia
                tbl.Controls.Add(new Label
                {
                    Text = $"C$ {it.Ganancia:N2}",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 14, FontStyle.Regular)
                }, 2, row);

                row++;
            }

            // TOTAL al final
            var total = items.Sum(x => x.Ganancia);
            tbl.Controls.Add(new Label
            {
                Text = "Total",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            }, 0, row);

            tbl.Controls.Add(new Label { Text = "", Dock = DockStyle.Fill }, 1, row);

            tbl.Controls.Add(new Label
            {
                Text = $"C$ {total:N2}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            }, 2, row);

            panel2.Controls.Add(tbl);
            tbl.BringToFront();
        }
        private Control MakeDotText(OxyColor color, string text)
        {

            var p = new Panel { Dock = DockStyle.Fill, Height = 35 };

            var dot = new Label
            {
                Text = "●",
                ForeColor = OxyToColor(color),
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(0, 1)
            };

            var lbl = new Label
            {
                Text = text,
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Regular),
                Location = new Point(18, 3),
            };
            p.Controls.Add(dot);
            p.Controls.Add(lbl);
            return p;
        }

        private Color OxyToColor(OxyColor c) => Color.FromArgb(c.A, c.R, c.G, c.B);

        private async  void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarData();
        }

        private async Task CargarData()
        {
            // Fuerza un cambio de tamaño para que se reajusten los controles
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
                    Dictionary<string, string> parameters = new Dictionary<string, string>();


                    parameters.Add("FechaInicio", dateFechaInicio.Value.ToString("yyyy-MM-dd", new CultureInfo("es-ES")));
                    parameters.Add("FechaFin", dateFechaFinal.Value.ToString("yyyy-MM-dd", new CultureInfo("es-ES")));
                    parameters.Add("Sucursal", chALTALIER.Checked && chWaMA.Checked ? "0" : chWaMA.Checked ? "2" : "1");

                    InventarioServicio api = new InventarioServicio();
                    var data = await api.MotoListarVentasPorRangoFechaGananciasAsync(parameters);
                    data = data
                .Select(x => x.ToVm())
                .OrderByDescending(x => x.CantidadFmt)
                .ToList();
 
                    btnUnidades.Text = "Unidades " +
            "\n" +
            "\n" +
            "" + data.Sum(p => p.CantidadFmt).ToString(); 
                    btnGanancias.Text = "Ganancias " +
            "\n" +
            "\n" +
            "C$ " + data.Sum(p => p.GananciaTotalFmt).ToString();


                    btnTotal.Text =   "Total " +
            "\n" +
            "\n" +
            "C$ " + data.Sum(p => p.TotalFmt).ToString(); data.Sum(p => p.PrecioFmt).ToString();


                    List<CatResumen> resumen = data.GroupBy(p => new { p.Categoria }).Select(g => new CatResumen
                    {
                        Nombre = g.Key.Categoria,
                        Unidades = g.Sum(x => x.CantidadFmt),
                        Ganancia = g.Sum(x => x.GananciaTotalFmt),
                        Color = ColorFromKey(g.Key.Categoria)
                    }).ToList();

                 

                    RenderGananciaPorCategoria(resumen);

                    lsvData.Items.Clear();
                    lsvData.BeginUpdate();

                    foreach (var itemCat in data)
                    {
                        var item = new ListViewItem(itemCat.IdCatalogoProducto);
                        item.SubItems.Add(itemCat.nombre_catalogo);
                        item.SubItems.Add(itemCat.Cantidad); 
                        item.SubItems.Add(itemCat.PrecioCompra);
                        item.SubItems.Add(itemCat.PrecioVentaUnit);
                        item.SubItems.Add(itemCat.GananciaUnit);
                        item.SubItems.Add(itemCat.GananciaTotal);
                        lsvData.Items.Add(item);

                    }
                    lsvData.EndUpdate();
                    lsvData.Invalidate();
                    lsvData.Refresh();
                     
                }
                finally
                {
                    loading.Close();
                    this.Enabled = true;
                    this.UseWaitCursor = false;
                }
            } 
        }
        private static OxyColor ColorFromKey(string key)
        {
            // Seed estable por texto (hash)
            int seed = key?.GetHashCode() ?? 0;
            var rnd = new Random(seed);

            // Rangos para evitar colores muy oscuros o muy claros
            byte r = (byte)rnd.Next(60, 230);
            byte g = (byte)rnd.Next(60, 230);
            byte b = (byte)rnd.Next(60, 230);

            return OxyColor.FromRgb(r, g, b);
        }
    }


    public class CatResumen
    {
        public string Nombre { get; set; } = "";
        public long Unidades { get; set; }
        public decimal Ganancia { get; set; }
        public OxyColor Color { get; set; } = OxyColors.Gray;
    }
}
