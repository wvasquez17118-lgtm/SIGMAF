using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF_LoadingDemo;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class ListarComprasForm : Form
    {
        public ListarComprasForm()
        {
            InitializeComponent();
        }

        private void ListarComprasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormularioAbierto = false;
        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            ComprasForm compras = new ComprasForm();
            compras.ShowDialog();
        }

        private   void ListarComprasForm_Load(object sender, EventArgs e)
        {
              Cargar();
        }


        private async void Cargar()
        {
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
                    CompraServicio compraServicio = new CompraServicio();
                    var data = await compraServicio.MotoListarFacturasComprasAsync();
                    var culture = CultureInfo.GetCultureInfo("es-NI");

                    var lista = data
                        .Select(x => x.ToVm(culture))
                        .OrderByDescending(x => x.CompraIdFmt)
                        .ToList();

                    lsvListadoCompras.Columns.Clear();
                    lsvListadoCompras.Items.Clear();

                    lsvListadoCompras.Columns.Add("CompraID", 100);
                    lsvListadoCompras.Columns.Add("Proveedor", 200);
                    lsvListadoCompras.Columns.Add("Tipo Compra", 200);
                    lsvListadoCompras.Columns.Add("Fecha Compra", 150);
                    lsvListadoCompras.Columns.Add("SubTotal", 100);
                    lsvListadoCompras.Columns.Add("Descuento", 100);
                    lsvListadoCompras.Columns.Add("Total", 100);
                    lsvListadoCompras.Columns.Add("Estado", 200);

                    lsvListadoCompras.BeginUpdate();

                    foreach (var itemCat in lista)
                    {
                        var item = new ListViewItem(itemCat.CompraIdFmt.ToString());
                        item.SubItems.Add(itemCat.Proveedor);
                        item.SubItems.Add(itemCat.TipoFactura);
                        item.SubItems.Add(itemCat.FechaFactura.ToString("dd/MM/yyyy"));
                        item.SubItems.Add(itemCat.SubTotalFmt);
                        item.SubItems.Add(itemCat.DescuentoFmt);
                        item.SubItems.Add(itemCat.TotalFmt);
                        item.SubItems.Add(itemCat.EstadoProceso);
                        lsvListadoCompras.Items.Add(item);

                    }
                    lsvListadoCompras.EndUpdate();
                }
                finally
                {
                    loading.Close();
                    this.Enabled = true;
                    this.UseWaitCursor = false;
                }
            }
        }
        private void lsvListadoCompras_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Averiguar qué item está bajo el mouse
                var info = lsvListadoCompras.HitTest(e.Location);

                if (info.Item != null)
                {
                    // Limpiar selección anterior
                    lsvListadoCompras.SelectedItems.Clear();

                    // Seleccionar la fila donde hiciste clic derecho
                    info.Item.Selected = true;
                    lsvListadoCompras.FocusedItem = info.Item;
                }
                else
                {
                    // Si clic derecho en espacio en blanco, limpiar selección
                    lsvListadoCompras.SelectedItems.Clear();
                }
            }
        }

        private void editarCompraFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvListadoCompras.SelectedItems.Count == 0)
                return;
            DialogResult r = MessageBox.Show("Estas seguro desea editar el registro?", "Edicion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                ListViewItem item = lsvListadoCompras.SelectedItems[0];

                using (ComprasForm form = new ComprasForm())
                {
                    form.compraid = long.Parse(item.SubItems[0].Text);
                  //  form.Titulo = string.Format("Detalle trabajo realizados ingreso taller => Moto placa N°. {0}  Fecha Ingreso taller => {1}.", item.SubItems[3].Text, item.SubItems[1].Text);
                    var result = form.ShowDialog();

                    // 🔹 Solo recargo si realmente guardó:
                    if (result == DialogResult.OK)
                    {
                        Cargar();
                    }
                }
            }
           
        }
    }
}
