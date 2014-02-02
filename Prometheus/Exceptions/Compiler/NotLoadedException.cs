using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    public class NotLoadedException : CompilerException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public NotLoadedException(Location pLocation)
            : base("Parser table is not loaded.", pLocation)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public NotLoadedException(string pMessage, Location pLocation, Exception pInnerException)
            : base(pMessage, pLocation, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public NotLoadedException(string pMessage, Location pLocation)
            : base(pMessage, pLocation)
        {
        }
    }
}