using SIGMAF.Desktop.Helpers;
using SIGMAF.Domain.MOTOS;
using System.Globalization;

namespace SIGMAF.Desktop.MOTOS
{
    public static class CompraFacturaMapper
    {
        public static ComprasFacturasDTO ToVm(this ComprasFacturasDTO dto, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.GetCultureInfo("es-NI"); // o es-ES / en-US según cómo lo querés ver

            var total = NumberHelper.ToDecimal(dto.Total);
            var sub = NumberHelper.ToDecimal(dto.SubTotal);
            var desc = NumberHelper.ToDecimal(dto.Descuento);

            return new ComprasFacturasDTO
            {
                CompraIdFmt = NumberHelper.ToLong(dto.CompraId),
                FechaFactura = dto.FechaFactura,
                EstadoProceso = dto.EstadoProceso ?? string.Empty,

            

                Proveedor = dto.Proveedor ?? string.Empty,
                TipoFactura = dto.TipoFactura ?? string.Empty,

                TotalFmt = NumberHelper.ToMiles(total, culture, decimals: 2),
                SubTotalFmt = NumberHelper.ToMiles(sub, culture, decimals: 2),
                DescuentoFmt = NumberHelper.ToMiles(desc, culture, decimals: 2),
            };
        }
    }
}
