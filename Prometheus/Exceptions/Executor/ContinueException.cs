using Prometheus.Nodes;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// Used to continue loops
    /// </summary>
    public class ContinueException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ContinueException(Node pNode)
            : base("continue", pNode)
        {
        }
    }
}