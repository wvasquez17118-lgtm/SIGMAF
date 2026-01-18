using SIGMAF.Domain.MOTOS;

namespace SIGMAF.ApiClient.ApiRestMoto
{
    public class CompraServicio
    {
        ApiService services;
        public CompraServicio()
        {
            services = new ApiService();
        }
        public async Task<ApiCrudResponse> GuardarCompraRepuestoAsync(Dictionary<string, string> parameters)
        {
            return await services.PostCrudAsync("guardarcomprarepuesto", parameters);
        }

        public async Task<List<ComprasFacturasDTO>> MotoListarFacturasComprasAsync()
        {
            return await services.PostListAsync<ComprasFacturasDTO>("motolistarfacturascompras");
        }

        public async Task<CompraMaestroDetalleDTO?> ObtenerCompraMaestroDetallePorIdAsync(Dictionary<string, string> parameters)
        {
            return await services.PostAsync<CompraMaestroDetalleDTO>("Obtenercompramaestrodetalleporid",parameters);
        }
        public async Task<ApiCrudResponse> AplicarCompraFacturaAInventarioAsync(Dictionary<string, string> parameters)
        {
            return await services.PostCrudAsync("motoaplicarcompraainventario", parameters);
        }
        
        public async Task<ApiCrudResponse> GuardarVentaRepuestoAsync(Dictionary<string, string> parameters)
        {
            return await services.PostCrudAsync("motoguardarventa", parameters);
        }
    }
}
