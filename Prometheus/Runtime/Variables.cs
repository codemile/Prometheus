using System.Collections.Generic;
using System.Diagnostics;
using Prometheus.Exceptions.Parser;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles symbols related to variable management
    /// </summary>
    public class Variables : PrometheusObject
    {
        /// <summary>
        /// Storage of variable values.
        /// </summary>
        private readonly Dictionary<string, Data> _variables;

        /// <summary>
        /// Constructor
        /// </summary>
        public Variables()
        {
            _variables = new Dictionary<string, Data>();
        }

        /// <summary>
        /// Returns the identifier for a reference, and throws an exception
        /// if it does not exist.
        /// </summary>
        /// <param name="pIdentifier">The data</param>
        /// <returns>The identifier</returns>
        private string AssertExists(Data pIdentifier)
        {
            Identifier id = pIdentifier.getIdentifier();
            if (_variables.ContainsKey(id.Name))
            {
                return id.Name;
            }
            throw new IdentifierException("Reference error: {0} is not defined",id.Name);
        }

        /// <summary>
        /// Returns the identifier for a reference, and throws an exception
        /// if it already exists.
        /// </summary>
        /// <param name="pIdentifier">The data</param>
        /// <returns>The identifier</returns>
        private string AssertUndefined(Data pIdentifier)
        {
            Identifier id = pIdentifier.getIdentifier();
            if (_variables.ContainsKey(id.Name))
            {
                throw new IdentifierException("Reference error: {0} already defined", id.Name);
            }
            return id.Name;
        }

        /// <summary>
        /// Declares a variable with a value
        /// </summary>
        /// <param name="pIdentifier">Name of the variable</param>
        /// <param name="pValue">The value</param>
        /// <returns>The value assigned</returns>
        [SymbolHandler(GrammarSymbol.Declare)]
        public Data Declare(Data pIdentifier, Data pValue)
        {
            string id = AssertUndefined(pIdentifier);
            _variables.Add(id, pValue);
            return pValue;
        }

        /// <summary>
        /// Declares a variable without a value
        /// </summary>
        /// <param name="pIdentifier">Name of the variable</param>
        /// <returns>The value assigned</returns>
        [SymbolHandler(GrammarSymbol.Declare)]
        public Data Declare(Data pIdentifier)
        {
            string id = AssertUndefined(pIdentifier);
            _variables.Add(id, Data.Undefined);
            return Data.Undefined;
        }

        /// <summary>
        /// Returns the value of a variable.
        /// </summary>
        /// <param name="pIdentifier">The variable name</param>
        /// <returns>The value or undefined.</returns>
        [SymbolHandler(GrammarSymbol.Variable)]
        public Data Variable(Data pIdentifier)
        {
            string id = AssertExists(pIdentifier);
            return _variables[id];
        }

        /// <summary>
        /// Increment
        /// </summary>
        [SymbolHandler(GrammarSymbol.Increment)]
        public Data Inc(Data pIdentifier)
        {
            string id = AssertExists(pIdentifier);
            Data d = _variables[id];
            return d.Type == typeof(double)
                ? _variables[id] = new Data(d.Get<double>() + 1)
                : _variables[id] = new Data(d.Get<long>() + 1);
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [SymbolHandler(GrammarSymbol.Decrement)]
        public Data Dec(Data pIdentifier)
        {
            string id = AssertExists(pIdentifier);
            Data d = _variables[id];
            return d.Type == typeof (double)
                ? _variables[id] = new Data(d.Get<double>() - 1)
                : _variables[id] = new Data(d.Get<long>() - 1);
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [SymbolHandler(GrammarSymbol.ListVars)]
        public Data ListVars()
        {
            foreach (KeyValuePair<string, Data> var in _variables)
            {
                if (var.Value.Type == typeof (string))
                {
                    Debug.WriteLine("{0} = \"{1}\"", var.Key, var.Value.Get<string>());
                    continue;
                }
                Debug.WriteLine("{0} = {1}", var.Key, var.Value.Get<string>() ?? "undefined");
            }
            return Data.Undefined;
        }

    }
}