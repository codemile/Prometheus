using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    public class PackageNotFoundException : CompilerException
    {
        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public PackageNotFoundException(string pMessage, Location pLocation, Exception pInnerException)
            : base(pMessage, pLocation, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public PackageNotFoundException(string pMessage, Location pLocation) 
            : base(pMessage, pLocation)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public PackageNotFoundException(string pMessage) 
            : base(pMessage)
        {
        }
    }
}