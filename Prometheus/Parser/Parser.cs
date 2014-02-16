using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Prometheus.Compile;
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

        /// <summary>
        /// Constructor
        /// </summary>
        public Parser()
        {
            _customVaraibles = new Dictionary<string, DataType>();
            _customObjects = new Dictionary<string, object>();
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
        public int Run(TargetCode pCode)
        {
            using (Executor executor = new Executor())
            {
                // create the global variables
                Dictionary<string, DataType> globals = new Dictionary<string, DataType>(_customVaraibles);

                // create root object (the default "this" reference)
                globals.Add("this", new InstanceType());

                foreach (KeyValuePair<string, object> customObject in _customObjects)
                {
                    ObjectSpace objSpace = new ObjectSpace(customObject.Value);
                    globals.Add(customObject.Key, new InstanceType(objSpace));
                }

                using (executor.Cursor.Stack = new StackSpace(executor.Cursor, globals))
                {
                    DataType value = executor.Execute(pCode.Root, new Dictionary<string, DataType>()) ??
                                     new NumericType(-1);

                    NumericType num = value as NumericType;
                    return (num != null) ? (int)num.Long : 0;
                }
            }
        }
    }
}