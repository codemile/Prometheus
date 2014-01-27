using System;
using Prometheus.Documents;

namespace Prometheus.Exceptions
{
    public class TypeNotFoundException : CompilerException
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
        public TypeNotFoundException(string pCommand, Cursor pCursor)
            : base(Message(pCommand), pCursor)
        {
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public TypeNotFoundException(string pCommand, Cursor pCursor, Exception pInnerException)
            : base(Message(pCommand), pCursor, pInnerException)
        {
        }
    }
}