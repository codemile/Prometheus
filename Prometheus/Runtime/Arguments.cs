using System.Collections.Generic;
using System.Linq;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Runtime
{
    public class Arguments
    {
        /// <summary>
        /// Collects the arguments for a function from the node.
        /// </summary>
        public static Dictionary<string, DataType> CollectArguments(Node pNode, DataType pArguments)
        {
            int argCount = pNode.Data.Count;

            ArgumentListType listType = pArguments.getArgumentList();
            if (listType.Count < argCount)
            {
                listType.AddRange(Enumerable.Repeat(DataType.Undefined, argCount - listType.Count));
            }

            Dictionary<string, DataType> variables = new Dictionary<string, DataType>(pNode.Data.Count);
            for (int i = 0; i < argCount; i++)
            {
                variables.Add(pNode.Data[i].getIdentifier().Name, listType[i]);
            }
            return variables;
        }
    }
}