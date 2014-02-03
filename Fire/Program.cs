using System.Reflection;
using Fire.Exceptions;
using Fire.Properties;
using Fire.Sources;
using GemsCLI;
using Logging;
using Logging.Writers;
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

            Options options = RequestFactory.Create<Options>(CliOptions.WindowsStyle, pArgs);
            if (options == null)
            {
                return;
            }

            Logger.Add(new ConsoleWriter(options.Debug));
            Logger.Add(new VisualStudioWriter());

            if (string.IsNullOrWhiteSpace(options.FileName))
            {
                WriteGreeting();
            }

            try
            {
                string filename = Reader.getFileNameWithExtension(options.FileName, "fire");
                string source = Reader.Open(filename);

                Compiler prometheus = new Compiler();
                TargetCode code = prometheus.Compile(filename, source);

                Parser parser = new Parser();
                parser.Run(code);
            }
            catch (FireException e)
            {
                _logger.Error(e.Message.Replace("{", "{{").Replace("}", "}}"));
            }
            catch (PrometheusException e)
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
            _logger.Fine(Resource.Greeting_Version, assembly.GetName().Version);
            _logger.Fine(Resource.Greeting_License);
            _logger.Fine(Resource.Greeting_Contact);
            _logger.Fine("");
        }
    }
}