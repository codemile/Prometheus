using System.Collections.Generic;
using System.Reflection;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Parser.Executors
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
        protected override MethodInfo GetMethod(Node pNode, int pArgCount)
        {
#if DEBUG
            ValidateArguments(pArgCount);
#endif
            return _methods[Cursor.Node.Type][pArgCount];
        }

#if DEBUG
        /// <summary>
        /// Performs a safety check in debug mode. The node tree should be in a stable state
        /// after being compiled. These errors should happen in a stable release.
        /// </summary>
        private void ValidateArguments(int pArgCount)
        {
            GrammarSymbol type = Cursor.Node.Type;
            if (!_methods.ContainsKey(type))
            {
                throw new InvalidArgumentException(
                    string.Format("{0} does not implement <{1}>", GetType().FullName, type), Cursor.Node);
            }
            if (!_methods[type].ContainsKey(pArgCount))
            {
                throw new InvalidArgumentException(
                    string.Format("{0} does not have {1} argument method for <{2}>", GetType().FullName, pArgCount,
                        type), Cursor.Node);
            }
        }
#endif
    }
}