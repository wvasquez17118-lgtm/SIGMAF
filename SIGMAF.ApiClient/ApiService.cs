using SIGMAF.ApiClient;
using SIGMAF.Domain.MOTOS;
using System.Text.Json;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public ApiService(HttpClient? httpClient = null)
    {
        // Podés inyectar un HttpClient desde fuera o crear uno aquí
        _httpClient = httpClient ?? new HttpClient
        {
            BaseAddress = new Uri(ApiConstants.BaseUrl)
        };

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    /// <summary>
    /// Método genérico para hacer POST y devolver una lista de T
    /// siguiendo el formato: { estado, data: [ ... ] }.
    /// </summary>
    public async Task<List<T>> PostListAsync<T>(string relativeUrl, Dictionary<string, string>? parameters = null) 
    {

        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, relativeUrl);

            // Si hay parámetros, los mandamos como application/x-www-form-urlencoded
            if (parameters != null && parameters.Count > 0)
            {
                request.Content = new FormUrlEncodedContent(parameters);
            }

            using var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new List<T>();
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            ApiListResponse<T>? apiResponse =
                JsonSerializer.Deserialize<ApiListResponse<T>>(jsonString, _jsonOptions);

            if (apiResponse != null && apiResponse.Estado && apiResponse.Data != null)
            {
                return apiResponse.Data;
            }
            return new List<T>();
        }
        catch (Exception ex)
        {

            return new List<T>();
        }
    }


    /// <summary>
    /// Método genérico para hacer POST y devolver  T
    /// siguiendo el formato: { estado, data: [ ... ] }.
    /// </summary>
    public async Task<ApiCrudResponse> PostCrudAsync(string relativeUrl, Dictionary<string, string>? parameters = null)
    {

        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, relativeUrl);

            if (parameters != null && parameters.Count > 0)
            {
                request.Content = new FormUrlEncodedContent(parameters);
            }

            using var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return new ApiCrudResponse();
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            ApiCrudResponse? apiResponse =
                JsonSerializer.Deserialize<ApiCrudResponse>(jsonString, _jsonOptions);

            
          return apiResponse ?? new ApiCrudResponse();   
        }
        catch (Exception ex)
        {
            return new ApiCrudResponse() { Estado = false, Mensaje = ex.Message };
        }
    }
}
