using System.IO;
using Prometheus.Exceptions.Compiler;

namespace Prometheus.Packages
{
    /// <summary>
    /// Handles reading a source code from a file.
    /// </summary>
    public class FileReader : iPackageReader
    {
        /// <summary>
        /// The file to read
        /// </summary>
        private readonly string _fileName;

        /// <summary>
        /// Constructor
        /// </summary>
        public FileReader(string pFileName)
        {
            _fileName = pFileName;
        }

        /// <summary>
        /// The full path to the file. This is used in error messages as a
        /// reference to the source code.
        /// </summary>
        public string FileName()
        {
            return _fileName;
        }

        /// <summary>
        /// The text reader will feed the source code to the compiler.
        /// </summary>
        /// <returns>A reader object</returns>
        public TextReader CreateReader()
        {
            if (!File.Exists(_fileName))
            {
                throw new SourceCodeException(string.Format("File does not exist: {0}", _fileName));
            }

            return new StreamReader(_fileName);
        }
    }
}