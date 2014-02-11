using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prometheus.Nodes;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// Runtime Type errors.
    /// </summary>
    public class DataTypeException : RunTimeException
    {
        /// <summary>
        /// Generates an error for incompatible types.
        /// </summary>
        public static DataTypeException InvalidTypes(string pOperator, DataType pValue1, DataType pValue2)
        {
            return new DataTypeException(string.Format("Cannot apply operator '{0}' to operands of type '{1}' and '{2}'", pOperator, pValue1.GetType().Name, pValue2.GetType().Name));
        }

        /// <summary>
        /// Generates an error for incompatible types.
        /// </summary>
        public static DataTypeException InvalidTypes(string pOperator, DataType pValue)
        {
            return new DataTypeException(string.Format("Cannot apply operator '{0}' to operand of type '{1}'", pOperator, pValue.GetType().Name));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        public DataTypeException(string pMessage)
            : base(pMessage)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pNode">The node the error relates to</param>
        public DataTypeException(string pMessage, Node pNode)
            : base(pMessage, pNode)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pInner">Inner exception</param>
        public DataTypeException(string pMessage, Exception pInner)
            : base(pMessage, pInner)
        {
        }
    }
}
