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
    public partial class RegistrosGastosForm : Form
    {
        public RegistrosGastosForm()
        {
            InitializeComponent();
            PrepararFormulario();
        }

        private void PrepararFormulario()
        {
            lstGastos.Columns.Clear();
            lstGastos.View = View.Details;
            lstGastos.FullRowSelect = true;
            lstGastos.OwnerDraw = true;
            lstGastos.Columns.Add("DESCRIPCION", 300);
            lstGastos.Columns.Add("COSTO", 120);
            lstGastos.Columns.Add("COSTO FIJO", 120);

            btnNuevo.Click += btnNuevo_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEditar.Click += btnEditar_Click;
            txtCosto.KeyPress += txtCosto_KeyPress;
            lstGastos.DoubleClick += lstGastos_DoubleClick;
            lstGastos.DrawColumnHeader += ListView_DrawColumnHeader;
            lstGastos.DrawItem += ListView_DrawItem;
            lstGastos.DrawSubItem += ListView_DrawSubItem;
            FormClosing += RegistrosGastosForm_FormClosing;

            LimpiarControles();
            EstablecerModoEdicion(false);
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void EstablecerModoEdicion(bool habilitar)
        {
            txtDescripcion.Enabled = habilitar;
            txtCosto.Enabled = habilitar;
            chEsCostoFijo.Enabled = habilitar;
        }

        private void LimpiarControles()
        {
            txtDescripcion.Clear();
            txtCosto.Clear();
            chEsCostoFijo.Checked = false;
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            LimpiarControles();
            EstablecerModoEdicion(true);

            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            txtDescripcion.Focus();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            LimpiarControles();
            EstablecerModoEdicion(false);

            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            EstablecerModoEdicion(true);

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void lstGastos_DoubleClick(object? sender, EventArgs e)
        {
            if (lstGastos.SelectedItems.Count == 0)
                return;

            ListViewItem item = lstGastos.SelectedItems[0];

            txtDescripcion.Text = item.Text;
            txtCosto.Text = item.SubItems.Count > 1 ? item.SubItems[1].Text : string.Empty;
            chEsCostoFijo.Checked = item.SubItems.Count > 2 && item.SubItems[2].Text == "SI";

            EstablecerModoEdicion(false);
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void RegistrosGastosForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Global.FormularioAbierto = false;
        }

        private void txtCosto_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.' && !txtCosto.Text.Contains('.'))
                return;

            e.Handled = true;
        }

        private void ListView_DrawColumnHeader(object? sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (sender is not ListView listView)
            {
                return;
            }

            using (var backBrush = new SolidBrush(SystemColors.Control))
            using (var borderPen = new Pen(SystemColors.ControlDark))
            using (var headerFont = new Font(listView.Font, FontStyle.Bold))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                e.Graphics.DrawRectangle(borderPen, e.Bounds);

                TextRenderer.DrawText(
                    e.Graphics,
                    e.Header?.Text ?? string.Empty,
                    headerFont,
                    e.Bounds,
                    Color.Black,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis
                );
            }
        }

        private void ListView_DrawItem(object? sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListView_DrawSubItem(object? sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {

        }
    }
}
