using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class EstadoResultadoFinancieroForm : Form
    {
        public EstadoResultadoFinancieroForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EstadoResultadoFinancieroForm_Load(object sender, EventArgs e)
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
        }

        private void dateFechaFinal_ValueChanged(object sender, EventArgs e)
        {

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
    }
}
