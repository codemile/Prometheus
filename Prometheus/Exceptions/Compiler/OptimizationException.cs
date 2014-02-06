using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    public class OptimizationException : CompilerException
    {
        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        protected OptimizationException(string pMessage, Location pLocation, Exception pInnerException)
            : base(pMessage, pLocation, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public OptimizationException(string pMessage, Location pLocation)
            : base(pMessage, pLocation)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public OptimizationException(string pMessage)
            : base(pMessage)
        {
        }
    }
}