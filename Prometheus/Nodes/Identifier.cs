namespace Prometheus.Nodes
{
    /// <summary>
    /// Holds the name of a reference, such as a variable name.
    /// </summary>
    public class Identifier
    {
        /// <summary>
        /// the display name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Constructor
        /// </summary>
        public Identifier(string pName)
        {
            Name = pName.ToLower();
        }
    }
}