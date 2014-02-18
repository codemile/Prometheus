using System;
using System.IO;

namespace Prometheus.Packages
{
    /// <summary>
    /// The compiler will use this to read a source code file.
    /// </summary>
    public interface iPackageReader
    {
        /// <summary>
        /// The full path to the file. This is used in error messages as a
        /// reference to the source code.
        /// </summary>
        string FileName();

        /// <summary>
        /// The text reader will feed the source code to the compiler.
        /// </summary>
        /// <returns>A reader object</returns>
        TextReader CreateReader();
    }
}