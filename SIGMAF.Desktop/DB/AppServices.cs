using SIGMAF.Infrastructure;
using SIGMAF.Infrastructure.MOTOS;

namespace SIGMAF.Desktop.DB
{
    public static class AppServices
    {
        public static CatalogoRepository Catalogos { get; private set; } = null!;
        public static ProveedorRepository Proveedores { get; private set; } = null!;
        public static CatalogoConInventarioRepository CatalogoConInventario { get; private set; } = null!;
        
        public static string ConnectionString { get; private set; } = null!;

        public static void Initialize()
        {
            ConnectionString = "Data Source=sigmaf_local.db";

            // Crear BD y tablas si no existen
            SqliteDatabase.Initialize(ConnectionString);

            // Instanciar repositorios
            Catalogos = new CatalogoRepository(ConnectionString);
            Proveedores = new ProveedorRepository(ConnectionString);
            CatalogoConInventario = new CatalogoConInventarioRepository(ConnectionString);

            // Aquí después agregás más repos: UsuariosLocal, SucursalesLocal, etc.
        }
    }
}
