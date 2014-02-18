using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    public class PackageErrorException : CompilerException
    {
        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public PackageErrorException(string pMessage, Location pLocation, Exception pInnerException)
            : base(pMessage, pLocation, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public PackageErrorException(string pMessage, Location pLocation) 
            : base(pMessage, pLocation)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public PackageErrorException(string pMessage) 
            : base(pMessage)
        {
        }
    }
}