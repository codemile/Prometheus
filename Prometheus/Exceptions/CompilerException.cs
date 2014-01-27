using System;
using Prometheus.Documents;

namespace Prometheus.Exceptions
{
    /// <summary>
    /// The base exception for all parsing errors.
    /// </summary>
    public class CompilerException : Exception
    {
        /// <summary>
        /// Formats the message.
        /// </summary>
        private static string Format(string pMessage, Cursor pCursor)
        {
            return string.Format("{0} {1}", pMessage, pCursor);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompilerException(Cursor pCursor)
            : base(Format("Unhandled error", pCursor))
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public CompilerException(string pMessage, Cursor pCursor, Exception pInnerException)
            : base(Format(pMessage, pCursor), pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public CompilerException(string pMessage, Cursor pCursor)
            : base(Format(pMessage, pCursor))
        {
        }
    }
}