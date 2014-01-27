using System;
using Prometheus.Documents;

namespace Prometheus.Exceptions
{
    public class InternalErrorException : ParserException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public InternalErrorException(DocumentCursor pCursor)
            : base("Internal error", pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public InternalErrorException(string pMessage, DocumentCursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public InternalErrorException(string pMessage, DocumentCursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}