using System;
using System.Diagnostics;
using System.Reflection;
using Fire.Properties;
using GemsCLI;
using Logging;

namespace Fire
{
    internal static class Program
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (Program));

        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="pArgs">Command line arguments</param>
        private static void Main(string[] pArgs)
        {
            WriteGreeting();
            Options options = RequestFactory.Create<Options>(CLIOptions.WindowsStyle, pArgs);
        }

        /// <summary>
        /// Displays program greeting.
        /// </summary>
        private static void WriteGreeting()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            Console.WriteLine(Resource.Greeting_Version, version);
            Console.WriteLine(Resource.Greeting_License);
            Console.WriteLine(Resource.Greeting_Contact);
            Console.WriteLine("");
        }
    }
}