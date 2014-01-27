namespace Prometheus.Documents
{
    public class FragmentNotFoundException : FragmentException
    {
        public FragmentNotFoundException(string pName, DocumentCursor pCursor)
            : base(string.Format("Fragment {0} was not found.", pName), pCursor)
        {
        }
    }
}