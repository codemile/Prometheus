using System.IO;
using System.Text.RegularExpressions;
using Prometheus.Exceptions.Compiler;

namespace Prometheus.Packages
{
    /// <summary>
    /// Generic text file reading.
    /// </summary>
    public static class Reader
    {
        /// <summary>
        /// Reads a source code file.
        /// </summary>
        /// <param name="pFileName">The name of the file (extension is optional)</param>
        /// <returns>The contents of the file.</returns>
        public static string Open(string pFileName)
        {
            if (!File.Exists(pFileName))
            {
                throw new SourceCodeException(string.Format("Could not open file: {0}", pFileName));
            }

            using (StreamReader reader = new StreamReader(pFileName))
            {
                try
                {
                    return reader.ReadToEnd();
                }
                catch (IOException)
                {
                    throw new SourceCodeException(string.Format("Unable to read file: {0}", pFileName));
                }
            }
        }

        /// <summary>
        /// Ensures that the file name contains a file extensions.
        /// </summary>
        /// <param name="pFileName">The filename</param>
        /// <param name="pExtension">The file extension</param>
        /// <returns>The filename with extension added.</returns>
        public static string getFileNameWithExtension(string pFileName, string pExtension)
        {
            string ext = string.Format(".{0}", pExtension.ToLower());

            if (pFileName.ToLower().EndsWith(ext))
            {
                return pFileName;
            }

            return (Regex.IsMatch(pFileName, @"^.*/(\.[^\.]+)$")) ? pFileName : string.Format("{0}{1}", pFileName, ext);
        }
    }
}