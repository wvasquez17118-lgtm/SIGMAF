using System.Text.Json.Serialization;

namespace SIGMAF.Domain.MOTOS
{
    public class ProveedorModel : IEntity
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("proveedor_id")]
        public string ProveedorId { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("direccion")]
        public string Direccion { get; set; } = string.Empty;

        [JsonPropertyName("celular")]
        public string Celular { get; set; } = string.Empty;

        [JsonPropertyName("estado")]
        public string Estado { get; set; }
    }
}
