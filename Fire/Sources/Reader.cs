using System.IO;
using Fire.Exceptions;

namespace Fire.Sources
{
    public static class Reader
    {
        /// <summary>
        /// Ensures that the file name contains a file extensions.
        /// </summary>
        /// <param name="pFileName">The filename</param>
        /// <param name="pExtension">The file extension</param>
        /// <returns>The filename with extension added.</returns>
        private static string getFileNameWithExtension(string pFileName, string pExtension)
        {
            string ext = string.Format(".{0}", pExtension.ToLower());

            if (pFileName.ToLower().EndsWith(ext))
            {
                return pFileName;
            }
            return pFileName.Contains(".") ? pFileName : string.Format("{0}{1}", pFileName, ext);
        }

        /// <summary>
        /// Reads a source code file.
        /// </summary>
        /// <param name="pFileName">The name of the file (extension is optional)</param>
        /// <returns>The contents of the file.</returns>
        public static string Open(string pFileName)
        {
            string target = getFileNameWithExtension(pFileName, "fire");

            if (!File.Exists(target))
            {
                throw new SourceCodeException("Could not open file: {0}", target);
            }

            using (StreamReader reader = new StreamReader(target))
            {
                try
                {
                    return reader.ReadToEnd();
                }
                catch (IOException)
                {
                    throw new SourceCodeException("Unable to read file: {0}", target);
                }
            }
        }
    }
}