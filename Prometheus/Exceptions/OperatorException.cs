using System;
using Markdown.Documents;

namespace Prometheus.Exceptions
{
    public class OperatorException : ParserException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public OperatorException(DocumentCursor pCursor)
            : base("Operator error", pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public OperatorException(string pMessage, DocumentCursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public OperatorException(string pMessage, DocumentCursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}