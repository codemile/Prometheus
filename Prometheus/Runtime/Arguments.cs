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
        public static Dictionary<string, iDataType> CollectArguments(Node pNode, ArgumentListType pArguments)
        {
            int argCount = pNode.Data.Count;

            if (pArguments.Arguments.Count < argCount)
            {
                pArguments.Arguments.AddRange(Enumerable.Repeat(UndefinedType.UNDEFINED,
                    argCount - pArguments.Arguments.Count));
            }

            Dictionary<string, iDataType> variables = new Dictionary<string, iDataType>(pNode.Data.Count);
            for (int i = 0; i < argCount; i++)
            {
                IdentifierType id = (IdentifierType)pNode.Data[i];
                variables.Add(id.Name, pArguments.Arguments[i]);
            }
            return variables;
        }
    }
}