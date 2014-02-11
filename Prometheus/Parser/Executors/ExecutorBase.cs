using System.Reflection;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors
{
    /// <summary>
    /// Base class for objects that execute code for the parser.
    /// </summary>
    public abstract class ExecutorBase
    {
        /// <summary>
        /// The executor can be used to run child nodes.
        /// </summary>
        protected readonly Executor Executor;

        /// <summary>
        /// Constructor
        /// </summary>
        protected ExecutorBase(Executor pExecutor)
        {
            Executor = pExecutor;
        }

        /// <summary>
        /// From the node and the method arguments find method on the current object that
        /// implements this feature.
        /// </summary>
        protected abstract MethodInfo GetMethod(Node pNode, int pArgCount);

        /// <summary>
        /// Executes a method on this object that matches the argument types.
        /// </summary>
        /// <param name="pValues">The argument values.</param>
        /// <returns>The return value, or null if no return value.</returns>
        public DataType Execute(object[] pValues)
        {
            try
            {
                MethodInfo method = GetMethod(Executor.Cursor.Node, pValues.Length);
                return (DataType)method.Invoke(this, pValues);
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