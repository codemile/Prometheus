using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PrometheusTest
{
    /// <summary>
    /// Handles serializing resources embedded in the assembly of the application.
    /// </summary>
    public class Resources
    {
        /// <summary>
        /// The assembly to load files from.
        /// </summary>
        private readonly Assembly _files;

        /// <summary>
        /// The folder resources are stored in.
        /// </summary>
        private readonly string _folder;

        /// <summary>
        /// The name of the package used to load embedded files.
        /// </summary>
        private readonly string _packageName;

        /// <summary>
        /// Constructor
        /// </summary>
        public Resources(Type pOwner, string pFolder)
        {
            _packageName = pOwner.FullName.Split(new[] { '.' })[0];
            _files = pOwner.Assembly;
            _folder = pFolder;
        }

        /// <summary>
        /// Loads a resource from the application as a string.
        /// </summary>
        public string ReadAsString(string pResourceName, bool pStripReturns = true, bool pForceUTF8 = false)
        {
            string fullResourceName = string.Format("{0}.{1}.{2}", _packageName, _folder, pResourceName);
            using (Stream stream = _files.GetManifestResourceStream(fullResourceName))
            {
                if (stream == null)
                {
                    throw new Exception(string.Format("Resource not found {0} - Did you forget to embed the resource via it's properties?", fullResourceName));
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    string str = reader.ReadToEnd();
                    if (pForceUTF8)
                    {
                        byte[] bytes = Encoding.Default.GetBytes(str);
                        str = Encoding.UTF8.GetString(bytes);
                    }
                    if (pStripReturns)
                    {
                        str = str.Replace("\r", "");
                    }
                    return str;
                }
            }
        }
    }
}
