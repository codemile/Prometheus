using System.IO;
using System.Reflection;
using Fire.Properties;
using GemsCLI;
using Logging;
using Logging.Writers;
using Prometheus.Compile;
using Prometheus.Exceptions;
using Prometheus.Nodes;

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

            if (string.IsNullOrWhiteSpace(options.Project))
            {
                WriteGreeting();
                return 0;
            }

            if (!Directory.Exists(options.Project))
            {
                _logger.Error("Directory does not exist: {0}", options.Project);
                return -1;
            }

            try
            {
                Project project = new Project();
                project.AddDirectory(options.Project);
                // TODO: Check that the package name is formatted correctly.
                project.Build(new ClassNameType(options.Package));

/*
                Parser parser = new Parser();
                return parser.Run(codeFile);
*/
            }
            catch (PrometheusException e)
            {
                _logger.Error("Error: " + e.Format().Replace("{", "{{").Replace("}", "}}"));
            }

            return -1;
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