using System;
using Markdown.Documents;

namespace Prometheus.Exceptions
{
    /// <summary>
    /// The base exception for all parsing errors.
    /// </summary>
    public class ParserException : Exception
    {
        /// <summary>
        /// Formats the message.
        /// </summary>
        private static string Format(string pMessage, DocumentCursor pCursor)
        {
            return string.Format("{0} {1}", pMessage, pCursor);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ParserException(DocumentCursor pCursor)
            : base(Format("Unhandled error", pCursor))
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public ParserException(string pMessage, DocumentCursor pCursor, Exception pInnerException)
            : base(Format(pMessage, pCursor), pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public ParserException(string pMessage, DocumentCursor pCursor)
            : base(Format(pMessage, pCursor))
        {
        }
    }
}