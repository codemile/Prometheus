using System.IO;
using System.Reflection;
using Fire.Properties;
using GemsCLI;
using Logging;
using Logging.Writers;
using Prometheus.Compile;
using Prometheus.Compile.Packaging;
using Prometheus.Exceptions;
using Prometheus.Packages;
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
        private static int Main(string[] pArgs)
        {
            Options options = RequestFactory.Create<Options>(CliOptions.WindowsStyle, pArgs);
            if (options == null)
            {
                return -1;
            }

#if DEBUG
            Logger.LogDebug = true;
#endif

            Logger.Add(new ConsoleWriter(options.Debug));
            Logger.Add(new VisualStudioWriter());

            if (string.IsNullOrWhiteSpace(options.FileName))
            {
                WriteGreeting();
                return 0;
            }

            string fileName = Path.GetFullPath(Reader.getFileNameWithExtension(options.FileName, "fire"));
            string includePath = Path.GetDirectoryName(fileName);

            try
            {
                Builder project = new Builder();
                project.AddDirectory(includePath);
                Compiled code = project.Build(fileName);

                Parser parser = new Parser();
                parser.Run(code);
            }
            catch (PrometheusException e)
            {
                Parser.HandleError(e);
            }

            return 0;
        }

        /// <summary>
        /// Displays program greeting.
        /// </summary>
        private static void WriteGreeting()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            _logger.Fine(Resource.Greeting_Version, assembly.GetName().Version);
            _logger.Fine(Resource.Greeting_License);
            _logger.Fine(Resource.Greeting_Contact);
            _logger.Fine("");
        }
    }
}