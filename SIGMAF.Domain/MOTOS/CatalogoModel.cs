using System.Text.Json.Serialization;

namespace SIGMAF.Domain.MOTOS
{
    public class CatalogoModel : IEntity
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("id")]
        public string IdCatalogo { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;


        [JsonPropertyName("codigocatalogo")]
        public string Codigo { get; set; } = string.Empty;

        [JsonPropertyName("codigo")]
        public string CodigoCategoria { get; set; } = string.Empty;

        [JsonPropertyName("idcategoria")]
        public string IdCategoria { get; set; }


        [JsonPropertyName("estado")]
        public string Estado { get; set; }
    }
}