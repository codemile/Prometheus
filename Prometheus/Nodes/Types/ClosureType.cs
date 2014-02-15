using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a reference to a function and the object that should be used
    /// as the "this" reference. The compiled flag just means that the function
    /// has been created as an object in the heap.
    /// </summary>
    public class ClosureType : DataType
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

        /// <summary>
        /// Un-compiled closure
        /// </summary>
        public ClosureType(Node pFunction)
        {
            Function = pFunction;
        }

        /// <summary>
        /// True if this closure has been compiled.
        /// </summary>
        public bool isCompiled()
        {
            return This != null;
        }

        /// <summary>
        /// Returns "function"
        /// </summary>
        public override string ToString()
        {
            return "function";
        }
    }
}