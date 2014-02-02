using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    public class CommandFactoryException : CompilerException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CommandFactoryException(Location pLocation)
            : base("Unexpected command factory error", pLocation)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public CommandFactoryException(string pMessage, Location pLocation, Exception pInnerException)
            : base(pMessage, pLocation, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public CommandFactoryException(string pMessage, Location pLocation)
            : base(pMessage, pLocation)
        {
        }
    }
}