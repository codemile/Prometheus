using System;
using System.Diagnostics;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Represents an undefined value.
    /// </summary>
    [DebuggerDisplay("Undefined")]
    public class UndefinedType : DataType
    {
        /// <summary>
        /// Debug message
        /// </summary>
        public override string ToString()
        {
            return "Undefined";
        }
    }
}