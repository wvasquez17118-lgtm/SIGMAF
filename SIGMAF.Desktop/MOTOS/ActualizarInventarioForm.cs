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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
