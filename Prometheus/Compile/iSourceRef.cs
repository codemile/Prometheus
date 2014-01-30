namespace Prometheus.Compile
{
    /// <summary>
    /// Used to lookup the file name of a source code reference from a node.
    /// </summary>
    public interface iSourceRef
    {
        /// <summary>
        /// The file name for the source code.
        /// </summary>
        /// <param name="pSource">The source ref number.</param>
        /// <returns>The file name</returns>
        string getFileName(int pSource);
    }
}