using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGMAF.Desktop.MOTOS
{
    public partial class InventarioRepuestoMotoForm : Form
    {
        public InventarioRepuestoMotoForm()
        {
            InitializeComponent();
        }

        private void InventarioRepuestoMotoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormularioAbierto = false;
        }
    }
}
