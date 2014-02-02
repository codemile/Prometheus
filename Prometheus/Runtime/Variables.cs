using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles symbols related to variable management
    /// </summary>
    public class Variables : PrometheusObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Variables(Cursor pCursor) 
            : base(pCursor)
        {
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [SymbolHandler(GrammarSymbol.Decrement)]
        public Data Dec(Data pIdentifier)
        {
            Data d = Cursor.Scope.Get(pIdentifier.getIdentifier().Name);
            d = d.Type == typeof (double)
                ? new Data(d.Get<double>() - 1)
                : new Data(d.Get<long>() - 1);
            Cursor.Scope.Set(pIdentifier.getIdentifier().Name, d);
            return d;
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
            Cursor.Scope.Create(pIdentifier.getIdentifier().Name, pValue);
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
            return Declare(pIdentifier, Data.Undefined);
        }

        /// <summary>
        /// Increment
        /// </summary>
        [SymbolHandler(GrammarSymbol.Increment)]
        public Data Inc(Data pIdentifier)
        {
            // TODO: Has to walk scope parents again to set.
            Data d = Cursor.Scope.Get(pIdentifier.getIdentifier().Name);
            d = d.Type == typeof (double)
                ? new Data(d.Get<double>() + 1)
                : new Data(d.Get<long>() + 1);
            Cursor.Scope.Set(pIdentifier.getIdentifier().Name, d);
            return d;
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [SymbolHandler(GrammarSymbol.ListVars)]
        public Data ListVars()
        {
            Cursor.Scope.Print();
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
            return Cursor.Scope.Get(pIdentifier.getIdentifier().Name);
        }

        /// <summary>
        /// Assigns a value to an Identifier
        /// </summary>
        /// <param name="pIdentifier">The variable name</param>
        /// <param name="pValue">The value to assign</param>
        [SymbolHandler(GrammarSymbol.Assignment)]
        public Data Assignment(Data pIdentifier, Data pValue)
        {
            Cursor.Scope.Set(pIdentifier.getIdentifier().Name, pValue);
            return pValue;
        }
    }
}