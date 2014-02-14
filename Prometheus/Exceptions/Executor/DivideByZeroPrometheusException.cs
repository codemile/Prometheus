using System;

namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// </summary>
    public class DivideByZeroPrometheusException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        /// <param name="pInner">Inner exception</param>
        public DivideByZeroPrometheusException(string pMessage, Exception pInner)
            : base(pMessage, pInner)
        {
        }
    }
}