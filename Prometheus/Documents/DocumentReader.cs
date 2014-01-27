using System.Collections.Generic;

namespace Prometheus.Documents
{
    /// <summary>
    /// This is a document that uses a fragment factory.
    /// </summary>
    public class DocumentReader : iDocument
    {
        /// <summary>
        /// The factory used to get text to search.
        /// </summary>
        private readonly iFragmentFactory _factory;

        /// <summary>
        /// A list of fragment types.
        /// </summary>
        private readonly List<string> _types;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pFactory">The factory used for fragments</param>
        public DocumentReader(iFragmentFactory pFactory)
        {
            _types = new List<string>(pFactory.SupportedTypes());
            _factory = pFactory;
        }

        /// <summary>
        /// Builds a list of text fragments for a specific scope.
        /// </summary>
        public Fragment[] getFragments(string pType, DocumentCursor pCursor)
        {
            if (!_types.Contains(pType))
            {
                throw new FragmentNotFoundException(pType, pCursor);
            }

            return _factory.CreateFragments(pType);
        }
    }
}