using System;

namespace Prometheus.Exceptions
{
    /// <summary>
    /// Base class for all exception.
    /// </summary>
    public abstract class PrometheusException : Exception
    {
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
        /// <param name="pInner">Inner exception</param>
        protected PrometheusException(string pMessage, Exception pInner)
            : base(pMessage, pInner)
        {
        }
    }
}