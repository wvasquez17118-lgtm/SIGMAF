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

        public async Task<ApiCrudResponse> SincronizacionActualizarInventarioAsync(Dictionary<string, string> parameters)
        {
            return await services.PostCrudAsync("motoaplicarventasAinventarioporfecha", parameters);
        }

        public async Task<ApiCrudResponse> MotoActualizarInventarioProductoAsync(Dictionary<string, string> parameters)
        {
            return await services.PostCrudAsync("motoactualizarinventarioproducto", parameters);
        }

        public async Task<List<GanaciasMotoDTO>> MotoListarVentasPorRangoFechaGananciasAsync(Dictionary<string, string> parameters)
        {
            return await services.PostListAsync<GanaciasMotoDTO>("motolistarventasporrangofechaganancias", parameters);
        }

    }
}
