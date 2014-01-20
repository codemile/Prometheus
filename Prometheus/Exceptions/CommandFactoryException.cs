using System;
using Markdown.Documents;

namespace Prometheus.Exceptions
{
    public class CommandFactoryException : ParserException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CommandFactoryException(DocumentCursor pCursor)
            : base("Unexpected command factory error", pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public CommandFactoryException(string pMessage, DocumentCursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public CommandFactoryException(string pMessage, DocumentCursor pCursor)
            : base(pMessage, pCursor)
        {
        }
    }
}