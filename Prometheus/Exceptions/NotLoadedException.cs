using System;
using Prometheus.Documents;

namespace Prometheus.Exceptions
{
    public class NotLoadedException : ParserException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public NotLoadedException(DocumentCursor pCursor)
            : base("Parser table is not loaded.", pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public NotLoadedException(string pMessage, DocumentCursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public NotLoadedException(string pMessage, DocumentCursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}