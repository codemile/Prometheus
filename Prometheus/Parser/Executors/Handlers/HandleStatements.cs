using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles node that are only responsible for executing their children.
    /// </summary>
    public class HandleStatements : ExecutorHandler
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly int _code = typeof (HandleStatements).Name.GetHashCode();

        /// <summary>
        /// The node types supported.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.Program,
                                                                        GrammarSymbol.Statements
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleStatements(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// The handler's code.
        /// </summary>
        public override int GetHandlerCode()
        {
            return _code;
        }

        /// <summary>
        /// Creates a statements block from the children of another node.
        /// </summary>
        public static Node Create(Node pNode)
        {
            Node node = new Node(GrammarSymbol.Statements, pNode.Location, _code);
            node.Children.AddRange(pNode.Children);
            return node;
        }

        /// <summary>
        /// Executes a node group and returns the result of the last node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
            for (int i = 0, c = pNode.Children.Count; i < c; i++)
            {
                DataType result = Executor.WalkDownChildren(pNode.Children[i]);
                // handle nested inner blocks.
                FunctionType block = result as FunctionType;
                if (block != null)
                {
                    Executor.Execute(block);
                }
            }
            return UndefinedType.Undefined;
        }
    }
}