using System;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes
{
    /// <summary>
    /// Handles type juggling at run-time. The engine only supports two types of
    /// numeric types "long" and "double".
    /// </summary>
    public static class DataTypeConverter
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
            Type t1 = (pType1 == typeof (UndefinedType)) ? DataType.Precise : pType1;
            Type t2 = (pType2 == typeof (UndefinedType)) ? DataType.Precise : pType2;

            t1 = (t1 == DataType.Precise || t1 == DataType.Integer) ? t1 : DataType.Integer;

            if (t1 == t2)
            {
                return t1;
            }

            t2 = (t2 == DataType.Precise || t2 == DataType.Integer) ? t2 : DataType.Integer;

            if (t1 == t2)
            {
                return t1;
            }

            if (t1 == DataType.Precise || t2 == DataType.Precise)
            {
                return DataType.Precise;
            }

            return DataType.Integer;
        }
    }
}