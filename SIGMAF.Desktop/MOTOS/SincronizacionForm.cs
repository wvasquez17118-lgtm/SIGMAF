using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Desktop.Constantes;
using SIGMAF.Desktop.DB;
using SIGMAF.Infrastructure;
using SIGMAF_LoadingDemo;
using System.Globalization;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class SincronizacionForm : Form
    {
        CatalogoService api = new CatalogoService();
        public SincronizacionForm()
        {
            InitializeComponent();
        }

        private async void btnSincronizar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            if (chActualizarInventarioVenta.Checked)
            {
                mensaje = string.Format(ConstantesMensajes.MensajeTituloSincronizarInventarioCorrectamente, dateFechaSincronizacion.Value.ToString("dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES")));
            }
            else
            {
                mensaje = ConstantesMensajes.MensajeTituloSincronizarCatalogoCorrectamente;
            }
            DialogResult r = MessageBox.Show(mensaje, ConstantesMensajes.MensajeConfirmacionGuardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        SqliteDatabase.DeleteDatabase(AppServices.ConnectionString);
                        SqliteDatabase.Initialize(AppServices.ConnectionString);
                        
                        var catalogos = await api.ObtenerCatalogoAsync();
                        var proveedor = await api.ObtenerProveedoresAsync();
                        var catalogosConInventario = await api.ObtenerCatalogosConInventarioMotoAsync();

                        if (catalogos.Any())
                        {
                            AppServices.Catalogos.InsertarVarios(catalogos);
                        }
                        if (proveedor.Any())
                        {
                            AppServices.Proveedores.InsertarVarios(proveedor);
                        }
                        if (!catalogosConInventario.Any())
                        {
                            AppServices.CatalogoConInventario.InsertarVarios(catalogosConInventario);
                        }

                        MessageBox.Show(chActualizarInventarioVenta.Checked ? string.Format(ConstantesMensajes.MensajeTituloSincronizarInventarioExitosamente, dateFechaSincronizacion.Value.ToString("dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"))) : ConstantesMensajes.MensajeTituloGuardadoCorrectamente, "Confirmación");
                        btnSincronizar.Enabled = false;
                        chActualizarInventarioVenta.Checked = false;
                        ChDescargarCatalogo.Checked = false;
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

        private void ChDescargarCatalogo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChDescargarCatalogo.Checked)
            {
                btnSincronizar.Enabled = true;
                chActualizarInventarioVenta.Checked = false;
            }
            else
            {
                btnSincronizar.Enabled = false;
            }
        }

        private void chActualizarInventarioVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (chActualizarInventarioVenta.Checked)
            {
                btnSincronizar.Enabled = true;
                ChDescargarCatalogo.Checked = false;
            }
            else
            {
                btnSincronizar.Enabled = false;
            }
        }

        private void SincronizacionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormularioAbierto = false;
        }
    }
}
