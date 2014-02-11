using System;
using System.Collections.Generic;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    /// <summary>
    /// The base exception for all compiler time errors.
    /// </summary>
    public class CompilerException : PrometheusException
    {
        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        protected CompilerException(string pMessage, Location pLocation, Exception pInnerException)
            : base(pMessage, pLocation, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public CompilerException(string pMessage, Location pLocation)
            : base(pMessage, pLocation)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        protected CompilerException(string pMessage)
            : base(pMessage)
        {
        }
    }
}