using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos
{
    public static class Extensiones
    {
        public static IEnumerable<int> To(this int number, int numberTo)
        {
            for (int i = 0; i < numberTo ; i++)
            {
                yield return number + i;
            }
        }

        public static int ToInt(this string cadena)
        {
            int salida;
            if (int.TryParse(cadena, out salida)) return salida;
            return 0;
        }

        public static long ToLong(this string cadena)
        {
            long salida;
            if (long.TryParse(cadena, out salida)) return salida;
            return 0;
        }

    }
}
