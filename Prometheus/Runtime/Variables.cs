using System.Collections.Generic;
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
        /// Assigns a value to a variable.
        /// </summary>
        /// <param name="pIdentifier">Name of the variable</param>
        /// <param name="pValue">The value</param>
        /// <returns>The value assigned</returns>
        [SymbolHandler(GrammarSymbol.Assignment)]
        public Data Assignment(Data pIdentifier, Data pValue)
        {
            if (!_variables.ContainsKey(pIdentifier.Value))
            {
                _variables.Add(pIdentifier.Value, pValue);
            }
            else
            {
                _variables[pIdentifier.Value] = pValue;
            }
            return pValue;
        }

        /// <summary>
        /// Returns the value of a variable.
        /// </summary>
        /// <param name="pIdentifier">The variable name</param>
        /// <returns>The value or undefined.</returns>
        [SymbolHandler(GrammarSymbol.Variable)]
        public Data Variable(Data pIdentifier)
        {
            return !_variables.ContainsKey(pIdentifier.Value) ? Data.Undefined : _variables[pIdentifier.Value];
        }
    }
}