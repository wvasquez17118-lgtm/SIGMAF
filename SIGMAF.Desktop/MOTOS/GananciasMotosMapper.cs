using SIGMAF.Desktop.Helpers;
using SIGMAF.Domain.MOTOS;
using System.Globalization;
using System.Text.Json.Serialization;

namespace SIGMAF.Desktop.MOTOS
{
    public static class GananciasMotosMapper
    {
        public static GanaciasMotoDTO ToVm(this GanaciasMotoDTO dto)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("es-NI"); // o es-ES / en-US según cómo lo querés ver



            return new GanaciasMotoDTO
            {
                IdVenta = dto.IdVenta,
                IdCatalogoProducto = dto.IdCatalogoProducto,
                catalogo_id = dto.catalogo_id,
                nombre_catalogo = dto.nombre_catalogo,
                codigo_catalogo = dto.codigo_catalogo,
                Cantidad = dto.Cantidad,
                PrecioFmt = NumberHelper.ToDecimal(dto.Precio),
                PrecioCompraFmt = NumberHelper.ToDecimal(dto.PrecioCompra),
                CantidadFmt = NumberHelper.ToLong(dto.Cantidad),
                TotalFmt = NumberHelper.ToLong(dto.Total),
                PrecioVentaUnitFmt = NumberHelper.ToLong(dto.PrecioVentaUnit),
                GananciaUnitFmt = NumberHelper.ToLong(dto.GananciaUnit),
                GananciaTotalFmt = NumberHelper.ToLong(dto.GananciaTotal),
                Categoria = dto.Categoria,
                PrecioCompra = dto.PrecioCompra,
                PrecioVentaUnit = dto.PrecioVentaUnit,
                GananciaTotal = dto.GananciaTotal,
                GananciaUnit = dto.GananciaUnit,
            };
        }
    }
}
 
