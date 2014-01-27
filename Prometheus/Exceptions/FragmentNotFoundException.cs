using Prometheus.Documents;

namespace Prometheus.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class FragmentNotFoundException : ParserException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pCursor"></param>
        public FragmentNotFoundException(string pName, DocumentCursor pCursor)
            : base(string.Format("Fragment {0} was not found.", pName), pCursor)
        {
        }
    }
}