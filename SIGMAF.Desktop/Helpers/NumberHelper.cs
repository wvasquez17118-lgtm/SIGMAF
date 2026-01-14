using System.Globalization;

namespace SIGMAF.Desktop.Helpers
{
   

    public static class NumberHelper
    {
        public static long ToLong(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;

            value = value.Trim();

            // intenta directo
            if (long.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var l))
                return l;

            // por si viene con separadores
            if (long.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("es-NI"), out l))
                return l;

            if (long.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("es-ES"), out l))
                return l;

            if (long.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out l))
                return l;

            // último recurso: si trae decimales, lo pasamos a decimal y truncamos
            var d = ToDecimal(value);
            return (long)d;
        }

        public static decimal ToDecimal(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0m;

            value = value.Trim();

            // limpia símbolos comunes (C$, $, espacios raros)
            value = value.Replace("C$", "", StringComparison.OrdinalIgnoreCase)
                         .Replace("$", "")
                         .Replace(" ", "")
                         .Trim();

            // 1) intentos “normales” por culturas
            var styles = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var cultures = new[]
            {
            CultureInfo.GetCultureInfo("es-NI"),
            CultureInfo.GetCultureInfo("es-ES"),
            CultureInfo.GetCultureInfo("en-US"),
            CultureInfo.InvariantCulture
        };

            foreach (var ci in cultures)
                if (decimal.TryParse(value, styles, ci, out var ok))
                    return ok;

            // 2) normalización manual (detecta separador decimal por el último '.' o ',')
            var normalized = NormalizeNumber(value);
            if (decimal.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out var d))
                return d;

            return 0m;
        }

        public static string ToMiles(decimal value, CultureInfo culture, int decimals = 2)
            => value.ToString(decimals == 0 ? "N0" : "N2", culture);

        private static string NormalizeNumber(string s)
        {
            // Si tiene '.' y ',' => el último que aparezca es el decimal; el otro es miles
            int lastDot = s.LastIndexOf('.');
            int lastComma = s.LastIndexOf(',');

            if (lastDot >= 0 && lastComma >= 0)
            {
                char decimalSep = lastDot > lastComma ? '.' : ',';
                char thousandSep = decimalSep == '.' ? ',' : '.';

                s = s.Replace(thousandSep.ToString(), "");
                s = s.Replace(decimalSep, '.'); // a Invariant
                return s;
            }

            // Solo uno de los dos
            if (lastComma >= 0)
            {
                // si parece decimal (2 dígitos al final), coma = decimal; si no, coma = miles
                int digitsAfter = s.Length - lastComma - 1;
                if (digitsAfter is 1 or 2)
                    return s.Replace(".", "").Replace(',', '.');
                return s.Replace(",", "");
            }

            if (lastDot >= 0)
            {
                int digitsAfter = s.Length - lastDot - 1;
                if (digitsAfter is 1 or 2)
                    return s.Replace(",", "");
                return s.Replace(".", "");
            }

            return s;
        }
    }

}
