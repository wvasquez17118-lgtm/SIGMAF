using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Domain.MOTOS;
using SIGMAF_LoadingDemo;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class InventarioRepuestoMotoForm : Form
    {
        InventarioServicio apiServicio;
        public List<ListadoInventarioDTO> producto;
        public InventarioRepuestoMotoForm()
        {
            InitializeComponent();
        }

        private void InventarioRepuestoMotoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormularioAbierto = false;
        }

        private async void InventarioRepuestoMotoForm_Load(object sender, EventArgs e)
        {
            producto = new List<ListadoInventarioDTO>();
            apiServicio = new InventarioServicio();
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
                    await CargarData();
                }
                finally
                {
                    loading.Close();
                    this.Enabled = true;
                    this.UseWaitCursor = false;
                }
            }
        }
        private  async  Task  CargarData()
        {
            producto = await apiServicio.ObtenercatalogosconinventariomotoAsync();
            producto = producto
          .Select(x => x.ToVm())
          .OrderByDescending(x => x.CantidadFmt)
          .ToList();

            lsvInventario.Columns.Clear();
            lsvInventario.View = View.Details;
            lsvInventario.FullRowSelect = true;
            lsvInventario.OwnerDraw = true;

            lsvInventario.Columns.Add("ID", 0);
            lsvInventario.Columns.Add("Producto", 500);
            lsvInventario.Columns.Add("Disponible", 200);
            lsvInventario.Columns.Add("Stock", 200);
            lsvInventario.Columns.Add("Precio Compra", 200);
            lsvInventario.Columns.Add("Precio Venta", 200);
            CargarListView(producto);
        }
        public void CargarListView(List<ListadoInventarioDTO> data)
        {
            lsvInventario.Items.Clear();
            lsvInventario.BeginUpdate();

            foreach (var itemCat in data)
            {
                var item = new ListViewItem(itemCat.InventarioStockId);
                item.SubItems.Add(itemCat.NombreProducto);
                item.SubItems.Add(itemCat.StockDisponible);
                item.SubItems.Add(itemCat.StockMinimo);
                item.SubItems.Add(itemCat.PrecioCompraFmt);
                item.SubItems.Add(itemCat.PrecioVentaFmt);
                lsvInventario.Items.Add(item);

            }
            lsvInventario.EndUpdate();
            lsvInventario.Invalidate();
            lsvInventario.Refresh();
        }
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            if (producto.Any())
            {
                if (txtBuscarProducto.Text.Length == 0)
                {
                    CargarListView(producto);
                }
                else
                {
                    string texto = txtBuscarProducto.Text.Trim().ToLower();
                    CargarListView(producto.Where(p => p.NombreProducto.Trim().ToLower().Contains(texto)).ToList());
                }
            }
        }

        private void lsvInventario_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var backBrush = new SolidBrush(SystemColors.Control))
            using (var borderPen = new Pen(SystemColors.ControlDark))
            using (var headerFont = new Font(lsvInventario.Font, FontStyle.Bold))
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

        private void lsvInventario_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lsvInventario_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void actualizarDisponibleToolStripMenuItem_Click(object sender, EventArgs e)
        { 

            if (lsvInventario.SelectedItems.Count == 0)
                return;
            DialogResult r = MessageBox.Show("Estas seguro desea editar el registro?", "Edicion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                ListViewItem item = lsvInventario.SelectedItems[0];

                using (ActualizarInventarioForm form = new ActualizarInventarioForm())
                {
                    form.caseTypeAction = "disponible";
                    form.id = long.Parse(item.SubItems[0].Text);
                    form.txtNombreProducto.Text = item.SubItems[1].Text.ToUpper();
                    form.txtCantidadDisponible.Text = item.SubItems[2].Text;
                    form.txtStock.Text = item.SubItems[3].Text;
                    form.txtPrecioCompra.Text = item.SubItems[4].Text;
                    form.txtPrecioVenta.Text = item.SubItems[5].Text;                    
                    var result = form.ShowDialog();

                    // 🔹 Solo recargo si realmente guardó:
                    if (result == DialogResult.OK)
                    {
                        CargarData();
                    }
                }
            }
        }

        private void actualizarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (lsvInventario.SelectedItems.Count == 0)
                return;
            DialogResult r = MessageBox.Show("Estas seguro desea editar el registro?", "Edicion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                ListViewItem item = lsvInventario.SelectedItems[0];

                using (ActualizarInventarioForm form = new ActualizarInventarioForm())
                {
                    form.caseTypeAction = "stock";
                    form.id = long.Parse(item.SubItems[0].Text);
                    form.txtNombreProducto.Text = item.SubItems[1].Text.ToUpper();
                    form.txtCantidadDisponible.Text = item.SubItems[2].Text;
                    form.txtStock.Text = item.SubItems[3].Text;
                    form.txtPrecioCompra.Text = item.SubItems[4].Text;
                    form.txtPrecioVenta.Text = item.SubItems[5].Text;
                    var result = form.ShowDialog();

                    // 🔹 Solo recargo si realmente guardó:
                    if (result == DialogResult.OK)
                    {
                        CargarData();
                    }
                }
            }
        }

        private void actualizarPrecioCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvInventario.SelectedItems.Count == 0)
                return;
            DialogResult r = MessageBox.Show("Estas seguro desea editar el registro?", "Edicion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                ListViewItem item = lsvInventario.SelectedItems[0];

                using (ActualizarInventarioForm form = new ActualizarInventarioForm())
                {
                    form.caseTypeAction = "preciocompra";
                    form.id = long.Parse(item.SubItems[0].Text);
                    form.txtNombreProducto.Text = item.SubItems[1].Text.ToUpper();
                    form.txtCantidadDisponible.Text = item.SubItems[2].Text;
                    form.txtStock.Text = item.SubItems[3].Text;
                    form.txtPrecioCompra.Text = item.SubItems[4].Text;
                    form.txtPrecioVenta.Text = item.SubItems[5].Text;
                    var result = form.ShowDialog();

                    // 🔹 Solo recargo si realmente guardó:
                    if (result == DialogResult.OK)
                    {
                        CargarData();
                    }
                }
            }
        }

        private void actualizarPrecioVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvInventario.SelectedItems.Count == 0)
                return;
            DialogResult r = MessageBox.Show("Estas seguro desea editar el registro?", "Edicion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                ListViewItem item = lsvInventario.SelectedItems[0];

                using (ActualizarInventarioForm form = new ActualizarInventarioForm())
                {
                    form.caseTypeAction = "precioventa";
                    form.id = long.Parse(item.SubItems[0].Text);
                    form.txtNombreProducto.Text = item.SubItems[1].Text.ToUpper();
                    form.txtCantidadDisponible.Text = item.SubItems[2].Text;
                    form.txtStock.Text = item.SubItems[3].Text;
                    form.txtPrecioCompra.Text = item.SubItems[4].Text;
                    form.txtPrecioVenta.Text = item.SubItems[5].Text;
                    var result = form.ShowDialog();

                    // 🔹 Solo recargo si realmente guardó:
                    if (result == DialogResult.OK)
                    {
                        CargarData();
                    }
                }
            }
        }
    }
}
