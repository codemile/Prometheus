using Prometheus.Nodes.Types;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// Thrown to pass a return value from inside a function.
    /// </summary>
    public class ReturnException : RunTimeException
    {
        /// <summary>
        /// </summary>
        public readonly Data Value;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReturnException(Data pValue)
        {
            Value = pValue;
        }
    }
}