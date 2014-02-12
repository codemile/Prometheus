namespace Prometheus.Nodes.Types.Bases
{
    /// <summary>
    /// Used by types that can be search targets
    /// </summary>
    public interface iSearchHaystack
    {
        /// <summary>
        /// Does this haystack contain the needle
        /// </summary>
        /// <param name="pNeedle">The needle to find</param>
        /// <returns>True</returns>
        bool Contains(iSearchNeedle pNeedle);
    }
}