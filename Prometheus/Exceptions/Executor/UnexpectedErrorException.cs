using System;
using Prometheus.Nodes;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// Something in the parser was unexpected.
    /// </summary>
    public class UnexpectedErrorException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pNode">The node the error relates to</param>
        public UnexpectedErrorException(string pMessage, Node pNode) : base(pMessage, pNode)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pInner">Inner exception</param>
        public UnexpectedErrorException(string pMessage, Exception pInner) : base(pMessage, pInner)
        {
        }
    }
}