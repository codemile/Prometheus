using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Prometheus.Documents
{
    /// <summary>
    /// Stores all the parts of a document and supports the factory interface.
    /// </summary>
    public class DocumentFactory : iFragmentFactory
    {
        /// <summary>
        /// A collection of fragments grouped by type.
        /// </summary>
        private readonly Dictionary<string, List<Fragment>> _fragments;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DocumentFactory()
        {
            _fragments = new Dictionary<string, List<Fragment>>();
        }

        /// <summary>
        /// All the supported types for this document.
        /// </summary>
        public IEnumerable<string> SupportedTypes()
        {
            return new List<string>(_fragments.Keys).ToArray();
        }

        /// <summary>
        /// Returns a collection of fragments of the given type.
        /// </summary>
        /// <param name="pType">The type to return.</param>
        /// <returns>Empty if none found by that type.</returns>
        public Fragment[] CreateFragments(string pType)
        {
            return _fragments.ContainsKey(pType) ? _fragments[pType].ToArray() : new Fragment[] {};
        }

        /// <summary>
        /// Attempts to remove unwanted characters and
        /// normalize whitespace.
        /// </summary>
        public static string Clean(string pStr)
        {
            pStr = pStr.Replace("\n", " "); // new lines
            pStr = pStr.Replace("\r", " "); // returns
            pStr = pStr.Replace("\t", " "); // tabs
            pStr = Regex.Replace(pStr, @"[\s]{2,}", " "); // remove 2 or more spaces
            return pStr.Trim();
        }

        /// <summary>
        /// Adds a fragment to the document.
        /// </summary>
        public void Add(Fragment pFrag)
        {
            if (!_fragments.ContainsKey(pFrag.Type))
            {
                _fragments.Add(pFrag.Type, new List<Fragment>());
            }
            _fragments[pFrag.Type].Add(pFrag);
        }

        /// <summary>
        /// How many fragments of the given type this document has.
        /// </summary>
        public int Count(string pType)
        {
            return _fragments.ContainsKey(pType) ? _fragments[pType].Count : 0;
        }
    }
}