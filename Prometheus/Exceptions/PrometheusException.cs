using System;
using System.Collections.Generic;
using Prometheus.Compile;

namespace Prometheus.Exceptions
{
    /// <summary>
    /// Base class for all exception.
    /// </summary>
    public abstract class PrometheusException : Exception
    {
        /// <summary>
        /// Where in the source code the error happen.
        /// </summary>
        public Location Where;

        /// <summary>
        /// Constructor
        /// </summary>
        protected PrometheusException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        protected PrometheusException(string pMessage)
            : base(pMessage)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pLocation">Where in the source code</param>
        protected PrometheusException(string pMessage, Location pLocation)
            : base(pMessage)
        {
            Where = pLocation;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pInner">Inner exception</param>
        protected PrometheusException(string pMessage, Exception pInner)
            : base(pMessage, pInner)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pLocation">Where in the source code</param>
        /// <param name="pInner">Inner exception</param>
        protected PrometheusException(string pMessage, Location pLocation, Exception pInner)
            : base(pMessage, pInner)
        {
            Where = pLocation;
        }

        /// <summary>
        /// Formats the message.
        /// </summary>
        public string Format()
        {
            if (Where == null)
            {
                return Message;
            }

            List<string> message = new List<string>
                                   {
                                       string.Format("{0} {1}", Message, Where),
                                       "",
                                       Where.Line,
                                       "^".PadLeft(Where.Column)
                                   };

            return string.Join(Environment.NewLine, message);
        }
    }
}