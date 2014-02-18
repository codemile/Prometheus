using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Prometheus.Exceptions.Compiler;
using Prometheus.Nodes;

namespace Prometheus.Packages
{
    /// <summary>
    /// A loader that points to a directory that acts like a package.
    /// </summary>
    public class DirectoryLoader : iPackageLoader
    {
        /// <summary>
        /// The directory
        /// </summary>
        private readonly string _directory;

        /// <summary>
        /// The name of the package.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pDirectory"></param>
        public DirectoryLoader(string pDirectory)
        {
            int last = pDirectory.LastIndexOf(Path.DirectorySeparatorChar);
            _directory = pDirectory.Substring(0, last);
            _name = pDirectory.Substring(last+1);
        }

        /// <summary>
        /// Creates a reader for each file in a directory, or a single file
        /// depending if the class name points to a package or class.
        /// </summary>
        public IList<iPackageReader> Load(ClassNameType pClassName)
        {
            if (String.Compare(pClassName[0], _name, StringComparison.CurrentCultureIgnoreCase) != 0)
            {
                return null;
            }

            string parts = pClassName.ToString().Replace('.', Path.DirectorySeparatorChar);
            string path = _directory + Path.DirectorySeparatorChar + parts;

            if (File.Exists(path + ".fire"))
            {
                return new iPackageReader[] { new FileReader(path + ".fire", pClassName) };
            }
            if (Directory.Exists(path))
            {
                return
                    (from file in Directory.EnumerateFiles(path, "*.fire") 
                     let cn = new ClassNameType(pClassName+"."+Path.GetFileNameWithoutExtension(file))
                     select (iPackageReader)new FileReader(file, cn))
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