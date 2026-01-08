using Microsoft.Data.Sqlite;
using SIGMAF.Domain.MOTOS;

namespace SIGMAF.Infrastructure.MOTOS
{
    public class ProveedorRepository
    {
        private readonly SqliteCrud<ProveedorModel> _crud;

        public ProveedorRepository(string connectionString)
        {
            _crud = new SqliteCrud<ProveedorModel>(
                connectionString,
                tableName: "MotosProveedores",
                mapFromReader: MapFromReader,
                toDictionary: ToDictionary
            );
        }

        // Mapeo lector -> entidad
        private ProveedorModel MapFromReader(SqliteDataReader reader)
        {
            var ordId = reader.GetOrdinal("Id");
            var ordProvId = reader.GetOrdinal("ProveedorId");
            var ordDireccion = reader.GetOrdinal("Direccion");
            var ordNombre = reader.GetOrdinal("Nombre");
            var ordCelular = reader.GetOrdinal("Celular");
            var ordEstado = reader.GetOrdinal("Estado");

            return new ProveedorModel
            {
                Id = reader.IsDBNull(ordId) ? 0 : reader.GetInt32(ordId),

                ProveedorId = reader.IsDBNull(ordProvId) ? "" : reader.GetString(ordProvId),
                Direccion = reader.IsDBNull(ordDireccion) ? "" : reader.GetString(ordDireccion),
                Nombre = reader.IsDBNull(ordNombre) ? "" : reader.GetString(ordNombre),
                Celular = reader.IsDBNull(ordCelular) ? "" : reader.GetString(ordCelular),
                Estado = reader.IsDBNull(ordEstado) ? "" : reader.GetString(ordEstado),
            };
        }

        // Mapeo entidad -> columnas (sin Id)
        private Dictionary<string, object?> ToDictionary(ProveedorModel c)
        {
            return new Dictionary<string, object?>
            {
                ["ProveedorId"] = c.ProveedorId,
                ["Direccion"] = c.Direccion,
                ["Nombre"] = c.Nombre,
                ["Celular"] = c.Celular,
                ["Estado"] = c.Estado,
            };
        }


        public int InsertarVarios(IEnumerable<ProveedorModel> catalogos)
    => _crud.InsertMany(catalogos);

        public int Insertar(ProveedorModel catalogo) => _crud.Insert(catalogo);

        public int Actualizar(ProveedorModel catalogo) => _crud.Update(catalogo);

        public int Eliminar(int id) => _crud.Delete(id);

        public ProveedorModel? ObtenerPorId(int id) => _crud.GetById(id);

        public List<ProveedorModel> ListarTodos() => _crud.GetAll();
    }
}