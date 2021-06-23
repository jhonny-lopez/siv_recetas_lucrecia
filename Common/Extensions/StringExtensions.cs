using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        //public static int ToInt(this string value, int defaultValue = 0)
        //{
        //    int retValue = defaultValue;

        //    bool wasParsed = int.TryParse(value, out retValue);

        //    if (wasParsed)
        //    {
        //        return retValue;
        //    }

        //    return defaultValue;
        //}

        public static int ToInt(this string value, bool throwsException = false, int defaultValue = 0)
        {
            int retValue = defaultValue;

            bool wasParsed = int.TryParse(value, out retValue);

            if (!wasParsed && throwsException)
            {
                throw new ArgumentException("No se pudo convertir a entero");
            }
            else if (!wasParsed)
            {
                return defaultValue;
            }

            return retValue;
        }

        public static string RemoveAllWhiteSpaces(this string value)
        {
            if (value == null)
            {
                return "";
            }

            return value.Replace(" ", "");
        }

        public static double ToDouble(this string value, double defaultValue = 0)
        {
            double retValue = defaultValue;

            bool wasParsed = double.TryParse(value, out retValue);

            if (wasParsed)
            {
                return retValue;
            }

            return defaultValue;
        }
    }
}
