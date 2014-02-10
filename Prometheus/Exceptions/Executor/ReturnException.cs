using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// Thrown to pass a return value from inside a function.
    /// </summary>
    public class ReturnException : RunTimeException
    {
        /// <summary>
        /// </summary>
        public readonly iDataType Value;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReturnException(iDataType pValue)
        {
            Value = pValue;
        }
    }
}