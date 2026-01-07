using SIGMAF.Desktop.DB;
using SIGMAF_MenuDemo;

namespace SIGMAF.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicializar SQLite y repositorios
            AppServices.Initialize();
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}