using System.Collections.Generic;
using System.Linq;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Factory class for function arguments.
    /// </summary>
    public static class Arguments
    {
        /// <summary>
        /// Collects the arguments for a function from the node.
        /// </summary>
        public static Dictionary<string, DataType> CollectArguments(Node pNode, ArrayType pArguments)
        {
            int argCount = pNode.Data.Count;

            if (pArguments.Values.Count < argCount)
            {
                pArguments.Values.AddRange(Enumerable.Repeat(UndefinedType.Undefined,
                    argCount - pArguments.Values.Count));
            }

            Dictionary<string, DataType> variables = new Dictionary<string, DataType>(pNode.Data.Count);
            for (int i = 0; i < argCount; i++)
            {
                variables.Add(((IdentifierType)pNode.Data[i]).Name, pArguments.Values[i]);
            }
            return variables;
        }
    }
}