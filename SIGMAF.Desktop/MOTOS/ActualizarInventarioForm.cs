using SIGMAF.ApiClient.ApiRestMoto;
using SIGMAF.Desktop.Constantes;
using SIGMAF_LoadingDemo;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class ActualizarInventarioForm : Form
    {
        public string caseTypeAction = "";
        public long id = 0;
        public ActualizarInventarioForm()
        {
            InitializeComponent();
        }

        private void ActualizarInventarioForm_Load(object sender, EventArgs e)
        {
            txtPrecioCompra.Enabled = true;
            txtPrecioVenta.Enabled = true;
            txtStock.Enabled = true;
            txtCantidadDisponible.Enabled = true;
            switch (caseTypeAction)
            {
                case "preciocompra":
                    lblTitulo.Text = "Actualizar producto del inventario => Precio Compra";
                    txtPrecioCompra.Enabled = true;
                    break;
                case "precioventa":
                    lblTitulo.Text = "Actualizar producto del inventario => Precio Venta";
                    txtPrecioVenta.Enabled = true;
                    break;
                case "stock":
                    lblTitulo.Text = "Actualizar producto del inventario => Stock";
                    txtStock.Enabled = true;
                    break;
                case "disponible":
                    lblTitulo.Text = "Actualizar producto del inventario => Cantidad Disponible";
                    txtCantidadDisponible.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void txtCantidadDisponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite control (Backspace, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Permite dígitos 0-9
            if (char.IsDigit(e.KeyChar))
                return;

            // (Opcional) Permitir signo negativo solo al inicio y solo una vez
            if (e.KeyChar == '-' && ((TextBox)sender).SelectionStart == 0 && !((TextBox)sender).Text.Contains("-"))
                return;

            // Bloquea todo lo demás
            e.Handled = true;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            bool save = true;

            if (txtPrecioCompra.Text.Length == 0)
                save = false;                   
            
            if (txtPrecioVenta.Text.Length == 0)
                save = false;                   
                            
            if (txtStock.Text.Length == 0)
                save = false;                 
            
            if (txtCantidadDisponible.Text.Length == 0)
                save = false;

            if (save)
            {
                InventarioServicio api = new InventarioServicio();

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

                            parameters.Add("catalogoId", id.ToString());
                            parameters.Add("stockDisponible", txtCantidadDisponible.Text.Trim());
                            parameters.Add("stockMinimo", txtStock.Text.Trim());
                            parameters.Add("precioCompra", txtPrecioCompra.Text.Trim());
                            parameters.Add("precioVenta", txtPrecioVenta.Text.Trim());

                            var resultado = await api.MotoActualizarInventarioProductoAsync(parameters);
                            if (resultado.Estado)
                            {
                                MessageBox.Show(ConstantesMensajes.MensajeTituloGuardadoCorrectamente, "ADMINISTRACIÓN");
                            }
                            DialogResult = DialogResult.OK;
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
            else
            {
                MessageBox.Show("Por favor necesitas llenar todos los campos, es requerido", "ADMINISTRACIÓN");
            }
        }
    }
}
