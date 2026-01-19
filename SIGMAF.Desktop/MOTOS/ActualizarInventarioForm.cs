namespace SIGMAF.Desktop.MOTOS
{
    public partial class ActualizarInventarioForm : Form
    {
        public string caseTypeAction = "";
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
    }
}
