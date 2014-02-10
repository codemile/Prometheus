using System.Collections.Generic;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a collection of data to be passed as arguments to a function.
    /// </summary>
    public class ArgumentListType : iDataType
    {
        /// <summary>
        /// Arguments
        /// </summary>
        public readonly List<iDataType> Arguments;

        /// <summary>
        /// Constructor
        /// </summary>
        public ArgumentListType()
            : this(new iDataType[] {})
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pArguments"></param>
        public ArgumentListType(IEnumerable<iDataType> pArguments)
        {
            Arguments = new List<iDataType>(pArguments);
        }
    }
}