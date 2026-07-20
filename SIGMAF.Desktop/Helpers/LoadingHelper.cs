using SIGMAF_LoadingDemo;

namespace SIGMAF.Desktop.Helpers
{
    internal static class LoadingHelper
    {
        public static FrmLoading Mostrar(Form form)
        {
            var loading = new FrmLoading
            {
                StartPosition = FormStartPosition.Manual,
                ShowInTaskbar = false,
                UseWaitCursor = true
            };

            form.UseWaitCursor = true;
            SetControlsEnabled(form, false);
            ActivarFormulario(form);
            CentrarSobreFormulario(loading, form);
            loading.Show(form.MdiParent ?? form);
            loading.BringToFront();

            return loading;
        }

        public static void Cerrar(Form form, FrmLoading loading)
        {
            loading.Close();
            SetControlsEnabled(form, true);
            form.UseWaitCursor = false;
            ActivarFormulario(form);
        }

        private static void SetControlsEnabled(Control parent, bool enabled)
        {
            foreach (Control control in parent.Controls)
            {
                control.Enabled = enabled;
            }
        }

        private static void ActivarFormulario(Form form)
        {
            if (form.MdiParent != null)
            {
                form.BringToFront();
            }

            form.Activate();
        }

        private static void CentrarSobreFormulario(Form loading, Form form)
        {
            var bounds = form.RectangleToScreen(form.ClientRectangle);

            loading.Location = new Point(
                bounds.Left + (bounds.Width - loading.Width) / 2,
                bounds.Top + (bounds.Height - loading.Height) / 2);
        }
    }
}
