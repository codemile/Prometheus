using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Prometheus.Compile.Optimizers;
using Prometheus.Parser.Executors.Attributes;
using Prometheus.Parser.Executors.Handlers;

namespace Prometheus.Parser.Executors
{
    /// <summary>
    /// Prometheus doesn't connect grammar in the parser to the methods in compiled code. So at run-time
    /// lookup tables are created for objects that have public methods that implement the code for the grammar.
    /// This is done by using attributes on the methods, and searching the assembly for those methods.
    /// </summary>
    public static class ObjectFactory
    {
#if LOG_GRAMMAR
    /// <summary>
    /// Logging
    /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (ObjectFactory));
#endif

        /// <summary>
        /// Finds all the classes in the assembly that implement the base type, and creates instances
        /// of each type.
        /// </summary>
        /// <typeparam name="T">The type to create</typeparam>
        /// <param name="pArguments">The constructor arguments</param>
        /// <returns>A collection of those objects</returns>
        private static IEnumerable<T> CreateObjects<T>(object[] pArguments)
            where T : class
        {
            IEnumerable<Type> types = GetTypes<T>();
            return types.Select(pType=>(T)Activator.CreateInstance(pType, pArguments));
        }

        /// <summary>
        /// Creates a dictionary for mapping between TKey types and TValue objects.
        /// This allows the parser to quickly call a method on an object based upon
        /// the type of grammar feature it implements.
        /// </summary>
        /// <typeparam name="TKey">Key for dictionary and type for method attribute.</typeparam>
        /// <typeparam name="TValue">Class type of objects that implement methods for the Key</typeparam>
        /// <typeparam name="TAttribute">Class type of the attribute to find on methods</typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> CreateLookupTable<TKey, TValue, TAttribute>(object[] pArguments)
            where TValue : ExecutorBase
            where TAttribute : ExecuteAttribute
        {
            IEnumerable<TValue> objects = CreateObjects<TValue>(pArguments);

            Dictionary<TKey, TValue> table = new Dictionary<TKey, TValue>();

            foreach (TValue obj in objects)
            {
                IEnumerable<MethodInfo> methods =
                    ExecutorReflector.SelectMethodsByAttribute<TAttribute>(obj.GetType());
                foreach (MethodInfo info in methods)
                {
                    TAttribute attribute = ExecutorReflector.getSymbolHandler<TAttribute>(info);
                    TKey key = attribute.GetExecutorType<TKey>();
                    if (table.ContainsKey(key))
                    {
                        continue;
                    }
                    table.Add(key, obj);
#if LOG_GRAMMAR
                    _logger.Debug("{0}: <{1}> => {2}", typeof (TKey).Name, obj.GetType().FullName, key);
#endif
                }
            }

            return table;
        }

        /// <summary>
        /// Creates an instance of all the classes that implement the iNodeOptimizer interface.
        /// </summary>
        public static List<iNodeOptimizer> CreateNodeOptimizers(iExecutor pExecutor)
        {
            return CreateObjects<iNodeOptimizer>(new object[] {pExecutor}).ToList();
        }

        /// <summary>
        /// Finds all the classes of a given type for the current assembly.
        /// </summary>
        /// <returns>A collection of types that extend that type.</returns>
        private static IEnumerable<Type> GetTypes<T>()
            where T : class
        {
            Assembly assembly = Assembly.Load("Prometheus");
            Type[] types = (from type in assembly.GetExportedTypes()
                            where
                                typeof (T).IsAssignableFrom(type) &&
                                !type.IsAbstract
                            select type).ToArray(); // array for debugging
            return types;
        }

        /// <summary>
        /// Creates a collection of node handlers.
        /// </summary>
        public static List<iExecutorHandler> CreateExecutorHandlers(iExecutor pExecutor)
        {
            return CreateObjects<iExecutorHandler>(new object[] {pExecutor}).ToList();
        }
    }
}