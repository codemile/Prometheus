using System.Collections.Generic;

namespace Prometheus.Documents
{
    /// <summary>
    /// A wrapper class that caches requests to look up fragments in a document. This
    /// improves performance by not having to always use the fragment factory.
    /// </summary>
    public class DocumentCache : iDocument
    {
        /// <summary>
        /// A cache of fragments created by the factory.
        /// </summary>
        private readonly Dictionary<string, Fragment[]> _fragmentCache;

        /// <summary>
        /// The document that will do the creating.
        /// </summary>
        private readonly iDocument _innerDocument;

        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentCache(iDocument pInnerDocument)
        {
            _innerDocument = pInnerDocument;
            _fragmentCache = new Dictionary<string, Fragment[]>();
        }

        /// <summary>
        /// Builds a list of text fragments for a specific scope. This method is optimized
        /// to store types in a memory cache for faster retrieval.
        /// </summary>
        public Fragment[] getFragments(string pType, DocumentCursor pCursor)
        {
            if (!_fragmentCache.ContainsKey(pType))
            {
                _fragmentCache.Add(pType, _innerDocument.getFragments(pType, pCursor));
            }
            return _fragmentCache[pType];
        }
    }
}