namespace Prometheus.Exceptions.Executor
{
    /// <summary>
    /// A rethrowable exception related to an identifier.
    /// </summary>
    public class IdentifierInnerException : RunTimeException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public IdentifierInnerException(string pMessage)
            : base(pMessage)
        {
        }
    }
}