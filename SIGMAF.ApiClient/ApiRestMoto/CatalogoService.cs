using SIGMAF.Domain.MOTOS;

namespace SIGMAF.ApiClient.ApiRestMoto
{
    public class CatalogoService
    {
        ApiService services;
        public CatalogoService ()
        {
            services = new ApiService();
        }
        public async Task<List<CatalogoModel>> ObtenerCatalogoAsync()
        {
            return await services.PostListAsync<CatalogoModel>("listarcatalogomoto");
        }

        public  async Task<ApiCrudResponse> GuardarCatalogoAsync(Dictionary<string, string> parameters)
        {
            return await services.PostCrudAsync("motoguardarcatalogo", parameters);
        }
    }
}
