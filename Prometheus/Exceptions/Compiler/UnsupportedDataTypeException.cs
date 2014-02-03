using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    /// <summary>
    /// </summary>
    public class UnsupportedDataTypeException : CompilerException
    {
        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        protected UnsupportedDataTypeException(string pMessage, Location pLocation, Exception pInnerException)
            : base(pMessage, pLocation, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public UnsupportedDataTypeException(string pMessage, Location pLocation) : base(pMessage, pLocation)
        {
        }
    }
}