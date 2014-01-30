using System.Diagnostics;

namespace Prometheus.Compile
{
    /// <summary>
    /// Defines a source code file.
    /// </summary>
    [DebuggerDisplay("{FileName}")]
    public class TargetSource
    {
        /// <summary>
        /// The filename
        /// </summary>
        public readonly string FileName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pFileName">Source code file.</param>
        public TargetSource(string pFileName)
        {
            FileName = pFileName;
        }
    }
}