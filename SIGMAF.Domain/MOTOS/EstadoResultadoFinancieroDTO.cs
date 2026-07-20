using System.Text.Json.Serialization;

namespace SIGMAF.Domain.MOTOS
{
    public class EstadoResultadoFinancieroDTO
    {
        public List<CostoFijoEstadoResultadoDTO> gastosfijos { get; set; } = new List<CostoFijoEstadoResultadoDTO>();
        public List<GanaciasMotoDTO> ventas { get; set; } = new List<GanaciasMotoDTO>();
    }

    public class CostoFijoEstadoResultadoDTO
    {
        public string id { get; set; } = string.Empty;
        public string nombre_gasto { get; set; } = string.Empty;
        public string gasto_fijo { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string EsVariable { get; set; } = string.Empty;

        [JsonIgnore]
        public decimal GastoFijoFmt { get; set; }

        [JsonIgnore]
        public string GastoFijoTexto { get; set; } = string.Empty;
    }
}
