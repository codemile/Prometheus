using System.Diagnostics;

namespace Prometheus.Compile
{
    /// <summary>
    /// Represents a location in the source code.
    /// Used mostly for error reporting.
    /// </summary>
    [DebuggerDisplay("{FileName} {Row}:{Column}")]
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
        public readonly string FileName;

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
        public Location(string pFileName, string pLine, int pRow, int pColumn)
        {
            FileName = pFileName ?? "";
            Line = pLine ?? "";

            Row = pRow;
            Column = pColumn;
        }

        /// <summary>
        /// Renders the location as a human readable value.
        /// </summary>
        public override string ToString()
        {
            return FileName == null
                ? "in undefined source."
                : string.Format("in {0} at: {1}, {2}", FileName, Row, Column);
        }
    }
}