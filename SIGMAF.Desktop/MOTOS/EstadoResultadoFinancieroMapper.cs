using SIGMAF.Desktop.Helpers;
using SIGMAF.Domain.MOTOS;
using System.Globalization;

namespace SIGMAF.Desktop.MOTOS
{
    public static class EstadoResultadoFinancieroMapper
    {
        public static CostoFijoEstadoResultadoDTO ToVm(this CostoFijoEstadoResultadoDTO dto)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("es-NI");
            decimal gastoFijo = NumberHelper.ToDecimal(dto.gasto_fijo);

            return new CostoFijoEstadoResultadoDTO
            {
                id = dto.id,
                nombre_gasto = dto.nombre_gasto,
                gasto_fijo = dto.gasto_fijo,
                estado = dto.estado,
                EsVariable = dto.EsVariable,
                GastoFijoFmt = gastoFijo,
                GastoFijoTexto = $"C$ {NumberHelper.ToMiles(gastoFijo, culture)}"
            };
        }
    }
}
