using System.Collections.Generic;
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

        private Identifier AssertIdentifier(Data pIdentifier)
        {
            Identifier id = pIdentifier.getIdentifier();
            if (_variables.ContainsKey(id.Name))
            {
                return id;
            }
            throw new UndefinedException(id.Name);
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
            Identifier id = pIdentifier.getIdentifier();
            if (!_variables.ContainsKey(id.Name))
            {
                _variables.Add(id.Name, pValue);
            }
            else
            {
                _variables[id.Name] = pValue;
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
            Identifier id = AssertIdentifier(pIdentifier);
            return _variables[id.Name];
        }

        /// <summary>
        /// Increment
        /// </summary>
        [SymbolHandler(GrammarSymbol.Increment)]
        public Data Inc(Data pIdentifier)
        {
            Identifier id = AssertIdentifier(pIdentifier);
            Data d = _variables[id.Name];
            return d.Type == typeof(double)
                ? _variables[id.Name] = new Data(d.Get<double>() + 1)
                : _variables[id.Name] = new Data(d.Get<long>() + 1);
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [SymbolHandler(GrammarSymbol.Decrement)]
        public Data Dec(Data pIdentifier)
        {
            Identifier id = AssertIdentifier(pIdentifier);
            Data d = _variables[id.Name];
            return d.Type == typeof (double)
                ? _variables[id.Name] = new Data(d.Get<double>() - 1)
                : _variables[id.Name] = new Data(d.Get<long>() - 1);
        }

    }
}