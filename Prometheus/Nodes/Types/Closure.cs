namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a reference to a function and the object that should be used
    /// as the "this" reference.
    /// </summary>
    public class Closure
    {
        /// <summary>
        /// The function
        /// </summary>
        public readonly Node Function;

        /// <summary>
        /// Reference to "this"
        /// </summary>
        public readonly Data This;

        /// <summary>
        /// Constructor
        /// </summary>
        public Closure(Alias pThis, Node pFunction)
        {
            This = new Data(pThis);
            Function = pFunction;
        }
    }
}