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

        /// <summary>
        /// The package to run
        /// </summary>
        [CliName(eROLE.PASSED)]
        [CliHelp("The path to the project directory.")]
        public string Directory { get; set; }

        [CliName(eROLE.PASSED)]
        [CliHelp("The name of the package.class to build.")]
        public string Package { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Options()
        {
            Debug = false;
        }
    }
}