using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Logging;
using Prometheus.Grammar;
using Prometheus.Parser;

namespace Prometheus.Runtime.Creators
{
    /// <summary>
    /// Contains a list of all the objects that extend PrometheusObject.
    /// </summary>
    public sealed class ObjectRepo
    {
#if DEBUG
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (ObjectRepo));
#endif

        /// <summary>
        /// Maps a symbol to an object instance.
        /// </summary>
        public readonly Dictionary<GrammarSymbol, PrometheusObject> Objects;

        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectRepo(Cursor pCursor)
        {
            Objects = new Dictionary<GrammarSymbol, PrometheusObject>();

            Assembly assembly = Assembly.Load("Prometheus");
            Type objType = typeof (PrometheusObject);

            Type[] types = (from type in assembly.GetExportedTypes()
                            where
                                objType.IsAssignableFrom(type) &&
                                !type.IsAbstract
                            select type).ToArray(); // for debugging

            object[] constructorParameters = {pCursor};

            foreach (Type type in types)
            {
                IEnumerable<GrammarSymbol> symbols = PrometheusObject.getSupportedSymbols(type);
                PrometheusObject proObj = (PrometheusObject)Activator.CreateInstance(type, constructorParameters);
                foreach (GrammarSymbol symbol in symbols)
                {
                    Objects.Add(symbol, proObj);

#if DEBUG
                    _logger.Debug("Symbol: <{0}> => {1}", symbol, proObj.GetType().FullName);
#endif
                }
            }
        }
    }
}