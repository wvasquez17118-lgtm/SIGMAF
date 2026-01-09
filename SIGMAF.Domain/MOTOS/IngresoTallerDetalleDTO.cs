namespace SIGMAF.Domain.MOTOS
{
    public class IngresoTallerDetalleDTO
    {
        public long CompraDetalleId { get; set; }
        public long CompraId { get; set; }
        public int CatalogoId { get; set; }
        public string Producto {  get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioCompra {  get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
