using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Parser.Executors
{
    /// <summary>
    /// Uses reflection to create executor objects.
    /// </summary>
    public static class ExecutorReflector
    {
        /// <summary>
        /// Creates a lookup table for grammar IDs and methods on an object.
        /// </summary>
        /// <param name="pType">The class type to inspect</param>
        /// <typeparam name="TKey">The class type for the grammar ID</typeparam>
        /// <typeparam name="TAttribute">The attribute that holds the ID</typeparam>
        /// <returns>The lookup table</returns>
        public static Dictionary<TKey, Dictionary<int, MethodInfo>> CreateMethodLookup<TKey, TAttribute>(Type pType)
            where TAttribute : ExecuteAttribute
        {
            Dictionary<TKey, Dictionary<int, MethodInfo>> lookup =
                new Dictionary<TKey, Dictionary<int, MethodInfo>>();

            IEnumerable<MethodInfo> methods = SelectMethodsByAttribute<TAttribute>(pType);
            foreach (MethodInfo info in methods)
            {
                TAttribute attribute = getSymbolHandler<TAttribute>(info);
                TKey key = attribute.GetExecutorType<TKey>();
                if (!lookup.ContainsKey(key))
                {
                    lookup.Add(key, new Dictionary<int, MethodInfo>());
                }
                lookup[key].Add(info.GetParameters().Length, info);
            }
            return lookup;
        }

        /// <summary>
        /// Finds all the methods marked as a symbol handler.
        /// </summary>
        /// <param name="pType"></param>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> SelectMethodsByAttribute<T>(Type pType) where T : Attribute
        {
            IEnumerable<MethodInfo> methods = from method in pType.GetMethods()
                                              where
                                                  method.IsPublic &&
                                                  !method.IsStatic &&
                                                  !method.IsConstructor &&
                                                  !method.ContainsGenericParameters &&
                                                  method.GetCustomAttributes(true).Any(pObj=>pObj is T)
                                              //method.GetParameters()
                                              //.All(pParam=>pParam.ParameterType == typeof (Data)) &&
                                              //method.ReturnType == typeof (Data)
                                              select method;
            return methods;
        }

        /// <summary>
        /// Finds the attribute object assigned to a method.
        /// </summary>
        /// <param name="pInfo">The method info</param>
        /// <returns>The attribute object</returns>
        public static T getSymbolHandler<T>(MethodInfo pInfo) where T : Attribute
        {
            return (T)pInfo.GetCustomAttributes(true).FirstOrDefault(pObj=>pObj is T);
        }
    }
}