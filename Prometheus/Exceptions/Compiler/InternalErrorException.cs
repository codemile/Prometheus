using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    public class InternalErrorException : CompilerException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public InternalErrorException(Location pLocation)
            : base("Internal error", pLocation)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public InternalErrorException(string pMessage)
            : base(pMessage)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public InternalErrorException(string pMessage, Location pLocation)
            : base(pMessage, pLocation)
        {
        }
    }
}