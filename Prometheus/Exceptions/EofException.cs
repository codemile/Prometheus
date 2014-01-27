using System;
using Prometheus.Documents;

namespace Prometheus.Exceptions
{
    public class EofException : ParserException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public EofException(DocumentCursor pCursor)
            : base("Unexpected end of file.", pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public EofException(string pMessage, DocumentCursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public EofException(string pMessage, DocumentCursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}