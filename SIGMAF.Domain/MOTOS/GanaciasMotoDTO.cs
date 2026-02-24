using System.Text.Json.Serialization;

namespace SIGMAF.Domain.MOTOS
{
    public class GanaciasMotoDTO
    {
        public string IdVenta {  get; set; } = string.Empty;
        public string IdCatalogoProducto { get; set; } = string.Empty;
        public string catalogo_id { get; set; } = string.Empty;
        public string nombre_catalogo { get; set; } = string.Empty;
        public string codigo_catalogo { get; set; } = string.Empty;
        public string Cantidad { get; set; } = string.Empty;
        public string Precio { get; set; } = string.Empty;
        public string Total { get; set; } = string.Empty;
        public string PrecioCompra { get; set; } = string.Empty;
        public string PrecioVentaUnit { get; set; } = string.Empty;
        public string GananciaUnit { get; set; } = string.Empty;
        public string GananciaTotal { get; set; } = string.Empty;
        public string Categoria {  get; set; } = string.Empty;  

        // Para mostrar con separador de miles
        [JsonIgnore]
        public decimal PrecioFmt { get; set; } 
        [JsonIgnore]
        public decimal PrecioCompraFmt { get; set; }

        [JsonIgnore]
        public long CantidadFmt { get; set; }

        [JsonIgnore]
        public decimal TotalFmt { get; set; }

        [JsonIgnore]
        public decimal PrecioVentaUnitFmt { get; set; }
        [JsonIgnore]
        public decimal GananciaUnitFmt { get; set; }
        [JsonIgnore]
        public decimal GananciaTotalFmt { get; set; }
    }
}
