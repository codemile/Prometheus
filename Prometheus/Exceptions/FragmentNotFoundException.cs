using Prometheus.Compile;

namespace Prometheus.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class FragmentNotFoundException : CompilerException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pCursor"></param>
        public FragmentNotFoundException(string pName, Cursor pCursor)
            : base(string.Format("Fragment {0} was not found.", pName), pCursor)
        {
        }
    }
}