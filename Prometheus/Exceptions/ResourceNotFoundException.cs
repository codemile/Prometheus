using Prometheus.Documents;

namespace Prometheus.Exceptions
{
    public class ResourceNotFoundException : ParserException
    {
        /// <summary>
        /// Throws an error when a path in the DLL is not found.
        /// </summary>
        public ResourceNotFoundException(string pResourcePath)
            : base(string.Format("Resource was not found: {0}", pResourcePath), DocumentCursor.None)
        {
        }
    }
}