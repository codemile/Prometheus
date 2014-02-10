using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a reference to a function and the object that should be used
    /// as the "this" reference.
    /// </summary>
    public class ClosureType : iDataType
    {
        /// <summary>
        /// The function
        /// </summary>
        public readonly Node Function;

        /// <summary>
        /// Reference to "this"
        /// </summary>
        public readonly AliasType This;

        /// <summary>
        /// Constructor
        /// </summary>
        public ClosureType(AliasType pThis, Node pFunction)
        {
            This = pThis;
            Function = pFunction;
        }
    }
}