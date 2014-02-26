using System.Diagnostics;
using Prometheus.Compile.Packaging;

namespace Prometheus.Compile
{
    /// <summary>
    /// Represents a location in the source code.
    /// Used mostly for error reporting.
    /// </summary>
    [DebuggerDisplay("{ImportFile} {Row}:{Column}")]
    public class Location
    {
        /// <summary>
        /// An empty cursor
        /// </summary>
        public static readonly Location None = new Location(null, "", 0, 0);

        /// <summary>
        /// The column number.
        /// </summary>
        public readonly int Column;

        /// <summary>
        /// The source for the source code.
        /// </summary>
        public readonly Imported ImportFile;

        /// <summary>
        /// A copy of the current line from the source file.
        /// </summary>
        public readonly string Line;

        /// <summary>
        /// The row number.
        /// </summary>
        public readonly int Row;

        /// <summary>
        /// Constructor
        /// </summary>
        public Location(Imported pFileName, string pLine, int pRow, int pColumn)
        {
            ImportFile = pFileName;
            Line = pLine ?? "";

            Row = pRow;
            Column = pColumn;
        }

        /// <summary>
        /// Renders the location as a human readable value.
        /// </summary>
        public override string ToString()
        {
            return ImportFile == null
                ? "in undefined source."
                : string.Format("in {0} at: {1}, {2}", ImportFile.FileName, Row, Column);
        }
    }
}