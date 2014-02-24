using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles the execution of a for loop.
    /// </summary>
    public class HandleLoopFor : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.ForControl
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleLoopFor(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
#if DEBUG
            ExecutorAssert.Children(pNode, 4);
#endif
            Node forDeclare = pNode.Children[0];
            Node forExpression = pNode.Children[1];
            Node forStep = pNode.Children[2];
            Node forBlock = pNode.Children[3];

            try
            {
                ExecuteChildren(forDeclare);
                while (Executor.WalkDownChildren(forExpression).getBool())
                {
                    ExecuteBlock(forBlock);
                    if (forStep.Type == GrammarSymbol.ForStep && forStep.Children.Count == 0)
                    {
                        continue;
                    }
                    Executor.WalkDownChildren(forStep);
                }
            }
            catch (BreakException)
            {
            }

            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Ensure the for statement contains required children.
        /// </summary>
        public override bool OptimizeChild(Node pParent, Node pChild)
        {
            // promote the child
            if (pChild.Type == GrammarSymbol.ForExpression)
            {
#if DEBUG
                ExecutorAssert.Children(pChild, 1);
#endif
                int where = pParent.Children.IndexOf(pChild);
                pParent.Children.RemoveAt(where);
                pParent.Children.Insert(where,pChild.FirstChild());

                return true;
            }

            if (pChild.Type != GrammarSymbol.ForControl || pChild.Children.Count == 4)
            {
                return false;
            }

            if (pChild.Children[0].Type != GrammarSymbol.ForDeclare)
            {
                pChild.Children.Insert(0, new Node(GrammarSymbol.ForDeclare, pChild.Location));
                return true;
            }

            return false;
        }
    }
}