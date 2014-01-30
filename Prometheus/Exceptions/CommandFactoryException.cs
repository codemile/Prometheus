using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions
{
    public class CommandFactoryException : CompilerException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CommandFactoryException(Cursor pCursor)
            : base("Unexpected command factory error", pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public CommandFactoryException(string pMessage, Cursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public CommandFactoryException(string pMessage, Cursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}