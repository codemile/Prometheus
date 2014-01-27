using System;

namespace Prometheus.Documents
{
    public class FragmentException : Exception
    {
        /// <summary>
        /// Formats the message.
        /// </summary>
        private static string Format(string pMessage, DocumentCursor pCursor)
        {
            return string.Format("{0} {1}", pMessage, pCursor);
        }

        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        public FragmentException(string pMessage, DocumentCursor pCursor, Exception pInnerException)
            : base(Format(pMessage, pCursor), pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public FragmentException(string pMessage, DocumentCursor pCursor)
            : base(Format(pMessage, pCursor))
        {
        }
    }
}