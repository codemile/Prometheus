using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Prometheus.Packages
{
    /// <summary>
    /// Treats subdirectories as the name of packages.
    /// </summary>
    public class DirectoryLoader : iPackageLoader
    {
        /// <summary>
        /// The root folder
        /// </summary>
        private readonly string _basePath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pPath"></param>
        public DirectoryLoader(string pPath)
        {
            _basePath = pPath;
        }

        /// <summary>
        /// The compiler will call this method when a package is required. If the path
        /// to a package is a directory, then return multiple readers for all files. If
        /// the path is to a specific file, then return one reader for that file.
        /// </summary>
        /// <param name="pPath">The path to the file, or the files in a package.</param>
        /// <returns>The package reader, or Null if not found</returns>
        public IList<iPackageReader> Load(string pPath)
        {
            string path = string.Format("{0}{1}{2}", _basePath, Path.DirectorySeparatorChar,
                pPath.Replace('.', Path.DirectorySeparatorChar));

            if (File.Exists(path + ".fire"))
            {
                return new iPackageReader[] {new FileReader(path + ".fire")};
            }
            if (Directory.Exists(path))
            {
                return
                    (from file in Directory.EnumerateFiles(path, "*.fire") 
                     select (iPackageReader)new FileReader(file))
                        .ToList();
            }
            return null;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}