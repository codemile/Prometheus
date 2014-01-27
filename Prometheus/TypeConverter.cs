using System;
using System.Globalization;

namespace Prometheus
{
    /// <summary>
    /// A central place to put code that converts between primitive types.
    /// </summary>
    public static class TypeConverter
    {
        /// <summary>
        /// Converts the object to a string.
        /// </summary>
        private static string getString(object pVal)
        {
            return pVal.ToString();
        }

        /// <summary>
        /// Attempts to convert to a boolean.
        /// </summary>
        public static bool getBool(object pVal)
        {
            string str = getString(pVal).Trim().ToLower();

            switch (str)
            {
                case "true":
                case "yes":
                case "on":
                case "1":
                case "always":
                    return true;

                case "false":
                case "no":
                case "off":
                case "0":
                case "never":
                    return false;
            }

            return getInt(pVal) != 0;
        }

        /// <summary>
        /// Attempts to convert the float value to an integer.
        /// </summary>
        public static int getInt(object pVal)
        {
            return (int)getPrecise(pVal);
        }

        /// <summary>
        /// Attempts to convert the string value to a double float.
        /// </summary>
        public static float getPrecise(object pVal)
        {
            // TODO: double and decimal might not be possible, but if they are
            //       the values won't convert consistently because of precision errors.
            if (pVal is int || pVal is float || pVal is double || pVal is decimal)
            {
                return (float)pVal;
            }

            const NumberStyles style = NumberStyles.Number |
                                       NumberStyles.AllowLeadingWhite |
                                       NumberStyles.AllowTrailingWhite |
                                       NumberStyles.AllowParentheses |
                                       NumberStyles.AllowCurrencySymbol |
                                       NumberStyles.AllowDecimalPoint |
                                       NumberStyles.AllowThousands |
                                       NumberStyles.AllowLeadingSign |
                                       NumberStyles.AllowExponent;

            float num;
            if (Single.TryParse(getString(pVal), style, CultureInfo.CurrentCulture, out num))
            {
                return num;
            }

            // TODO: Try replacing this with an exception once try/catch
            //       features have been added.
            return 0.0f;
        }
    }
}