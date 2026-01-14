using SIGMAF.Desktop.MOTOS;
using SIGMAF_LoadingDemo;
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
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            _imgBase = Properties.Resources.icon_moto_ida;
            CambiarColorRandom();
            AplicarDireccion(true);
            picAnimacion.Left = 0;
            picAnimacion.Top = (panelInferior.Height - picAnimacion.Height) / 2;
            timerAnimacion.Start();
        }


        private Button CreateRibbonButton(string text, string iconFile, Action onClick = null)
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

            btn.Image = LoadIcon(iconFile);
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
            flowMenu.Controls.Add(CreateRibbonButton("Catálogos", "icon_catalogo.png", () => AbrirCatalogosMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Ventas", "icon_venta.png", () => AbrirVentaRepuestoMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Compras", "icon_compras.png", () => AbrirAgregarComprasMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Inventarios", "icon_inventory.png", () => AbrirAgregarComprasMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Ajustes stock", "icon_ajustestock.png", () => AbrirCatalogosMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Stock", "icon_bar.png", () => AbrirCatalogosMotos()));
            flowMenu.Controls.Add(CreateRibbonButton("Sincronización", "icon_sincronizacion.png", () => AbrirSincronizacionMOTOS()));
            flowMenu.ResumeLayout();
        }
        #endregion

        #region FORMULARIOS MOTOS
        private void AbrirCatalogosMotos()
        {
            if (!Global.FormularioAbierto)
            {
                Global.FormularioAbierto = true;
                this.Text = "SIGMAF – Catálogos MOTOS";
                CatalogoMotosForm frm = new CatalogoMotosForm();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void AbrirVentaRepuestoMotos()
        {
            if (!Global.FormularioAbierto)
            {
                Global.FormularioAbierto = true;
                this.Text = "SIGMAF – Catálogos MOTOS";
                RegistrarVentaForm frm = new RegistrarVentaForm();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }
        

        private void AbrirAgregarComprasMotos()
        {
            if (!Global.FormularioAbierto)
            {
                Global.FormularioAbierto = true;
                this.Text = "SIGMAF – Agregar compras MOTOS";
                //ComprasForm frm = new ComprasForm();
                ListarComprasForm frm = new ListarComprasForm();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void AbrirSincronizacionMOTOS()
        {
            if (!Global.FormularioAbierto)
            {
                Global.FormularioAbierto = true;
                this.Text = "SIGMAF – Sincronización MOTOS";
                SincronizacionForm frm = new SincronizacionForm();
                frm.MdiParent = this;
                frm.Show();
            }
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


        private Image LoadIcon(string fileName)
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;

                // Caso publicado: exe + recursos
                string pathBinRecursos = Path.Combine(basePath, "recursos");
                string rootRecursos;

                if (Directory.Exists(pathBinRecursos))
                {
                    rootRecursos = pathBinRecursos;
                }
                else
                {
                    // Caso Visual Studio: subir a la raíz del proyecto
                    string projectRoot = Path.GetFullPath(Path.Combine(basePath, @"..\..\.."));
                    rootRecursos = Path.Combine(projectRoot, "recursos");
                }

                string fullPath = Path.Combine(rootRecursos, fileName);
                if (File.Exists(fullPath))
                {
                    return Image.FromFile(fullPath);
                }
            }
            catch
            {
                // ignoramos errores
            }

            return null;
        }
    }
}
