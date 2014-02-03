using Prometheus.Nodes;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// A rethrowable exception related to an identifier.
    /// </summary>
    public class IdentifierException : RunTimeException
    {
        /// <summary>
        /// The reference ID that is undefined
        /// </summary>
        private readonly string _identifier;

        /// <summary>
        /// The message to format
        /// </summary>
        private readonly string _message;

        /// <summary>
        /// Constructor
        /// </summary>
        public IdentifierException(string pMessage, string pIdentifier)
        {
            _identifier = pIdentifier;
            _message = pMessage;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public IdentifierException(string pMessage, Node pNode)
            : base(pMessage, pNode)
        {
        }

        /// <summary>
        /// Rethrows the exception using a node to add a reference to source code location.
        /// </summary>
        /// <param name="pException"></param>
        /// <param name="pNode"></param>
        public static void Rethrow(IdentifierException pException, Node pNode)
        {
            throw new IdentifierException(string.Format(pException._message, pException._identifier), pNode);
        }
    }
}