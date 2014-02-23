using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles the execution of for each loops.
    /// </summary>
    public class HandleLoopEach : ExecutorHandler
    {
        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.EachControl
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleLoopEach(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
#if DEBUG
            ExecutorAssert.Children(pNode, 2);
#endif
            Node eachArray = pNode.Children[0];
            Node eachBlock = pNode.Children[1];

            PluralType plural = Executor.WalkDownChildren(eachArray).Cast<PluralType>();

            Dictionary<string, DataType> variables = new Dictionary<string, DataType>
                                                     {
                                                         {plural.Singular.Name, UndefinedType.Undefined}
                                                     };

            ArrayType arr = new ArrayType();

            try
            {
                foreach (DataType item in plural.Array)
                {
                    variables[plural.Singular.Name] = item;
                    try
                    {
                        ExecuteBlock(eachBlock, variables);
                    }
                    catch (ReturnException returnEx)
                    {
                        arr.Add(returnEx.Value);
                    }
                }
            }
            catch (BreakException)
            {
            }

            return arr;
        }

        /// <summary>
        /// Inspect a node
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <returns>Same node, a new node or null to remove it.</returns>
        public override Node Optimize(Node pNode)
        {
            if (pNode.Type != GrammarSymbol.EachControl)
            {
                return base.Optimize(pNode);
            }

#if DEBUG
            ExecutorAssert.Children(pNode, 2);
#endif
            Node eachPlural = pNode.Children[0];
            if (eachPlural.Type == GrammarSymbol.PluralID)
            {
                return base.Optimize(pNode);
            }

            // make sure first child is PluralID
            Node plural = new Node(GrammarSymbol.PluralID, eachPlural.Location);
            plural.Add(eachPlural);
            pNode.Children.RemoveAt(0);
            pNode.Children.Insert(0, plural);

            return base.Optimize(pNode);
        }
    }
}