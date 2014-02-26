using Prometheus.Nodes;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// Used to break out of loops
    /// </summary>
    public class BreakException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BreakException(Node pNode)
            : base("break", pNode)
        {
        }
    }
}