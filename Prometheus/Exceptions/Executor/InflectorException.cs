using Prometheus.Nodes;

namespace Prometheus.Exceptions.Executor
{
    public class InflectorException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        public InflectorException(string pMessage)
            : base(pMessage)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pNode">The node the error relates to</param>
        public InflectorException(string pMessage, Node pNode)
            : base(pMessage, pNode)
        {
        }
    }
}