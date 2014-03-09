using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Logging;
using Prometheus.Compile.Packaging;
using Prometheus.Exceptions;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Storage;

namespace Prometheus.Parser
{
    /// <summary>
    /// The run-time engine for Prometheus.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// List of types that can be converted to double without lose of precision.
        /// </summary>
        private static readonly HashSet<Type> _doubleTypes = new HashSet<Type>
                                                             {
                                                                 typeof (float),
                                                                 typeof (double)
                                                             };

        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (Parser));

        /// <summary>
        /// List of types that can be converted to long without lose of precision.
        /// </summary>
        private static readonly HashSet<Type> _longTypes = new HashSet<Type>
                                                           {
                                                               typeof (Byte),
                                                               typeof (SByte),
                                                               typeof (Int16),
                                                               typeof (Int32),
                                                               typeof (Int64),
                                                               typeof (UInt16),
                                                               typeof (UInt32),
                                                               typeof (UInt64)
                                                           };

        /// <summary>
        /// A list of objects to inject
        /// </summary>
        private readonly Dictionary<string, object> _customObjects;

        /// <summary>
        /// A list of variables to inject
        /// </summary>
        private readonly Dictionary<string, DataType> _customVaraibles;

        private static bool IsTestSuite(Node pNode)
        {
            return pNode.HasChild(GrammarSymbol.TestSuiteDecl);
        }

        /// <summary>
        /// Generates a list of tests to run.
        /// </summary>
        private static IEnumerable<string> getTestsToRun(Node pRoot, IEnumerable<string> pUnitTests)
        {
            Node testSuite = pRoot.FindChild(GrammarSymbol.TestSuiteDecl);
            if (testSuite.Children.Count == 0)
            {
                return pUnitTests;
            }

            if (testSuite.FirstChild().Symbol == GrammarSymbol.TestSuiteArray)
            {
                return from id in testSuite.FirstChild().Children
                       where id.Symbol == GrammarSymbol.ValidID
                             && id.FirstData() is IdentifierType
                       select id.FirstData().Cast<IdentifierType>().Name;
            }
            if (testSuite.FirstChild().Symbol == GrammarSymbol.ValidID)
            {
                return from id in testSuite.FirstChild().Data
                       where id is IdentifierType
                       select id.Cast<IdentifierType>().Name;
            }

            throw new UnexpectedErrorException(string.Format("Unexpected data assigned to <{0}>",
                GrammarSymbol.TestSuiteDecl));
        }

        /// <summary>
        /// Creates a list of all unit test declarations.
        /// </summary>
        private static IEnumerable<string> getUnitTestNames(Node pImported)
        {
            return (from child in pImported.Children
                    where child.Symbol == GrammarSymbol.TestDecl
                    select child.FirstData().Cast<IdentifierType>().Name).ToList();
        }

        /// <summary>
        /// Executes the node as a program.
        /// </summary>
        private void Execute(IEnumerable<Node> pNode, Cursor pCursor)
        {
            using (Executor executor = new Executor(pCursor))
            {
                // create the global variables
                Dictionary<string, DataType> globals = new Dictionary<string, DataType>(_customVaraibles)
                                                       {
                                                           {
                                                               "this", new InstanceType(
                                                               new QualifiedType("global"),
                                                               new StorageSpace())
                                                           }
                                                       };

                foreach (KeyValuePair<string, object> customObject in _customObjects)
                {
                    ObjectSpace objSpace = new ObjectSpace(customObject.Value);
                    globals.Add(customObject.Key,
                        new InstanceType(
                            new QualifiedType(string.Format("global.{0}", customObject.Value.GetType().Name.ToLower())),
                            objSpace));
                }

                using (pCursor.Root = new CursorSpace(pCursor, globals))
                {
                    foreach (Node node in pNode)
                    {
                        executor.Execute(node, new Dictionary<string, DataType>());
                    }
                }
            }
        }

        /// <summary>
        /// Executes the list of nodes and handles any exceptions.
        /// </summary>
        private bool ExecuteSafely(IEnumerable<Node> pNodes, Cursor pCursor)
        {
            try
            {
                Execute(pNodes, pCursor);
                return true;
            }
            catch (PrometheusException e)
            {
                HandleError(e);
            }
            catch (Exception e)
            {
                _logger.Exception(e);
            }
            return false;
        }

        /// <summary>
        /// Runs the code in testing mode.
        /// </summary>
        private void ExecuteTests(Compiled pCompiled)
        {
            IEnumerable<Node> testNodes = pCompiled.getTestNodes();
            IList<Node> nodes = pCompiled.getNodes().ToList();

            foreach (Node testNode in testNodes)
            {
                _logger.Fine("");
                _logger.Fine("Testing {0}", testNode.Location.ImportFile.Name);

                IEnumerable<string> unitTests = getUnitTestNames(testNode);
                foreach (string test in getTestsToRun(testNode, unitTests))
                {
                    List<Node> runThese = new List<Node>(nodes) {testNode};
                    bool result = ExecuteSafely(runThese, new Cursor(test));
                    _logger.Fine("{0} {1}::{2}", result ? "Pass" : "Fail", testNode.Location.ImportFile.Name, test);
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Parser()
        {
            _customVaraibles = new Dictionary<string, DataType>();
            _customObjects = new Dictionary<string, object>();
        }

        /// <summary>
        /// Logs the error
        /// </summary>
        public static void HandleError(PrometheusException pException)
        {
            _logger.Error("Error: " + pException.Format().Replace("{", "{{").Replace("}", "}}"));
        }

        /// <summary>
        /// Adds a primitive variable type
        /// </summary>
        /// <param name="pName">The variable name</param>
        /// <param name="pValue">The value</param>
        public void Create(string pName, object pValue)
        {
            if (_longTypes.Contains(pValue.GetType()))
            {
                _customVaraibles.Add(pName, new NumericType(Convert.ToInt64(pValue)));
            }
            else if (_doubleTypes.Contains(pValue.GetType()))
            {
                _customVaraibles.Add(pName, new NumericType(Convert.ToDouble(pValue)));
            }
            else if (pValue is bool)
            {
                _customVaraibles.Add(pName, new BooleanType((bool)pValue));
            }
            else if (pValue is string)
            {
                _customVaraibles.Add(pName, new StringType((string)pValue));
            }
            else if (pValue is Regex)
            {
                Regex regex = (Regex)pValue;
                StringType.eFLAGS flags = regex.Options.HasFlag(RegexOptions.IgnoreCase)
                    ? StringType.eFLAGS.IGNORE_CASE
                    : StringType.eFLAGS.NONE;
                _customVaraibles.Add(pName, new StringType(true, regex.ToString(), StringType.eMODE.ANYWHERE, flags));
            }
        }

        /// <summary>
        /// Adds an object to the parser to be exposed as a variable at run-time.
        /// </summary>
        /// <param name="pNameSpace">The namespace to use</param>
        /// <param name="pName">The variable name</param>
        /// <param name="pValue">The object to expose</param>
        public void CreateObject(string pNameSpace, string pName, object pValue)
        {
            _customObjects.Add(pName, pValue);
        }

        /// <summary>
        /// Runs the code
        /// </summary>
        public void Run(Compiled pCompiled)
        {
            if (pCompiled.TestSuite)
            {
                ExecuteTests(pCompiled);
            }
            else
            {
                ExecuteSafely(pCompiled.Imported, new Cursor());
            }
        }
    }
}