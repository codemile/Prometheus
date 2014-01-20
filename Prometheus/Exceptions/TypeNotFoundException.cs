using System;
using Markdown.Documents;

namespace Prometheus.Exceptions
{
    public class TypeNotFoundException : ParserException
    {
        /// <summary>
        /// Formats the message.
        /// </summary>
        private static string Message(string pClass)
        {
            return string.Format("Class type for statement not found: {0}", pClass);
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public TypeNotFoundException(string pCommand, DocumentCursor pCursor)
            : base(Message(pCommand), pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public TypeNotFoundException(string pCommand, DocumentCursor pCursor, Exception pInnerException)
            : base(Message(pCommand), pCursor, pInnerException)
        {
        }
    }
}