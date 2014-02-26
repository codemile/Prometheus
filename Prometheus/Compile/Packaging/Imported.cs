using System.Diagnostics;

namespace Prometheus.Compile.Packaging
{
    /// <summary>
    /// Describes the source code file used to compile an imported file.
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Imported
    {
        /// <summary>
        /// The full path to the file for this package.
        /// </summary>
        public readonly string FileName;

        /// <summary>
        /// The name of the package (as a relative path from the root package).
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Constructor
        /// </summary>
        public Imported(string pFileName, string pName)
        {
            FileName = pFileName;
            Name = pName;
        }
    }
}