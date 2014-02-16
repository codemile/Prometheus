using System.Reflection;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
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
        /// Resolves a data reference to get the value it points to.
        /// </summary>
        protected DataType Resolve(DataType pValue)
        {
            QualifiedType id = pValue as QualifiedType;
            return id == null ? pValue : Executor.Cursor.Resolve(id).Read();
        }

        /// <summary>
        /// Resolves a data reference to get the value it points to.
        /// </summary>
        protected T Resolve<T>(DataType pValue) where T : DataType
        {
            QualifiedType id = pValue as QualifiedType;
            return id == null ? (T)pValue : Executor.Cursor.Get<T>(id);
        }

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
                RunTimeException inner = e.InnerException as RunTimeException;
                if (inner != null)
                {
                    inner.Where = inner.Where ?? Executor.Cursor.Node.Location;
                    throw e.InnerException;
                }
                throw;
            }
        }
    }
}