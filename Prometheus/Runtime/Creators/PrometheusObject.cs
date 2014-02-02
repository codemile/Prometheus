using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Prometheus.Exceptions.Parser;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser;

namespace Prometheus.Runtime.Creators
{
    /// <summary>
    /// All executable objects
    /// </summary>
    public abstract class PrometheusObject
    {
        /// <summary>
        /// Reference to the cursor used by the parser. Always points to the
        /// current node being evaluated.
        /// </summary>
        protected readonly Cursor Cursor;

        /// <summary>
        /// A lookup table for a method. Grouped by symbol and argument count.
        /// </summary>
        private readonly Dictionary<GrammarSymbol, Dictionary<int, MethodInfo>> _methods;

        /// <summary>
        /// Constructor
        /// </summary>
        protected PrometheusObject(Cursor pCursor)
        {
            _methods = CreateMethodLookup(GetType());
            Cursor = pCursor;
        }

        /// <summary>
        /// Creates a lookup table for symbols and methods.
        /// </summary>
        /// <param name="pType">The class to inspect</param>
        /// <returns>The lookup table</returns>
        public static Dictionary<GrammarSymbol, Dictionary<int, MethodInfo>> CreateMethodLookup(Type pType)
        {
            Dictionary<GrammarSymbol, Dictionary<int, MethodInfo>> lookup =
                new Dictionary<GrammarSymbol, Dictionary<int, MethodInfo>>();

            IEnumerable<MethodInfo> methods = SymbolHandler.SelectSymbolHandlers(pType);
            foreach (MethodInfo info in methods)
            {
                SymbolHandler symbolAttr = SymbolHandler.getSymbolHandler(info);
                if (!lookup.ContainsKey(symbolAttr.Symbol))
                {
                    lookup.Add(symbolAttr.Symbol, new Dictionary<int, MethodInfo>());
                }
                lookup[symbolAttr.Symbol].Add(info.GetParameters().Length, info);
            }
            return lookup;
        }

        /// <summary>
        /// Gets a list of symbols a type implements.
        /// </summary>
        /// <param name="pType">The type to check</param>
        /// <returns>A list of symbols.</returns>
        public static IEnumerable<GrammarSymbol> getSupportedSymbols(Type pType)
        {
            IEnumerable<MethodInfo> methods = SymbolHandler.SelectSymbolHandlers(pType);
            return (from method in methods
                    let symbolAttr = SymbolHandler.getSymbolHandler(method)
                    select symbolAttr.Symbol).Distinct();
        }

        /// <summary>
        /// Executes a method on this object that matches the argument types.
        /// </summary>
        /// <param name="pValues">The argument values.</param>
        /// <returns>The return value, or null if no return value.</returns>
        public Data Execute(object[] pValues)
        {
#if DEBUG
            GrammarSymbol type = Cursor.Node.Type;
            if (!_methods.ContainsKey(type))
            {
                throw new InvalidArgumentException(
                    string.Format("{0} does not implement <{1}>", GetType().FullName, type),Cursor.Node);
            }
            if (!_methods[type].ContainsKey(pValues.Length))
            {
                throw new InvalidArgumentException(
                    string.Format("{0} does not have {1} argument method for <{2}>", GetType().FullName, pValues.Length,type),Cursor.Node);
            }
#endif
            try
            {
                return (Data)_methods[Cursor.Node.Type][pValues.Length].Invoke(this, pValues);
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException is RunTimeException)
                {
                    throw e.InnerException;
                }
                throw;
            }
        }
    }
}