using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

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

        private void GananciasRepuestosForm_Load(object sender, EventArgs e)
        {
            btnCostos.Text = "Costos " +
                "\n" +
                "\n" +
                "C$  30 2522";
            _plot = new PlotView { Dock = DockStyle.Fill, BackColor = Color.White };
            panel3.Controls.Clear();
            panel3.Controls.Add(_plot);

            // EJEMPLO (reemplazá por tus datos reales):
            var data = new List<CatResumen>
        {
            new CatResumen { Nombre="Lubricantes", Unidades=75, Ganancia=500.15m, Color=OxyColor.Parse("#2E86DE") },
            new CatResumen { Nombre="Repuestos",   Unidades=30, Ganancia=270.00m, Color=OxyColor.Parse("#F1C40F") },
            new CatResumen { Nombre="Eléctricos",  Unidades=33, Ganancia=800.00m, Color=OxyColor.Parse("#E67E22") },
            new CatResumen { Nombre="Lujo",        Unidades=78, Ganancia=1200.50m, Color=OxyColor.Parse("#2ECC71") },
        };

            RenderGananciaPorCategoria(data);
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

            // 3) LEYENDA DERECHA (● nombre)
            //PintarLeyendaDerecha(items);
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

        //private void PintarLeyendaDerecha(List<CatResumen> items)
        //{
        //    panel4.Controls.Clear();

        //    var flow = new FlowLayoutPanel
        //    {
        //        Dock = DockStyle.Fill,
        //        FlowDirection = FlowDirection.TopDown,
        //        WrapContents = false,
        //        AutoScroll = true,
        //        Padding = new Padding(8, 30, 8, 8)
        //    };

        //    foreach (var it in items)
        //    {
        //        var row = new Panel { Width = panel4.Width - 20, Height = 22 };

        //        var dot = new Label
        //        {
        //            Text = "●",
        //            ForeColor = OxyToColor(it.Color),
        //            AutoSize = true,
        //            Font = new Font("Segoe UI", 10, FontStyle.Bold),
        //            Location = new Point(0, 2)
        //        };

        //        var name = new Label
        //        {
        //            Text = it.Nombre,
        //            AutoSize = true,
        //            Font = new Font("Segoe UI", 9, FontStyle.Regular),
        //            Location = new Point(18, 3)
        //        };

        //        row.Controls.Add(dot);
        //        row.Controls.Add(name);
        //        flow.Controls.Add(row);
        //    }

        //    panel4.Controls.Add(flow);
        //}

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
    }

 

    public class CatResumen
    {
        public string Nombre { get; set; } = "";
        public int Unidades { get; set; }
        public decimal Ganancia { get; set; }
        public OxyColor Color { get; set; } = OxyColors.Gray;
    }
}
