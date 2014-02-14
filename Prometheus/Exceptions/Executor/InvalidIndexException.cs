using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// Invalid access to an array
    /// </summary>
    public class InvalidIndexException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InvalidIndexException(string pMessage)
            : base(pMessage)
        {
        }
    }
}
