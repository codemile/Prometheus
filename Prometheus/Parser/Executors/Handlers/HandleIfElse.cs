using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Storage;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles the execution of a if/then/else block of code.
    /// </summary>
    public class HandleIfElse : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.IfControl
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleIfElse(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
            if (pNode.Children.Count == 2)
            {
                DataType exp = Executor.WalkDownChildren(pNode.Children[0]);
                if (!exp.getBool())
                {
                    return UndefinedType.Undefined;
                }

                using (Cursor.Stack = new CursorSpace(Cursor))
                {
                    return Executor.WalkDownChildren(pNode.Children[1]);
                }
            }

            if (pNode.Children.Count != 3)
            {
                throw new TestException(
                    string.Format("Invalid child count. Expected (2 or 3) Found <{0}>", pNode.Children.Count),
                    pNode);
            }

            DataType _if = Executor.WalkDownChildren(pNode.Children[0]);
            if (_if.getBool())
            {
                using (Cursor.Stack = new CursorSpace(Cursor))
                {
                    return Executor.WalkDownChildren(pNode.Children[1]);
                }
            }

            using (Cursor.Stack = new CursorSpace(Cursor))
            {
                return Executor.WalkDownChildren(pNode.Children[2]);
            }
        }
    }
}