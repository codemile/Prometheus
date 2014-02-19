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
        [CliName]
        [CliOptional]
        [CliHelp("Send output to Visual Studio's immediate window.")]
        public bool Debug { get; set; }

        [CliName(eROLE.PASSED)]
        [CliHelp("The name of the file to build.")]
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