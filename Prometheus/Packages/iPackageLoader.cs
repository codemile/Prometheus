using System;
using System.Collections.Generic;

namespace Prometheus.Packages
{
    /// <summary>
    /// Defines a loader used to find and load source code files.
    /// </summary>
    public interface iPackageLoader : IDisposable
    {
        /// <summary>
        /// The compiler will call this method when a package is required. If the path
        /// to a package is a directory, then return multiple readers for all files. If
        /// the path is to a specific file, then return one reader for that file.
        /// </summary>
        /// <param name="pPath">The path to the file, or the files in a package.</param>
        /// <returns>The package reader, or Null if not found</returns>
        IList<iPackageReader> Load(string pPath);
    }
}