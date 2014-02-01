using Prometheus.Nodes;

namespace Prometheus.Exceptions.Parser
{
    /// <summary>
    /// x is not defined error.
    /// </summary>
    public class UndefinedException : RunTimeException
    {
        /// <summary>
        /// The reference ID that is undefined
        /// </summary>
        public string Identifier;

        /// <summary>
        /// Constructor
        /// </summary>
        public UndefinedException(string pIdentifier)
            : base(string.Format("Reference error: {0} is not defined", pIdentifier))
        {
            Identifier = pIdentifier;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public UndefinedException(string pIdentifier, Node pNode)
            : base(string.Format("Reference error: {0} is not defined {1}", pIdentifier, pNode.Location))
        {
            Identifier = pIdentifier;
        }
    }
}