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
        public readonly DataType Value;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReturnException(DataType pValue)
        {
            Value = pValue;
        }
    }
}