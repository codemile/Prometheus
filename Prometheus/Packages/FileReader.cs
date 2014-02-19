using System.IO;
using Prometheus.Exceptions.Compiler;
using Prometheus.Nodes;

namespace Prometheus.Packages
{
    /// <summary>
    /// Handles reading a source code from a file.
    /// </summary>
    public class FileReader : iPackageReader
    {
        /// <summary>
        /// Name of the class to read.
        /// </summary>
        private readonly ClassNameType _className;

        /// <summary>
        /// Path to the file
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// Constructor
        /// </summary>
        public FileReader(ClassNameType pClassName, string pPath)
        {
            _path = pPath;
            _className = pClassName;
        }

        /// <summary>
        /// The class this reader provides source code for.
        /// </summary>
        public ClassNameType ClassName()
        {
            return _className;
        }

        /// <summary>
        /// The full path to the file. This is used in error messages as a
        /// reference to the source code.
        /// </summary>
        public string FileName()
        {
            return _path;
        }

        /// <summary>
        /// The text reader will feed the source code to the compiler.
        /// </summary>
        /// <returns>A reader object</returns>
        public string Read()
        {
            if (!File.Exists(_path))
            {
                throw new SourceCodeException(string.Format("File does not exist: {0}", _path));
            }
            using (StreamReader reader = new StreamReader(_path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}