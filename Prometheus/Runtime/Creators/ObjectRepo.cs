using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Prometheus.Grammar;

namespace Prometheus.Runtime.Creators
{
    /// <summary>
    /// Contains a list of all the objects that extend PrometheusObject.
    /// </summary>
    public sealed class ObjectRepo
    {
        /// <summary>
        /// Maps a symbol to an object instance.
        /// </summary>
        public readonly Dictionary<GrammarSymbol, PrometheusObject> Objects;

        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectRepo()
        {
            Objects = new Dictionary<GrammarSymbol, PrometheusObject>();

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
                PrometheusObject proObj = (PrometheusObject)Activator.CreateInstance(type);
                foreach (GrammarSymbol symbol in symbols)
                {
                    Objects.Add(symbol, proObj);
                }
            }
        }
    }
}