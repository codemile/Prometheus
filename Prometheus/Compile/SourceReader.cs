using System.IO;

namespace Prometheus.Compile
{
    public class SourceReader : StringReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.IO.StringReader"/> class that reads from the specified string.
        /// </summary>
        /// <param name="s">The string to which the <see cref="T:System.IO.StringReader"/> should be initialized. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="s"/> parameter is null. </exception>
        public SourceReader(string s) : base(s)
        {
        }
    }
}