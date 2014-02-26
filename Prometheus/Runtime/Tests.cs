using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles grammar related to running unit tests.
    /// </summary>
    public class Tests : ExecutorGrammar
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
        public Tests(Executor pExecutor)
            : base(pExecutor)
        {
            _tests = new List<string>();
            _testSuite = new List<string>();
        }

        /// <summary>
        /// Declares a unit test.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.TestDecl)]
        public DataType TestDecl(Node pNode, IdentifierType pName, FunctionType pTest)
        {
            _tests.Add(pName.Name);
            Cursor.Stack.Create(pName.Name, pTest);
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Executes the current unit test.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.TestExecute)]
        public DataType TestExecute(Node pNode)
        {
            try
            {
                QualifiedType unit = new QualifiedType(Cursor.UnitTest);
                FunctionType func = Resolve<FunctionType>(unit);
                return Executor.Execute(func);
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
        public DataType TestSuite(Node pNode)
        {
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Declares a source file as a test suite.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.TestSuiteDecl)]
        public DataType TestSuite(Node pNode, DataType pTests)
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
        /// Handles a basic assert
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.AssertProc)]
        public DataType _Assert(Node pNode, DataType pValue)
        {
            if (!pValue.getBool())
            {
                throw new TestException("Assert failed", pNode);
            }
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Triggers the failure of a test.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.FailProc)]
        public DataType _Fail(Node pNode, DataType pValue)
        {
            QualifiedType id = pValue as QualifiedType;

            DataType value = id != null
                ? Cursor.Resolve(id).Read()
                : pValue;

            throw new TestException(string.Format("Failed: {0}", value), pNode);
        }

        /// <summary>
        /// Triggers the failure of a test.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.FailProc)]
        public DataType _Fail(Node pNode)
        {
            throw new TestException("Failed", pNode);
        }
    }
}