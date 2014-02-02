using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    public class OperatorException : CompilerException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public OperatorException(Location pLocation)
            : base("Operator error", pLocation)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public OperatorException(string pMessage, Location pLocation, Exception pInnerException)
            : base(pMessage, pLocation, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public OperatorException(string pMessage, Location pLocation)
            : base(pMessage, pLocation)
        {
        }
    }
}