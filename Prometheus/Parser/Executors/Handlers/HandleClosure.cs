using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles the creation of a closure function, or creates a closure object from a child node to
    /// prevent that node from being executed.
    /// For example; when creating a declaration the constructor function is turned into a closure to
    /// prevent it from being executed from the declaration is parsed.
    /// </summary>
    public class HandleClosure : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.ObjectBlock,
                                                                        GrammarSymbol.FunctionBlock,
                                                                        GrammarSymbol.TestBlock,
                                                                        GrammarSymbol.FunctionExpression
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleClosure(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
            if (pNode.Type != GrammarSymbol.FunctionExpression
                || pNode.Children.Count == 1)
            {
                return new ClosureType(pNode.FirstChild());
            }

            ArrayType arguments = Executor.WalkDownChildren(pNode.Children[0]).Cast<ArrayType>();
            Node func = pNode.Children[1];

            return new ClosureType(func, arguments);
        }
    }
}