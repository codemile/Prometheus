using System;
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
        /// Wraps around another exception.
        /// </summary>
        public InternalErrorException(string pMessage, Location pLocation, Exception pInnerException)
            : base(pMessage, pLocation, pInnerException)
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