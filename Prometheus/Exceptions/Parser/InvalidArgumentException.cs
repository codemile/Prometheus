using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prometheus.Nodes;

namespace Prometheus.Exceptions.Parser
{
    public class InvalidArgumentException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pNode">The node the error relates to</param>
        public InvalidArgumentException(string pMessage, Node pNode) : base(pMessage, pNode)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pInner">Inner exception</param>
        public InvalidArgumentException(string pMessage, Exception pInner) : base(pMessage, pInner)
        {
        }
    }
}
