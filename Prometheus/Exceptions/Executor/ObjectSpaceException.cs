using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prometheus.Exceptions.Executor
{
    public class ObjectSpaceException : RunTimeException
    {
        /// <summary>
        /// Formats the error message.
        /// </summary>
        private static string Format(string pMessage, object pRef)
        {
            return string.Format("{0} objects of type <{1}>", pMessage, pRef.GetType().FullName);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectSpaceException(string pMessage, object pRef)
            : base(Format(pMessage,pRef))
        {
            
        }
    }
}
