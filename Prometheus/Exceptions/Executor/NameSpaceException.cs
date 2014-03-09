using Prometheus.Nodes;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// NameSpace exceptions
    /// </summary>
    public class NameSpaceException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NameSpaceException(string pMessage)
            : base(pMessage)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public NameSpaceException(string pMessage, Node pNode)
            : base(pMessage, pNode)
        {
        }
    }
}