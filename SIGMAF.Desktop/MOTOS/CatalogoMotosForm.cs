using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Desktop.Constantes;
using SIGMAF.Domain.MOTOS;
using SIGMAF_LoadingDemo;
using System;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class CatalogoMotosForm : Form
    {
        CatalogoService api = new CatalogoService();
        private int idproducto = 0;
        public string idcategoria = string.Empty;
        public class CategoriaProducto
        {
            public string Codigo { get; set; } = string.Empty;
            public string Descripcion { get; set; } = string.Empty;
        }
        public CatalogoMotosForm()
        {
            InitializeComponent();
        }

        private List<CatalogoModel> resultado = new List<CatalogoModel>();
        private async void CatalogoMotosForm_Load(object sender, EventArgs e)
        { // Fuerza un cambio de tamaño para que se reajusten los controles
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
                    await CargarCatalogoAsync();
                }
                finally
                {
                    loading.Close();
                    this.Enabled = true;
                    this.UseWaitCursor = false;
                }
            }
            CargarCategoria();
        }

        private async Task CargarCatalogoAsync()
        {
            lsvCatalogos.Columns.Clear();
            lsvCatalogos.Columns.Add("Id", 0);
            lsvCatalogos.Columns.Add("IdCatalogo", 0);
            lsvCatalogos.Columns.Add("Codigo", 0);
            lsvCatalogos.Columns.Add("Producto", 400);
            lsvCatalogos.Columns.Add("Descripcion", 400);

            resultado = await api.ObtenerCatalogoAsync();

            CargarListview(resultado);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                CargarListview(resultado);
            }
            else
            {
                filtro = filtro.ToLower();
                CargarListview(resultado.Where(p => p.Nombre.ToLower().Contains(filtro)).ToList());
            }
        }

        private void CargarListview(List<CatalogoModel> data)
        {
            lblTotalProducto.Text = "TOTAL: " + data.Count.ToString();
            lsvCatalogos.BeginUpdate();
            lsvCatalogos.Items.Clear();

            foreach (var itemCat in data)
            {
                var item = new ListViewItem(itemCat.IdCatalogo);
                item.SubItems.Add(itemCat.IdCategoria.ToString());
                item.SubItems.Add(itemCat.Codigo);
                item.SubItems.Add(itemCat.Nombre);
                item.SubItems.Add(itemCat.Descripcion);

                lsvCatalogos.Items.Add(item);
                if (itemCat.Estado == "0")
                {
                    item.BackColor = Color.Red;
                    item.ForeColor = Color.White;
                }
            }
            lsvCatalogos.EndUpdate();
        }

        private void CargarCategoria()
        {
            var categorias = new List<CategoriaProducto>
            {
                new CategoriaProducto { Codigo = "",  Descripcion = "--Selecciona cataegoria--" },
                new CategoriaProducto { Codigo = "1",  Descripcion = "RM - Repuestos moto" },
                new CategoriaProducto { Codigo = "2", Descripcion = "LUB - Lubricantes" },
                new CategoriaProducto { Codigo = "3", Descripcion = "ACC - Accesorios" },
                new CategoriaProducto { Codigo = "4", Descripcion = "LULED - Luces led" },
            };

            cmbCategoriaProducto.DataSource = categorias;
            cmbCategoriaProducto.DisplayMember = "Descripcion";
            cmbCategoriaProducto.ValueMember = "Codigo";
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (this.txtBusqueda.Text.Trim().Length == 0)
            {
                CargarListview(resultado);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idcategoria = string.Empty;
            idproducto = 0;
            txtProducto.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            cmbCategoriaProducto.SelectedValue = "";
            txtProducto.Enabled = true;
            cmbCategoriaProducto.Enabled = true;
            txtDescripcion.Enabled = true;
            txtDescripcion.Text = "";

            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            idcategoria = string.Empty;
            idproducto = 0;
            txtProducto.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            cmbCategoriaProducto.SelectedValue = "";
            txtProducto.Enabled = false;
            cmbCategoriaProducto.Enabled = false;
            txtDescripcion.Enabled = false;

            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCategoriaProducto.SelectedValue?.ToString() == "")
            {
                MessageBox.Show("Registro categoria es requerido.", "Advertencia");
                cmbCategoriaProducto.Focus();
            }
            else if (txtProducto.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Registro producto es requerido.", "Advertencia");
                txtProducto.Focus();
            }
            else
            {
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
                            Dictionary<string, string> parameters = new Dictionary<string, string>();


                            parameters.Add("accion", idproducto == 0 ? "NUEVO" : "ACTUALIZAR");
                            parameters.Add("id", idproducto.ToString());
                            parameters.Add("nombre", txtProducto.Text.Trim());
                            parameters.Add("idcategoria", cmbCategoriaProducto.SelectedValue?.ToString() ?? "");
                            parameters.Add("codigo", txtCodigo.Text);
                            parameters.Add("descripcion", txtDescripcion.Text.Trim());
                            parameters.Add("cambiocategoria", idcategoria != cmbCategoriaProducto.SelectedValue?.ToString().Split('-')[0] ? "SI" : "NO");
                            var resultado = await api.GuardarCatalogoAsync(parameters);
                            if (resultado.Estado)
                            {
                                MessageBox.Show(ConstantesMensajes.MensajeTituloGuardadoCorrectamente,"ADMINISTRACIÓN");
                                await CargarCatalogoAsync();
                            }
                            idproducto = 0;
                            txtProducto.Clear();
                            txtCodigo.Clear();
                            txtDescripcion.Clear();
                            cmbCategoriaProducto.SelectedValue = "";
                            txtProducto.Enabled = false;
                            cmbCategoriaProducto.Enabled = false;
                            txtDescripcion.Enabled = false;

                            btnCancelar.Enabled = false;
                            btnNuevo.Enabled = true;
                            btnGuardar.Enabled = false;
                            btnEliminar.Enabled = false;
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
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(ConstantesMensajes.MensajeConfirmacionEliminar, ConstantesMensajes.MensajeTituloConfirmacionEliminar, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                Dictionary<string, string> parameters = new Dictionary<string, string>();


                parameters.Add("accion", "ELIMINAR");
                parameters.Add("id", idproducto.ToString());
                parameters.Add("nombre", txtProducto.Text.Trim());
                parameters.Add("idcategoria", cmbCategoriaProducto.SelectedValue?.ToString() ?? "");
                parameters.Add("codigo", txtCodigo.Text);
                parameters.Add("descripcion", txtDescripcion.Text.Trim());
                parameters.Add("cambiocategoria", "");
                var resultado = await api.GuardarCatalogoAsync(parameters);
                if (resultado.Estado)
                {
                    MessageBox.Show(ConstantesMensajes.MensajeTituloEliminadoCorrectamente);
                    await CargarCatalogoAsync();
                }
                idproducto = 0;
                txtProducto.Clear();
                txtCodigo.Clear();
                txtDescripcion.Clear();
                cmbCategoriaProducto.SelectedValue = "";
                txtProducto.Enabled = false;
                cmbCategoriaProducto.Enabled = false;
                txtDescripcion.Enabled = false;

                btnCancelar.Enabled = false;
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void lsvCatalogos_DoubleClick(object sender, EventArgs e)
        {
            if (lsvCatalogos.SelectedItems.Count == 0)
                return;  // por seguridad

            // Item seleccionado (la fila)
            ListViewItem item = lsvCatalogos.SelectedItems[0];

            // Columna id producto
            idproducto = Convert.ToInt32(item.Text);

            cmbCategoriaProducto.SelectedValue = item.SubItems[1].Text;
            idcategoria = item.SubItems[1].Text;
            txtCodigo.Text = item.SubItems[2].Text;
            txtProducto.Text = item.SubItems[3].Text;
            txtDescripcion.Text = item.SubItems[4].Text;


            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            txtProducto.Enabled = true;
            cmbCategoriaProducto.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void CatalogoMotosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormularioAbierto = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
