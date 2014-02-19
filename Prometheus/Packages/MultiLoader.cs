using System.Collections.Generic;
using System.Linq;
using Prometheus.Nodes;

namespace Prometheus.Packages
{
    /// <summary>
    /// A collection of package loaders. The loaders will be called in the ordered
    /// they appear in the list until one returns a package reader. This can be
    /// used to load packages from different locations.
    /// </summary>
    public class MultiLoader : List<iPackageLoader>, iPackageLoader
    {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Clear();
        }

        /// <summary>
        /// The compiler will call this method when a package is required. If the path
        /// to a package is a directory, then return multiple readers for all files. If
        /// the path is to a specific file, then return one reader for that file.
        /// </summary>
        /// <param name="pClassName">The path to the file, or the files in a package.</param>
        /// <returns>The package reader, or Null if not found</returns>
        public IList<iPackageReader> Load(ClassNameType pClassName)
        {
            return this.Select(pLoader=>pLoader.Load(pClassName)).FirstOrDefault(pReaders=>pReaders != null);
        }
    }
}