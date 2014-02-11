using System.Collections.Generic;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a collection of data to be passed as arguments to a function.
    /// </summary>
    public class ArgumentListType : DataType
    {
        public readonly List<DataType> Arguments;

        public ArgumentListType()
        {
            Arguments = new List<DataType>();
        }

        public ArgumentListType(IEnumerable<DataType> pArguments)
        {
            Arguments = new List<DataType>(pArguments);
        }
    }
}