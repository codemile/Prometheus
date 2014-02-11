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
        public static Dictionary<string, DataType> CollectArguments(Node pNode, ArgumentListType pArguments)
        {
            int argCount = pNode.Data.Count;

            if (pArguments.Arguments.Count < argCount)
            {
                pArguments.Arguments.AddRange(Enumerable.Repeat(DataType.Undefined,
                    argCount - pArguments.Arguments.Count));
            }

            Dictionary<string, DataType> variables = new Dictionary<string, DataType>(pNode.Data.Count);
            for (int i = 0; i < argCount; i++)
            {
                variables.Add(((IdentifierType)pNode.Data[i]).FullName, pArguments.Arguments[i]);
            }
            return variables;
        }
    }
}