using System;
using Prometheus.Nodes;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// A symbol has no code associated with it.
    /// </summary>
    public class AssertionException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pNode">The node the error relates to</param>
        public AssertionException(string pMessage, Node pNode) : base(pMessage, pNode)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pInner">Inner exception</param>
        public AssertionException(string pMessage, Exception pInner) : base(pMessage, pInner)
        {
        }
    }
}