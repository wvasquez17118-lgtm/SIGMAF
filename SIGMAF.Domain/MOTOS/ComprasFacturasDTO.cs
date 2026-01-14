using System.Text.Json.Serialization;

namespace SIGMAF.Domain.MOTOS
{
    public class ComprasFacturasDTO
    {
        [JsonPropertyName("compra_id")]
        public string CompraId { get; set; } = string.Empty;

        [JsonPropertyName("fecha")]
        public DateTime FechaFactura { get; set; }

        [JsonPropertyName("estado_proceso_desc")]
        public string EstadoProceso { get; set; } = string.Empty;

        [JsonPropertyName("total")]
        public string Total {  get; set; } = string.Empty;

        [JsonPropertyName("subtotal")] 
        public string SubTotal { get; set; } = string.Empty;

        [JsonPropertyName("descuento")]
        public string Descuento { get; set; } = string.Empty;

        [JsonPropertyName("nombre")]
        public string Proveedor { get; set; } = string.Empty;

        [JsonPropertyName("tipo_factura")]
        public string TipoFactura { get; set; } = string.Empty;

        // Para mostrar con separador de miles
        [JsonIgnore]
        public string TotalFmt { get; init; } = "0";
        [JsonIgnore]
        public string SubTotalFmt { get; init; } = "0";
        [JsonIgnore]
        public string DescuentoFmt { get; init; } = "0";
        [JsonIgnore]
        public long CompraIdFmt { get; set; }
    }
}
