using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions.Executor;

namespace Prometheus.Nodes.Types.Bases
{
    /// <summary>
    /// The data for a node.
    /// </summary>
    public abstract class DataType
    {
        /// <summary>
        /// Returns an array type. Creating a new type if required.
        /// </summary>
        /// <returns>An array collection</returns>
        private IEnumerable<DataType> ToArray()
        {
            return (GetType() == typeof (ArrayType))
                ? (ArrayType)this
                : new ArrayType(this);
        }

        /// <summary>
        /// </summary>
        /// <param name="pHaystack"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToArray<T>(DataType pHaystack) where T : DataType
        {
            IEnumerable<DataType> items = pHaystack.ToArray();
            return from item in items select item.Cast<T>();
        }

        /// <summary>
        /// Creates a new copy of the data.
        /// </summary>
        public virtual DataType Clone()
        {
            return this;
        }

        /// <summary>
        /// Casts to a required type.
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        /// <returns>The result</returns>
        public T Cast<T>() where T : DataType
        {
            T item = this as T;
            if (item == null)
            {
                throw DataTypeException.InvalidTypes(string.Format("Cast<{0}>", typeof (T).Name), this);
            }
            return item;
        }

        /// <summary>
        /// Attempts to convert this type to boolean.
        /// </summary>
        /// <returns>Boolean value</returns>
        public bool getBool()
        {
            if (GetType() == typeof (BooleanType))
            {
                return ((BooleanType)this).Value;
            }
            if (GetType() == typeof (NumericType))
            {
                NumericType num = (NumericType)this;
                if (num.Type == typeof (long))
                {
                    return (long)num.Value != 0;
                }
            }

            throw new DataTypeException(string.Format("Cannot convert <{0}> to boolean", GetType().FullName));
        }
    }
}