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

        private string _fileName;

        /// <summary>
        /// The package to run
        /// </summary>
        [CliName(eROLE.PASSED)]
        [CliHelp("File to build")]
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                if (_fileName.IndexOf('.') == -1)
                {
                    _fileName += ".fire";
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Options()
        {
            Debug = false;
        }
    }
}