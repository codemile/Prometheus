using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;

namespace Prometheus.Runtime.Creators
{
    /// <summary>
    /// Defines a method that executes code for a Grammar Symbol.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class SymbolHandler : Attribute
    {
        /// <summary>
        /// The symbol the method implement.
        /// </summary>
        public readonly GrammarSymbol Symbol;

        /// <summary>
        /// Construct
        /// </summary>
        /// <param name="pSymbol">The symbol the method implement.</param>
        public SymbolHandler(GrammarSymbol pSymbol)
        {
            Symbol = pSymbol;
        }

        /// <summary>
        /// Finds all the methods marked as a symbol handler.
        /// </summary>
        /// <param name="pType"></param>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> SelectSymbolHandlers(Type pType)
        {
            IEnumerable<MethodInfo> methods = from method in pType.GetMethods()
                                              where
                                                  method.IsPublic &&
                                                  !method.IsStatic &&
                                                  !method.IsConstructor &&
                                                  !method.ContainsGenericParameters &&
                                                  method.GetCustomAttributes(true).Any(pObj=>pObj is SymbolHandler) &&
                                                  method.GetParameters()
                                                      .All(pParam=>pParam.ParameterType == typeof (Data)) &&
                                                  method.ReturnType == typeof (Data)
                                              select method;
            return methods;
        }

        /// <summary>
        /// Finds the attribute object assigned to a method.
        /// </summary>
        /// <param name="pInfo">The method info</param>
        /// <returns>The attribute object</returns>
        public static SymbolHandler getSymbolHandler(MethodInfo pInfo)
        {
            return (SymbolHandler)pInfo.GetCustomAttributes(true).FirstOrDefault(pObj=>pObj is SymbolHandler);
        }
    }
}