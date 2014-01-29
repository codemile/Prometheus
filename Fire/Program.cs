using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Fire.Exceptions;
using Fire.Properties;
using Fire.Sources;
using GemsCLI;
using Logging;
using Prometheus;

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
            Options options = RequestFactory.Create<Options>(CliOptions.WindowsStyle, pArgs);
            if (options == null)
            {
                return;
            }

            try
            {
                string source = Reader.Open(options.FileName);
                Compiler prometheus = new Compiler();
                TargetCode code = prometheus.Compile(options.FileName, source);
            }
            catch (FireException e)
            {
                _logger.Exception(e);
            }
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