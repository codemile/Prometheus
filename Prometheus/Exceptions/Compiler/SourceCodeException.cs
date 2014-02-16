namespace Prometheus.Exceptions.Compiler
{
    public class SourceCodeException : CompilerException
    {
        /// <summary>
        /// Throw a message.
        /// </summary>
        public SourceCodeException(string pMessage)
            : base(pMessage)
        {
        }
    }
}