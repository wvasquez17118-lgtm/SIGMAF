using SIGMAF.Domain.MOTOS;

namespace SIGMAF.ApiClient.ApiRestMoto
{
    public class InventarioServicio
    {
        ApiService services;
        public InventarioServicio()
        {
            services = new ApiService();
        }
        public async Task<List<ListadoInventarioDTO>> ObtenercatalogosconinventariomotoAsync()
        {
            return await services.PostListAsync<ListadoInventarioDTO>("obtenercatalogosconinventariomoto");
        }
    }
}
