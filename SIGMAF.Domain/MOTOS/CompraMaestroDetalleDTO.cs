using System.Text.Json.Serialization;

namespace SIGMAF.Domain.MOTOS
{
    public class CompraMaestroDetalleDTO
    {
        [JsonPropertyName("Compra")]
        public CompraMaestroDTO Compra { get; set; } = new();

        [JsonPropertyName("Detalle")]
        public List<CompraDetalleDTO> Detalle { get; set; } = new();
    }
    public class CompraDetalleDTO
    {
        [JsonPropertyName("compra_detalle_id")]
        public string CompraDetalleId { get; set; } = string.Empty;

        [JsonPropertyName("compra_id")]
        public string CompraId { get; set; } = string.Empty;

        [JsonPropertyName("catalogo_id")]
        public string CatalogoId { get; set; } = string.Empty;

        [JsonPropertyName("cantidad")]
        public string Cantidad { get; set; } = string.Empty;

        [JsonPropertyName("precio_compra")]
        public string PrecioCompra { get; set; } = string.Empty;

        [JsonPropertyName("precio_venta")]
        public string PrecioVenta { get; set; } = string.Empty;

        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; } = string.Empty;
    }
    public class CompraMaestroDTO
    {
        [JsonPropertyName("compra_id")]
        public string CompraId { get; set; } = string.Empty;

        [JsonPropertyName("fecha")]
        public string Fecha { get; set; } = string.Empty;

        [JsonPropertyName("proveedor_id")]
        public string ProveedorId { get; set; } = string.Empty;        

        [JsonPropertyName("tipo_factura")]
        public string TipoFactura { get; set; } = string.Empty; // 'CR' o 'CO'

        [JsonPropertyName("subtotal")]
        public string SubTotal { get; set; } = string.Empty;

        [JsonPropertyName("descuento")]
        public string Descuento { get; set; } = string.Empty;

        [JsonPropertyName("total")]
        public string Total { get; set; } = string.Empty;

        [JsonPropertyName("observacion")]
        public string? Observacion { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; } = string.Empty;

        [JsonPropertyName("estado_proceso")]
        public string EstadoProceso { get; set; }  // 1/2 

        // Para evitar problemas de parseo de fechas (por el " " en MySQL),
        // lo dejo string. Si vos ya parseás bien, lo podés cambiar a DateTime?.
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; } = string.Empty;

        [JsonPropertyName("updated_at")]
        public string? UpdatedAt { get; set; }
    }
}
