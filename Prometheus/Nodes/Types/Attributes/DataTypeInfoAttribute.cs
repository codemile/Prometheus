using System;

namespace Prometheus.Nodes.Types.Attributes
{
    /// <summary>
    /// Describes how a DataType object is represented as a type in the parser.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class DataTypeInfoAttribute : Attribute
    {
        /// <summary>
        /// The display name for the type.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Constructor
        /// </summary>
        public DataTypeInfoAttribute(string pName)
        {
            Name = pName.Trim().ToLower();
        }
    }
}