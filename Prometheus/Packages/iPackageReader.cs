using Prometheus.Nodes;

namespace Prometheus.Packages
{
    /// <summary>
    /// The compiler will use this to read a source code file.
    /// </summary>
    public interface iPackageReader
    {
        ClassNameType ClassName();

        /// <summary>
        /// The full path to the file. This is used in error messages as a
        /// reference to the source code.
        /// </summary>
        string FileName();

        /// <summary>
        /// Read the source code for the compiler.
        /// </summary>
        /// <returns>The source code</returns>
        string Read();
    }
}