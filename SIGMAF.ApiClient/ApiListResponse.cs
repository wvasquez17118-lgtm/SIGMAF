using System.Text.Json.Serialization;

namespace SIGMAF.ApiClient
{
    public class ApiListResponse<T>
    {
        [JsonPropertyName("estado")]
        public bool Estado { get; set; }

        [JsonPropertyName("data")]
        public List<T>? Data { get; set; }

        [JsonPropertyName("mensaje")]
        public string? Mensaje { get; set; }
    }

    public class ApiCrudResponse
    {
        [JsonPropertyName("estado")]
        public bool Estado { get; set; }        

        [JsonPropertyName("mensaje")]
        public string? Mensaje { get; set; }
    }
}
