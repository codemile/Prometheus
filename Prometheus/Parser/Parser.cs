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
            switch (pNode.Type)
            {
                case GrammarSymbol.Statements:
                    for (int i = 0, c = pNode.Children.Count; i < c; i++)
                    {
                        Execute(pNode.Children[i]);
                    }
                    return Data.Undefined;
                case GrammarSymbol.Statement:
                    return Execute(pNode.Children[0]);
            }

#if DEBUG
            AssertNode(pNode);
#endif

            PrometheusObject proObj = _repo.Objects[pNode.Type];

            int dCount = pNode.Data.Count;
            object[] values = new object[pNode.Children.Count + dCount];
            for (int i = 0, c = dCount; i < c; i++)
            {
                values[i] = pNode.Data[i];
            }
            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
                values[i + dCount] = Execute(pNode.Children[i]);
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
/*
            if (pNode.Children.Count != 0 && pNode.Data.Count != 0)
            {
                throw new UnexpectedErrorException("Node can not have children and data at same time", pNode);
            }
*/
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