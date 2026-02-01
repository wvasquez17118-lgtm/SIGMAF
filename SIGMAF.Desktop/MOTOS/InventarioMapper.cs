using SIGMAF.Desktop.Helpers;
using SIGMAF.Domain.MOTOS;
using System.Globalization;

namespace SIGMAF.Desktop.MOTOS
{
    public static class InventarioMapper
    {
        public static ListadoInventarioDTO ToVm(this ListadoInventarioDTO dto)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("es-NI"); // o es-ES / en-US según cómo lo querés ver

            var precioV = NumberHelper.ToDecimal(dto.PrecioVenta);
            var precioCom = NumberHelper.ToDecimal(dto.PrecioCompra);

            return new ListadoInventarioDTO
            {
                CantidadFmt = NumberHelper.ToLong(dto.StockDisponible),
                StockDisponible = dto.StockDisponible,
                StockMinimo = dto.StockMinimo,
                NombreProducto = dto.NombreProducto,
                InventarioStockId = dto.InventarioStockId,
                CatalogoId = dto.CatalogoId,
                PrecioCompraFmt = NumberHelper.ToMiles(precioCom, culture, decimals: 2),
                PrecioVentaFmt = NumberHelper.ToMiles(precioV, culture, decimals: 2),
            };
        }
    }
}
