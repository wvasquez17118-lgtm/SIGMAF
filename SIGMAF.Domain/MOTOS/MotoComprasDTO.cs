namespace SIGMAF.Domain.MOTOS
{
    public class MotoComprasDTO
    {
        public long CompraId { get; set; }
        public DateTime Fecha {  get; set; }  
        public int ProveedorId { get; set; }
        public string TipoFactura { get; set; } = string.Empty;
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public string Observacion { get; set; } = string.Empty;
        public int Estado { get; set; }
    }
}
