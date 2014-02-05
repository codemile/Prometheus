using System;

namespace Prometheus.Parser.Executors.Attributes
{
    /// <summary>
    /// Base class for attributes that identify executable methods.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public abstract class ExecuteAttribute : Attribute
    {
        /// <summary>
        /// Returns an identifier of the kind of method the derived attribute is defining.
        /// </summary>
        /// <typeparam name="T">Must match the property type in the derived class.</typeparam>
        /// <returns>The identifier</returns>
        public abstract T GetExecutorType<T>();
    }
}