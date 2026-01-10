using Microsoft.Data.Sqlite;
using SIGMAF.Domain.MOTOS;

namespace SIGMAF.Infrastructure.MOTOS
{
    public class CatalogoRepository
    {
        private readonly SqliteCrud<CatalogoModel> _crud;

        public CatalogoRepository(string connectionString)
        {
            _crud = new SqliteCrud<CatalogoModel>(
                connectionString,
                tableName: "MotosCatalogos",
                mapFromReader: MapFromReader,
                toDictionary: ToDictionary
            );
        }

        // Mapeo lector -> entidad
        private CatalogoModel MapFromReader(SqliteDataReader reader)
        {
            return new CatalogoModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                IdCatalogo = reader.GetString(reader.GetOrdinal("IdCatalogo")),
                IdCategoria = reader.GetString(reader.GetOrdinal("IdCategoria")),
                CodigoCategoria = reader.GetString(reader.GetOrdinal("CodigoCategoria")),
                Estado = reader.GetString(reader.GetOrdinal("Estado")),
            };
        }

        // Mapeo entidad -> columnas (sin Id)
        private Dictionary<string, object?> ToDictionary(CatalogoModel c)
        {
            return new Dictionary<string, object?>
            {
                ["Codigo"] = c.Codigo,
                ["Descripcion"] = c.Descripcion,
                ["Nombre"] = c.Nombre,
                ["IdCatalogo"] = c.IdCatalogo,
                ["IdCategoria"] = c.IdCategoria,
                ["CodigoCategoria"] = c.CodigoCategoria,
                ["Estado"] = c.Estado,
            };
        }


        public int InsertarVarios(IEnumerable<CatalogoModel> catalogos)
    => _crud.InsertMany(catalogos);

        public int Insertar(CatalogoModel catalogo) => _crud.Insert(catalogo);

        public int Actualizar(CatalogoModel catalogo) => _crud.Update(catalogo);

        public int Eliminar(int id) => _crud.Delete(id);

        public CatalogoModel? ObtenerPorId(int id) => _crud.GetById(id);

        public List<CatalogoModel> ListarTodos() => _crud.GetAll();
    }
}