using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Prometheus.Nodes;

namespace Prometheus.Packages
{
    /// <summary>
    /// A loader that points to a directory that acts like a package.
    /// </summary>
    public class DirectoryLoader : iPackageLoader
    {
        private readonly iPackageReaderFactory _factory;

        /// <summary>
        /// The directory
        /// </summary>
        public readonly string Directory;

        /// <summary>
        /// The name of the package.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Constructor
        /// </summary>
        public DirectoryLoader(iPackageReaderFactory pFactory, string pDirectory)
        {
            _factory = pFactory;
            int last = pDirectory.LastIndexOf(Path.DirectorySeparatorChar);
            Directory = pDirectory.Substring(0, last);
            Name = pDirectory.Substring(last + 1);
        }

        /// <summary>
        /// Creates a reader for each file in a directory, or a single file
        /// depending if the class name points to a package or class.
        /// </summary>
        public IList<iPackageReader> Load(ClassNameType pClassName)
        {
            if (String.Compare(pClassName[0], Name, StringComparison.CurrentCultureIgnoreCase) != 0)
            {
                return null;
            }

            string parts = pClassName.ToString().Replace('.', Path.DirectorySeparatorChar);
            string path = Directory + Path.DirectorySeparatorChar + parts;

            if (File.Exists(path + ".fire"))
            {
                iPackageReader reader = _factory.Create(pClassName, path + ".fire");
                return new[] { reader };
            }
            if (System.IO.Directory.Exists(path))
            {
                return
                    (from file in System.IO.Directory.EnumerateFiles(path, "*.fire")
                     let cn = new ClassNameType(pClassName + "." + Path.GetFileNameWithoutExtension(file))
                     select _factory.Create(cn,file))
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