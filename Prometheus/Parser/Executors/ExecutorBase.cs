using System.Collections.Generic;
using System.Reflection;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;

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
        public Data Execute(object[] pValues)
        {
            try
            {
                MethodInfo method = GetMethod(Executor.Cursor.Node, pValues.Length);
                return (Data)method.Invoke(this, pValues);
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

        /// <summary>
        /// Executes a grammar method on this object.
        /// </summary>
        /// <param name="pValues">The arguments</param>
        /// <returns>The output data</returns>
        /// <exception cref="RunTimeException">Throws runtime exceptions from inner grammar objects.</exception>
        public Data Execute(List<Data> pValues)
        {
            try
            {
                MethodInfo method = GetMethod(Executor.Cursor.Node, pValues.Count);

                ParameterInfo[] infos = method.GetParameters();
                object[] values = new object[pValues.Count];

                for (int i = 0, c = pValues.Count; i < c; i++)
                {
                    values[i] = pValues[i].Get(infos[i].ParameterType);
                }

                object result = method.Invoke(this, values);

                return new Data(result);
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