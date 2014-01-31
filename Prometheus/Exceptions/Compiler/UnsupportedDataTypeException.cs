using System;
using Prometheus.Compile;

namespace Prometheus.Exceptions.Compiler
{
    /// <summary>
    /// 
    /// </summary>
    public class UnsupportedDataTypeException : CompilerException
    {
        /// <summary>
        /// Wraps around another exception.
        /// </summary>
        protected UnsupportedDataTypeException(string pMessage, Cursor pCursor, Exception pInnerException)
            : base(pMessage, pCursor, pInnerException)
        {
        }

        /// <summary>
        /// Throw a message.
        /// </summary>
        public UnsupportedDataTypeException(string pMessage, Cursor pCursor) : base(pMessage, pCursor)
        {
        }
    }
}