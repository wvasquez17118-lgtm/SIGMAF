using Microsoft.Data.Sqlite;
using SIGMAF.Domain.MOTOS;

namespace SIGMAF.Infrastructure.MOTOS
{
    public class CatalogoConInventarioRepository
    {
        private readonly SqliteCrud<CatalogoConInventarioModel> _crud;

        public CatalogoConInventarioRepository(string connectionString)
        {
            _crud = new SqliteCrud<CatalogoConInventarioModel>(
                connectionString,
                tableName: "MotosCatalagoConInventario",
                mapFromReader: MapFromReader,
                toDictionary: ToDictionary
            );
        }

        // Mapeo lector -> entidad
        private CatalogoConInventarioModel MapFromReader(SqliteDataReader reader)
        {
            return new CatalogoConInventarioModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                CatalogoId = reader.GetString(reader.GetOrdinal("CatalogoId")),
                NombreProducto = reader.GetString(reader.GetOrdinal("NombreProducto")),
                DescripcionProducto = reader.GetString(reader.GetOrdinal("DescripcionProducto")),
                inventarioStokId = reader.GetString(reader.GetOrdinal("inventarioStokId")),
                StockDisponible = reader.GetString(reader.GetOrdinal("StockDisponible")),
                StockMinimo = reader.GetString(reader.GetOrdinal("StockMinimo")),
                PrecioCompra = reader.GetString(reader.GetOrdinal("PrecioCompra")),
                PrecioVenta = reader.GetString(reader.GetOrdinal("PrecioVenta")),
            };
        }
         
        // Mapeo entidad -> columnas (sin Id)
        private Dictionary<string, object?> ToDictionary(CatalogoConInventarioModel c)
        {
            return new Dictionary<string, object?>
            {
                ["CatalogoId"] = c.CatalogoId,
                ["NombreProducto"] = c.NombreProducto,
                ["DescripcionProducto"] = c.DescripcionProducto,
                ["inventarioStokId"] = c.inventarioStokId,
                ["StockDisponible"] = c.StockDisponible,
                ["StockMinimo"] = c.StockMinimo,
                ["PrecioCompra"] = c.PrecioCompra,
                ["PrecioVenta"] = c.PrecioVenta,
            };
        }


        public int InsertarVarios(IEnumerable<CatalogoConInventarioModel> catalogos)
    => _crud.InsertMany(catalogos);

        public int Insertar(CatalogoConInventarioModel catalogo) => _crud.Insert(catalogo);

        public int Actualizar(CatalogoConInventarioModel catalogo) => _crud.Update(catalogo);

        public int Eliminar(int id) => _crud.Delete(id);

        public CatalogoConInventarioModel? ObtenerPorId(int id) => _crud.GetById(id);

        public List<CatalogoConInventarioModel> ListarTodos() => _crud.GetAll();
    }
}