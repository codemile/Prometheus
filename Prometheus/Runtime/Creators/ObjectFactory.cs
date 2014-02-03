using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Logging;
using Prometheus.Grammar;

namespace Prometheus.Runtime.Creators
{
    /// <summary>
    /// Contains a list of all the objects that extend PrometheusObject.
    /// </summary>
    public static class ObjectFactory
    {
#if DEBUG
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (ObjectFactory));
#endif

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pArguments">The arguments to pass to the object constructor.</param>
        public static Dictionary<GrammarSymbol, PrometheusObject> Create(object[] pArguments)
        {
            Dictionary<GrammarSymbol, PrometheusObject> objects = new Dictionary<GrammarSymbol, PrometheusObject>();

            Assembly assembly = Assembly.Load("Prometheus");
            Type objType = typeof (PrometheusObject);

            Type[] types = (from type in assembly.GetExportedTypes()
                            where
                                objType.IsAssignableFrom(type) &&
                                !type.IsAbstract
                            select type).ToArray(); // for debugging

            foreach (Type type in types)
            {
                IEnumerable<GrammarSymbol> symbols = PrometheusObject.getSupportedSymbols(type);
                PrometheusObject proObj = (PrometheusObject)Activator.CreateInstance(type, pArguments);
                foreach (GrammarSymbol symbol in symbols)
                {
                    objects.Add(symbol, proObj);

#if DEBUG
                    _logger.Debug("Symbol: <{0}> => {1}", symbol, proObj.GetType().FullName);
#endif
                }
            }

            return objects;
        }
    }
}