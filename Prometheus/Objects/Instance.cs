using System.Collections.Generic;
using Prometheus.Nodes.Types;

namespace Prometheus.Objects
{
    /// <summary>
    /// Holds the data associated with an instance of an object.
    /// </summary>
    public class Instance
    {
        /// <summary>
        /// Members of this object
        /// </summary>
        public readonly Dictionary<string, Data> Members;

        /// <summary>
        /// The number of references to this instance.
        /// </summary>
        public int References;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMembers">Populates this object's members from data.</param>
        public Instance(IDictionary<string, Data> pMembers)
        {
            References = 0;
            Members = new Dictionary<string, Data>(pMembers);
        }
    }
}