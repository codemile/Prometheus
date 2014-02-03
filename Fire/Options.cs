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
        /// Send output to Visual Studio's immediate window.
        /// </summary>
        [CliName(eROLE.NAMED)]
        [CliOptional]
        [CliHelp("Send output to Visual Studio's immediate window.")]
        public bool Debug { get; set; }

        /// <summary>
        /// The name of the input file.
        /// </summary>
        [CliName(eROLE.PASSED)]
        [CliHelp("Name of the input file.")]
        public string FileName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Options()
        {
            Debug = false;
        }
    }
}