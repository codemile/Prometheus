using Prometheus.Compile;
using Prometheus.Exceptions.Parser;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Runtime.Creators;

namespace Prometheus.Parser
{
    /// <summary>
    /// The run-time engine for Prometheus.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// The compiled code
        /// </summary>
        private readonly TargetCode _code;

        /// <summary>
        /// Repository of objects.
        /// </summary>
        private readonly ObjectRepo _repo;

        /// <summary>
        /// Executes an object as a statement
        /// </summary>
        /// <param name="pNode">The node being executed</param>
        private Data Execute(Node pNode)
        {
            if (pNode.Type == GrammarSymbol.Statements)
            {
                for (int i = 0, c = pNode.Children.Count; i < c; i++)
                {
                    Execute(pNode.Children[i]);
                }
                return Data.Undefined;
            }

#if DEBUG
            AssertNode(pNode);
#endif

            PrometheusObject proObj = _repo.Objects[pNode.Type];

            object[] values;
            if (pNode.Children.Count != 0)
            {
                values = new object[pNode.Children.Count];
                for (int i = 0, c = pNode.Children.Count; i < c; i++)
                {
                    values[i] = Execute(pNode.Children[i]);
                }
            }
            else if (pNode.Data.Count != 0)
            {
                values = new object[pNode.Data.Count];
                for (int i = 0, c = pNode.Data.Count; i < c; i++)
                {
                    values[i] = pNode.Data[i];
                }
            }
            else
            {
                values = new object[0];
            }

            return proObj.Execute(pNode, values);
        }

#if DEBUG
        /// <summary>
        /// Validates that the node is structured as expected.
        /// </summary>
        /// <param name="pNode">The node to validate</param>
        private void AssertNode(Node pNode)
        {
            if (!_repo.Objects.ContainsKey(pNode.Type))
            {
                throw new UnsupportedSymbolException("Symbol is not implemented", pNode);
            }
            if (pNode.Children.Count != 0 && pNode.Data.Count != 0)
            {
                throw new UnexpectedErrorException("Node can not have children and data at same time", pNode);
            }
        }
#endif

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pCode">The compiled code to parse.</param>
        public Parser(TargetCode pCode)
        {
            _code = pCode;
            _repo = new ObjectRepo();
        }

        /// <summary>
        /// Runs the code
        /// </summary>
        public void Run()
        {
            Execute(_code.Root);
        }
    }
}