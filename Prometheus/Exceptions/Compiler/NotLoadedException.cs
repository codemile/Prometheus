using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    public class NotLoadedException : CompilerException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public NotLoadedException(Cursor pCursor)
            : base("Parser table is not loaded.", pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public NotLoadedException(string pMessage, Cursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public NotLoadedException(string pMessage, Cursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}