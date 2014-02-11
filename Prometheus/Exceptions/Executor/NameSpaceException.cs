namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// NameSpace exceptions
    /// </summary>
    public class NameSpaceException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">Exception message</param>
        public NameSpaceException(string pMessage)
            : base(pMessage)
        {
        }
    }
}