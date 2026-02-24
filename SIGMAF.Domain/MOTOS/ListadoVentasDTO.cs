namespace SIGMAF.Domain.MOTOS
{
    public class ListadoVentasDTO
    {
        public string IdVenta { get; set; } = string.Empty;
        public string IdCatalogoProducto { get; set; } = string.Empty;
        public string NombreProducto { get; set; } = string.Empty;
        public string Cantidad { get; set; } = string.Empty;
        public string Precio { get; set; } = string.Empty;
        public string Total { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string DescripcionEliminado { get; set; } = string.Empty;
        public string FechaCreacion { get; set; } = string.Empty;
        public string  EstadoAplicado {  get; set; } = string.Empty;
        public string Sucursal {  get; set; } = string.Empty;
        public string NombreSucursal => Sucursal == "1" ? "Altalier" : "Wama";

    }
}
