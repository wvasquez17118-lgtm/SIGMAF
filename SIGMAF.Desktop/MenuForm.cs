using SIGMAF.Desktop.Constantes;
using SIGMAF.Desktop.MOTOS;
using SIGMAF.Domain.MOTOS;
using SIGMAF_LoadingDemo;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SIGMAF.Desktop
{
    public partial class MenuForm : Form
    {
        private int _velocidadX = 2;
        private bool _haciaDerecha = true;

        private Bitmap _imgBase;
        private Bitmap _imgTintada;
        private readonly Random _rand = new Random();


        public MenuForm()
        {
            InitializeComponent();
            this.MdiChildActivate += MenuForm_MdiChildActivate;
        }
        private void MenuForm_MdiChildActivate(object sender, EventArgs e)
        {
            // Si hay un hijo activo, enganchamos su evento de cierre
            var child = this.ActiveMdiChild;
            if (child != null)
            {
                // evita enganchar doble
                child.FormClosed -= Child_FormClosed;
                child.FormClosed += Child_FormClosed;
            }

            ActualizarFondoMDI(); // por si cambiaste de ventana
        }

        private void Child_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Aquí ya se eliminó del MdiChildren ✅
            ActualizarFondoMDI();
        }

        public void ActualizarFondoMDI()
        {
            this.BeginInvoke(new Action(() =>
            {
                pictureBox1.Visible = (this.MdiChildren.Length == 0);
            }));
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
            _imgBase = Properties.Resources.icon_moto_ida;
            CambiarColorRandom();
            AplicarDireccion(true);
            picAnimacion.Left = 0;
            picAnimacion.Top = (panelInferior.Height - picAnimacion.Height) / 2;
            timerAnimacion.Start();
            inicioToolStripMenuItem_Click(null, null);
        }


        private Button CreateRibbonButton(string text, Image iconFile, Action onClick = null)
        {

            var btn = new Button();
            btn.Text = text;
            btn.Size = new Size(130, 80);   // antes 100, 80
            btn.TextAlign = ContentAlignment.BottomCenter;
            btn.TextImageRelation = TextImageRelation.ImageAboveText;
            btn.BackColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 210, 225);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(227, 242, 253);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 225, 240);
            btn.TextAlign = ContentAlignment.BottomCenter;
            btn.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btn.Margin = new Padding(4);
            btn.Padding = new Padding(4);

            btn.Image = iconFile;
            btn.ImageAlign = ContentAlignment.TopCenter;


            if (onClick != null)
            {
                btn.Click += (s, e) => onClick();
            }
            return btn;
        }

        #region MENU STRIP MOTO
        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "SIGMAF – Menu GYM";
            flowMenu.SuspendLayout();
            flowMenu.Controls.Clear();
            flowMenu.Controls.Add(CreateRibbonButton("Catálogos", SIGMAF.Desktop.Properties.Resources.icon_catalogo, () => AbrirCatalogosMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Ventas", SIGMAF.Desktop.Properties.Resources.icon_venta, () => AbrirVentaRepuestoMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Compras", SIGMAF.Desktop.Properties.Resources.icon_compras, () => AbrirAgregarComprasMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Inventarios", SIGMAF.Desktop.Properties.Resources.icon_inventory, () => AbrirInventarioRepuestoMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Ganancias", SIGMAF.Desktop.Properties.Resources.icon_ganancias, () => AbrirGanaciasRepuestoMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Sincronización", SIGMAF.Desktop.Properties.Resources.icon_sincronizacion, () => AbrirSincronizacionMOTOS()));
            flowMenu.ResumeLayout();
        }
        #endregion

        #region FORMULARIOS MOTOS

        private T AbrirOActivarForm<T>() where T : Form, new()
        {
            // 1. Buscar si ya hay una instancia abierta
            var existente = this.MdiChildren.OfType<T>().FirstOrDefault();

            //pictureBox1.Dock = DockStyle.Fill;
            //pictureBox1.SendToBack();

            if (existente != null)
            {
                // 2. Ya existe → traer al frente y refrescar datos
                existente.WindowState = FormWindowState.Maximized;
                existente.BringToFront();
                existente.Activate();

                return existente;
            }

            // 3. No existe → crear, mostrar y refrescar
            var frm = new T
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };

            frm.Show();

            return frm;
        }

        private void AbrirCatalogosMotos()
        {
            this.Text = "SIGMAF – Catálogos repuestos MOTOS";
            AbrirOActivarForm<CatalogoMotosForm>();
        }

        private void AbrirVentaRepuestoMotos()
        {
            this.Text = "SIGMAF – Agregar ventas MOTOS";
            AbrirOActivarForm<RegistrarVentaForm>();
        }

        private void AbrirAgregarComprasMotos()
        {
            this.Text = "SIGMAF – Listar compras MOTOS";
            AbrirOActivarForm<ListarComprasForm>();
        }
        private void AbrirInventarioRepuestoMotos()
        {
            this.Text = "SIGMAF – Inventario repuestos MOTOS";
            AbrirOActivarForm<InventarioRepuestoMotoForm>();
        }

        private void AbrirGanaciasRepuestoMotos()
        {
            this.Text = "SIGMAF – Ganancias repuestos MOTOS";
            AbrirOActivarForm<GananciasRepuestosForm>();
        }

        private void AbrirSincronizacionMOTOS()
        {
            this.Text = "SIGMAF – Sincronización MOTOS";
            AbrirOActivarForm<SincronizacionForm>();
        }
        #endregion


        private void movimientosVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowMenu.SuspendLayout();
            flowMenu.Controls.Clear();
            // flowMenu.Controls.Add(CreateRibbonButton("Venta", "icon_catalogos.png", () => AbrirCatalogosGym()));
            //flowMenu.Controls.Add(CreateRibbonButton("Inventario", "icon_catalogos.png", () => AbrirCatalogosGym()));
            flowMenu.ResumeLayout();
        }

        #region METODO ANIMACION FOOTTER
        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            int nuevoX = picAnimacion.Left + _velocidadX;
            if (nuevoX <= 0)
            {
                nuevoX = 0;
                _velocidadX = Math.Abs(_velocidadX);
                CambiarColorRandom();
                AplicarDireccion(true);
            }
            else if (nuevoX + picAnimacion.Width >= panelInferior.Width)
            {
                nuevoX = panelInferior.Width - picAnimacion.Width;
                _velocidadX = -Math.Abs(_velocidadX);
                CambiarColorRandom();
                AplicarDireccion(false);
            }
            picAnimacion.Left = nuevoX;
        }

        private void CambiarColorRandom()
        {
            var color = GetRandomColor();

            _imgTintada?.Dispose();
            _imgTintada = TintImage(_imgBase, color);
        }
        private Bitmap TintImage(Bitmap original, Color newColor)
        {
            var tinted = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color src = original.GetPixel(x, y);

                    if (src.A == 0)
                    {
                        tinted.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {
                        Color dst = Color.FromArgb(src.A, newColor.R, newColor.G, newColor.B);
                        tinted.SetPixel(x, y, dst);
                    }
                }
            }

            return tinted;
        }
        private void AplicarDireccion(bool haciaDerecha)
        {
            _haciaDerecha = haciaDerecha;
            var bmp = (Bitmap)_imgTintada.Clone();
            if (!haciaDerecha)
            {
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            picAnimacion.Image?.Dispose();
            picAnimacion.Image = bmp;
        }


        private Color GetRandomColor()
        {
            int r = _rand.Next(80, 256);
            int g = _rand.Next(80, 256);
            int b = _rand.Next(80, 256);
            return Color.FromArgb(255, r, g, b);
        }
        #endregion

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(ConstantesMensajes.MensajeConfirmacionGuardar, ConstantesMensajes.MensajeTituloConfirmacionGuardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                 
            }
        }
    }
}
