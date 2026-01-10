using System.Text.Json.Serialization;

namespace SIGMAF.Domain.MOTOS
{
    public class CatalogoConInventarioModel : IEntity
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("catalogo_id")]
        public string CatalogoId { get; set; } = string.Empty;

        [JsonPropertyName("nombre_producto")]
        public string NombreProducto { get; set; } = string.Empty;

        [JsonPropertyName("descripcion")]
        public string DescripcionProducto { get; set; } = string.Empty;

        [JsonPropertyName("inventario_stock_id")]
        public string inventarioStokId { get; set; } = string.Empty;

        [JsonPropertyName("stock_disponible")]
        public string StockDisponible {  get; set; } = string.Empty;

        [JsonPropertyName("stock_minimo")]
        public string StockMinimo { get; set; } = string.Empty;

        [JsonPropertyName("precio_compra")]
        public string PrecioCompra {  get; set; } = string.Empty;

        [JsonPropertyName("precio_venta")]
        public string PrecioVenta { get; set; } = string.Empty;
    }
}
