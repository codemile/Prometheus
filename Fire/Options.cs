using GemsCLI.Attributes;
using GemsCLI.Enums;

namespace Fire
{
    /// <summary>
    /// Holds the command line options.
    /// </summary>
    public class Options
    {
        /// <summary>
        /// The name of the input file.
        /// </summary>
        [CliName(eROLE.PASSED)]
        [CliHelp("Name of the input file.")]
        public string Filename { get; set; }
    }
}