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
using Prometheus.Compile;
using Prometheus.Exceptions;
using Prometheus.Parser;

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
                string filename = Reader.getFileNameWithExtension(options.FileName, "fire");
                string source = Reader.Open(filename);

                Compiler prometheus = new Compiler();
                TargetCode code = prometheus.Compile(filename, source);

                Parser parser = new Parser(code);
                parser.Execute();
            }
            catch (FireException e)
            {
                _logger.Error(e.Message.Replace("{", "{{").Replace("}", "}}"));
            }
            catch (CompilerException e)
            {
                _logger.Error(e.Message.Replace("{", "{{").Replace("}", "}}"));
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

            Debug.WriteLine(Resource.Greeting_Version, version);
            Debug.WriteLine(Resource.Greeting_License);
            Debug.WriteLine(Resource.Greeting_Contact);
            Debug.WriteLine("");
        }
    }
}