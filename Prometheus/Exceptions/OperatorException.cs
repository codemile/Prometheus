using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions
{
    public class OperatorException : CompilerException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public OperatorException(Cursor pCursor)
            : base("Operator error", pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public OperatorException(string pMessage, Cursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public OperatorException(string pMessage, Cursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}