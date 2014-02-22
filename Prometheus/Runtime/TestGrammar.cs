using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles grammar related to running unit tests.
    /// </summary>
    public class TestGrammar : ExecutorGrammar
    {
        /// <summary>
        /// List of unit tests to execute.
        /// </summary>
        private readonly List<string> _testSuite;

        /// <summary>
        /// A list of unit tests defined in the program.
        /// </summary>
        private readonly List<string> _tests;

        /// <summary>
        /// Constructor
        /// </summary>
        public TestGrammar(Executor pExecutor)
            : base(pExecutor)
        {
            _tests = new List<string>();
            _testSuite = new List<string>();
        }

        /// <summary>
        /// Executes the current unit test.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.TestExecute)]
        public DataType TestExecute()
        {
            try
            {
                QualifiedType unit = new QualifiedType(Executor.Cursor.UnitTest);
                ClosureType func = Executor.Cursor.Get<ClosureType>(unit);
                return func.Function.Children.Count == 0
                    ? UndefinedType.Undefined
                    : Executor.Execute(func.Function);
            }
            catch (ReturnException returnData)
            {
                return returnData.Value;
            }
        }

        /// <summary>
        /// Declares a source file as a test suite.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.TestSuiteDecl)]
        public DataType TestSuite()
        {
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Declares a source file as a test suite.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.TestSuiteDecl)]
        public DataType TestSuite(DataType pTests)
        {
            ArrayType arr = pTests is ArrayType
                ? (ArrayType)pTests
                : new ArrayType(pTests);

            foreach (IdentifierType id in from test in arr select test.Cast<IdentifierType>())
            {
                _tests.Add(id.Name);
            }
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Declares a unit test.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.TestDecl)]
        public DataType UnitTest(IdentifierType pName, ClosureType pTest)
        {
            _tests.Add(pName.Name);
            Executor.Cursor.Stack.Create(pName.Name, pTest);
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Handles a basic assert
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.AssertProc)]
        public DataType _Assert(DataType pValue)
        {
            if (!pValue.getBool())
            {
                throw new AssertionException("Assert failed", Executor.Cursor.Node);
            }
            return UndefinedType.Undefined;
        }
    }
}