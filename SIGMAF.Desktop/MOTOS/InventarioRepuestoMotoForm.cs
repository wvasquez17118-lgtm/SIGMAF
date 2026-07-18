using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Desktop.Helpers;
using SIGMAF.Domain.MOTOS;
using SIGMAF_LoadingDemo;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class InventarioRepuestoMotoForm : Form
    {
        InventarioServicio apiServicio;
        public List<ListadoInventarioDTO> producto;
        private string filtroCantidadUno = string.Empty;
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
            await CargarData();
        }
        private async Task CargarData(bool mostrarMensajeStockBajo = true)
        {
            producto = new List<ListadoInventarioDTO>();
            ActualizarLabelAlertaStockBajo(new List<ListadoInventarioDTO>());
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
                    Dictionary<string, string> parameters = new Dictionary<string, string>();

                    parameters.Add("sucursal", "ALL");
                    producto = await apiServicio.ObtenercatalogosconinventariomotoAsync(parameters);
                    producto = producto
                  .Select(x => x.ToVm())
                  .OrderByDescending(x => x.CantidadFmt)
                  .ToList();

                    lsvInventario.Columns.Clear();
                    lsvInventario.View = View.Details;
                    lsvInventario.FullRowSelect = true;
                    lsvInventario.OwnerDraw = true;

                    lsvInventario.Columns.Add("IDCatalogo", 0);
                    lsvInventario.Columns.Add("Producto", 500);
                    lsvInventario.Columns.Add("Disponible", 200);
                    lsvInventario.Columns.Add("Stock", 200);
                    lsvInventario.Columns.Add("Precio Compra", 200);
                    lsvInventario.Columns.Add("Precio Venta", 200);
                    lsvInventario.Columns.Add("Precio Venta Altalier", 200);
                    lsvInventario.Columns.Add("Cantidad Altalier", 200);
                    lsvInventario.Columns.Add("Cantidad Wama", 200);
                    AplicarFiltros();
                    MostrarAlertaStockBajo(mostrarMensajeStockBajo);
                }
                finally
                {
                    loading.Close();
                    this.Enabled = true;
                    this.UseWaitCursor = false;
                }
            }


        }
        public void CargarListView(List<ListadoInventarioDTO> data)
        {
            lsvInventario.Items.Clear();
            lsvInventario.BeginUpdate();

            foreach (var itemCat in data)
            {
                var item = new ListViewItem(itemCat.CatalogoId);
                item.SubItems.Add(itemCat.NombreProducto);
                item.SubItems.Add(itemCat.StockDisponible);
                item.SubItems.Add(itemCat.StockMinimo);
                item.SubItems.Add(itemCat.PrecioCompraFmt);
                item.SubItems.Add(itemCat.PrecioVentaFmt);
                item.SubItems.Add(itemCat.PrecioVentaAltalierFmt);
                item.SubItems.Add(itemCat.CantidadAltalier);
                item.SubItems.Add(itemCat.CantidadWama);
                lsvInventario.Items.Add(item);

            }
            lsvInventario.EndUpdate();
            lsvInventario.Invalidate();
            lsvInventario.Refresh();
            lblTotalProductos.Text = $"Total productos: {data.Count}";
        }
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (producto == null || !producto.Any())
            {
                CargarListView(new List<ListadoInventarioDTO>());
                return;
            }

            IEnumerable<ListadoInventarioDTO> data = producto;
            string texto = txtBuscarProducto.Text.Trim().ToLower();

            if (!string.IsNullOrWhiteSpace(texto))
            {
                data = data.Where(p => p.NombreProducto.Trim().ToLower().Contains(texto));
            }

            if (chkStockMinimo.Checked)
            {
                data = data.Where(p => NumberHelper.ToLong(p.StockDisponible) <= NumberHelper.ToLong(p.StockMinimo));
            }

            if (filtroCantidadUno == "wama")
            {
                data = data.Where(p => NumberHelper.ToLong(p.CantidadWama) == 1);
            }
            else if (filtroCantidadUno == "altalier")
            {
                data = data.Where(p => NumberHelper.ToLong(p.CantidadAltalier) == 1);
            }

            CargarListView(data.ToList());
        }

        private List<ListadoInventarioDTO> ObtenerProductosStockBajo()
        {
            if (producto == null || !producto.Any())
            {
                return new List<ListadoInventarioDTO>();
            }

            return producto
                .Where(p => NumberHelper.ToLong(p.StockDisponible) <= NumberHelper.ToLong(p.StockMinimo))
                .ToList();
        }

        private void MostrarAlertaStockBajo(bool mostrarMensaje)
        {
            var productosStockBajo = ObtenerProductosStockBajo();
            ActualizarLabelAlertaStockBajo(productosStockBajo);

            if (!productosStockBajo.Any())
            {
                return;
            }

            if (!mostrarMensaje)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                "Hay productos con Stock Bodega igual o menor al Stock.\n\nPresiona Si para ver esos productos o No para continuar.",
                "Alerta de stock",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                chkStockMinimo.Checked = true;
                AplicarFiltros();
            }
        }

        private void ActualizarLabelAlertaStockBajo(List<ListadoInventarioDTO> productosStockBajo)
        {
            lblAlertaStock.Text = $"Productos bajo stock bodega: {productosStockBajo.Count}";
            lblAlertaStock.Visible = productosStockBajo.Any();
            lblAlertaStock.Refresh();
            panel1.Refresh();
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
        /// <summary>
        /// /////////////////////////////aca es el metodo original
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actualizarDisponibleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lsvInventario.SelectedItems.Count == 0)
                return;

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
                form.txtPrecioVentaAltalier.Text = item.SubItems[6].Text;
                form.txtCantidadAltalier.Text = item.SubItems[7].Text;
                form.txtCantidadWAMA.Text = item.SubItems[8].Text;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CargarData();
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
                    form.txtPrecioVentaAltalier.Text = item.SubItems[6].Text;
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
                    form.txtPrecioVentaAltalier.Text = item.SubItems[6].Text;
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
                    form.txtPrecioVentaAltalier.Text = item.SubItems[6].Text;
                    form.txtCantidadAltalier.Text = item.SubItems[7].Text;
                    form.txtCantidadWAMA.Text = item.SubItems[8].Text;
                    var result = form.ShowDialog();

                    // 🔹 Solo recargo si realmente guardó:
                    if (result == DialogResult.OK)
                    {
                        CargarData();
                    }
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            filtroCantidadUno = string.Empty;
            chkStockMinimo.Checked = false;
            await CargarData();
        }

        private void chkStockMinimo_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private async Task ActualizarYFiltrarCantidadUnoAsync(string ubicacion)
        {
            filtroCantidadUno = ubicacion;
            await CargarData(mostrarMensajeStockBajo: false);
            AplicarFiltros();
        }

        private async void productosCon1DisponibleWamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ActualizarYFiltrarCantidadUnoAsync("wama");
        }

        private async void productosCon1DisponibleAltalierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ActualizarYFiltrarCantidadUnoAsync("altalier");
        }
    }
}
