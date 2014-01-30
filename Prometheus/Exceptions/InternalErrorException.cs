using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions
{
    public class InternalErrorException : CompilerException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public InternalErrorException(Cursor pCursor)
            : base("Internal error", pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public InternalErrorException(string pMessage, Cursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public InternalErrorException(string pMessage, Cursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}