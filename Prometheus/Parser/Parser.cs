using System.Collections.Generic;
using Prometheus.Compile;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Objects;
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
        /// A list of variables to inject
        /// </summary>
        private readonly Dictionary<string, DataType> _customVaraibles;

        /// <summary>
        /// A list of objects to inject
        /// </summary>
        private readonly Dictionary<string, object> _customObjects; 

        /// <summary>
        /// Constructor
        /// </summary>
        public Parser()
        {
            _customVaraibles = new Dictionary<string, DataType>();
            _customObjects = new Dictionary<string, object>();
        }

        /// <summary>
        /// Adds a double variable
        /// </summary>
        /// <param name="pNameSpace">The namespace</param>
        /// <param name="pName">The variable name</param>
        /// <param name="pValue">The string value</param>
        public void CreateDouble(string pNameSpace, string pName, double pValue)
        {
            ClassNameType name = new ClassNameType(new QualifiedType(pNameSpace), new IdentifierType(pName));
            _customVaraibles.Add(pName, new NumericType(pValue));
        }

        /// <summary>
        /// Adds a long variable
        /// </summary>
        /// <param name="pNameSpace">The namespace</param>
        /// <param name="pName">The variable name</param>
        /// <param name="pValue">The string value</param>
        public void CreateLong(string pNameSpace, string pName, long pValue)
        {
            ClassNameType name = new ClassNameType(new QualifiedType(pNameSpace), new IdentifierType(pName));
            _customVaraibles.Add(pName, new NumericType(pValue));
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
        /// Adds a string variable
        /// </summary>
        /// <param name="pNameSpace">The namespace</param>
        /// <param name="pName">The variable name</param>
        /// <param name="pValue">The string value</param>
        public void CreateString(string pNameSpace, string pName, string pValue)
        {
            ClassNameType name = new ClassNameType(new QualifiedType(pNameSpace), new IdentifierType(pName));
            _customVaraibles.Add(pName, new StringType(pValue));
        }

        /// <summary>
        /// Runs the code
        /// </summary>
        public int Run(TargetCode pCode)
        {
            using (Executor executor = new Executor())
            {
                // create the global variables
                Dictionary<string, DataType> globals = new Dictionary<string, DataType>(_customVaraibles);

                // create root object (the default "this" reference)
                DataType _this = executor.Cursor.Heap.Add(new Instance(new ClassNameType("prometheus.root")));
                globals.Add("this", _this);

                foreach (var customObject in _customObjects)
                {
                    ObjectSpace objSpace = new ObjectSpace(customObject.Value);
                    DataType alias = executor.Cursor.Heap.Add(new Instance(new ClassNameType(customObject.Value.GetType()),objSpace));
                    globals.Add(customObject.Key, alias);
                }

                using (executor.Cursor.Stack = new StackSpace(executor.Cursor, globals))
                {
                    DataType value = executor.Execute(pCode.Root, new Dictionary<string, DataType>()) ??
                                     new NumericType(-1);

                    NumericType num = value as NumericType;
                    return (num != null) ? (int)num.getLong() : 0;
                }
            }
        }
    }
}