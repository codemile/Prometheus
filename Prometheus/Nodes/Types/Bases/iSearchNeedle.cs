namespace Prometheus.Nodes.Types.Bases
{
    /// <summary>
    /// Used by types that can be used to search for text.
    /// </summary>
    public interface iSearchNeedle
    {
        /// <summary>
        /// Is this term found in the haystack
        /// </summary>
        /// <param name="pHaystack">The string to search</param>
        /// <returns>True if found</returns>
        bool isFound(string pHaystack);
    }
}