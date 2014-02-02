using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    public class EofException : CompilerException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public EofException(Location pLocation)
            : base("Unexpected end of file.", pLocation)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public EofException(string pMessage, Location pLocation, Exception pInnerException)
            : base(pMessage, pLocation, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public EofException(string pMessage, Location pLocation)
            : base(pMessage, pLocation)
        {
        }
    }
}