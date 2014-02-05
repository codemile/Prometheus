using System.Collections.Generic;
using System.Linq;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;

namespace Prometheus.Runtime
{
    public class Arguments
    {
        /// <summary>
        /// Collects the arguments for a function from the node.
        /// </summary>
        public static Dictionary<string, Data> CollectArguments(Node pNode, Data pArguments)
        {
            int argCount = pNode.Data.Count;

            ArgumentList list = pArguments.getArgumentList();
            if (list.Count < argCount)
            {
                list.AddRange(Enumerable.Repeat(Data.Undefined, argCount - list.Count));
            }

            Dictionary<string, Data> variables = new Dictionary<string, Data>(pNode.Data.Count);
            for (int i = 0; i < argCount; i++)
            {
                variables.Add(pNode.Data[i].getIdentifier().Name, list[i]);
            }
            return variables;
        }
    }
}