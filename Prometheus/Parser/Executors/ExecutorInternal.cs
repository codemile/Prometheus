using System.Collections.Generic;
using System.Reflection;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Parser.Executors
{
    /// <summary>
    /// Derived by classes that implement core APIs as functions. An example
    /// would be string manipulation.
    /// </summary>
    public abstract class ExecutorInternal : ExecutorBase
    {
        /// <summary>
        /// A lookup table for a method. Grouped by symbol and argument count.
        /// </summary>
        private readonly Dictionary<string, Dictionary<int, MethodInfo>> _methods;

        /// <summary>
        /// Constructor
        /// </summary>
        protected ExecutorInternal(Executor pExecutor)
            : base(pExecutor)
        {
            _methods = ExecutorReflector.CreateMethodLookup<string, ExecuteInternal>(GetType());
        }

        /// <summary>
        /// Looks up the method to use for the internal command.
        /// </summary>
        protected override MethodInfo GetMethod(Node pNode, int pArgCount)
        {
            string name = ((IdentifierType)pNode.Data[0]).Name;
            return _methods[name][pArgCount];
        }
    }
}