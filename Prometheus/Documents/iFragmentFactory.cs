using System.Collections.Generic;

namespace Prometheus.Documents
{
    /// <summary>
    /// Defines a factory that can divided the body of a document into
    /// multiple smaller fragments to narrow the scope of a search.
    /// </summary>
    public interface iFragmentFactory
    {
        /// <summary>
        /// The factory should divide the document into fragments of
        /// the given type.
        /// </summary>
        /// <param name="pType">The type of a fragment type.</param>
        /// <returns>The fragments or empty list.</returns>
        Fragment[] CreateFragments(string pType);

        /// <summary>
        /// Provide a unique list of names for each type of fragment. Try
        /// to use singular words as a fragment type. The names should
        /// include only alpha and underscore characters.
        /// Possible examples are "title","body","paragraph","sentence".
        /// </summary>
        /// <returns>A list of fragment names.</returns>
        IEnumerable<string> SupportedTypes();
    }
}