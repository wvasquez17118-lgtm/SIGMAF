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

        [JsonPropertyName("mensajeerror")]
        public string? Mensaje { get; set; }
    }

    public class ApiResponse<T>
    {
        [JsonPropertyName("estado")]
        public bool Estado { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("mensajeerror")]
        public string? MensajeError { get; set; }
    }
}
