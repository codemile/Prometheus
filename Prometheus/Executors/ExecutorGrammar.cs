using System.Collections.Generic;
using System.Reflection;
using Prometheus.Exceptions.Executor;
using Prometheus.Executors.Attributes;
using Prometheus.Grammar;
using Prometheus.Nodes;

namespace Prometheus.Executors
{
    /// <summary>
    /// All executable objects
    /// </summary>
    public abstract class ExecutorGrammar : ExecutorBase
    {
        /// <summary>
        /// A lookup table for a method. Grouped by symbol and argument count.
        /// </summary>
        private readonly Dictionary<GrammarSymbol, Dictionary<int, MethodInfo>> _methods;

        /// <summary>
        /// Constructor
        /// </summary>
        protected ExecutorGrammar(Executor pExecutor)
            : base(pExecutor)
        {
            _methods = ExecutorReflector.CreateMethodLookup<GrammarSymbol, ExecuteSymbol>(GetType());
        }

        /// <summary>
        /// Find the target method using the lookup table.
        /// </summary>
        protected override MethodInfo GetMethod(Node pNode, object[] pValues)
        {
#if DEBUG
            ValidateArguments(pValues);
#endif
            return _methods[Executor.Cursor.Node.Type][pValues.Length];
        }

#if DEBUG
        /// <summary>
        /// Performs a safety check in debug mode. The node tree should be in a stable state
        /// after being compiled. These errors should happen in a stable release.
        /// </summary>
        private void ValidateArguments(ICollection<object> pValues)
        {
            GrammarSymbol type = Executor.Cursor.Node.Type;
            if (!_methods.ContainsKey(type))
            {
                throw new InvalidArgumentException(
                    string.Format("{0} does not implement <{1}>", GetType().FullName, type), Executor.Cursor.Node);
            }
            if (!_methods[type].ContainsKey(pValues.Count))
            {
                throw new InvalidArgumentException(
                    string.Format("{0} does not have {1} argument method for <{2}>", GetType().FullName, pValues.Count,
                        type), Executor.Cursor.Node);
            }
        }
#endif
    }
}