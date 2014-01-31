using System;

namespace Prometheus.Nodes
{
    /// <summary>
    /// Handles type juggling at run-time. The engine only supports two types of
    /// numeric types "long" and "double".
    /// </summary>
    public static class DataConverter
    {
        /// <summary>
        /// Inspects the two data objects to see what numeric type
        /// both objects can be converted without loosing precision.
        /// During type juggling where the type is not a compatible
        /// numeric type a long type will be used.
        /// </summary>
        /// <param name="pType1">First data</param>
        /// <param name="pType2">Second data</param>
        /// <returns>The best numeric type</returns>
        public static Type BestNumericType(Type pType1, Type pType2)
        {
            pType1 = (pType1 == typeof (double) || pType1 == typeof (long)) ? pType1 : typeof (long);
            if (pType1 == pType2)
            {
                return pType1;
            }

            pType2 = (pType2 == typeof (double) || pType2 == typeof (long)) ? pType2 : typeof (long);
            if (pType1 == pType2)
            {
                return pType1;
            }

            if (pType1 == typeof (double) || pType2 == typeof (double))
            {
                return typeof (double);
            }

            return typeof (long);
        }
    }
}