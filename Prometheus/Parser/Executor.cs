using System.Collections.Generic;
using System.Linq;
using Prometheus.Compile.Optomizer;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Runtime.Creators;

namespace Prometheus.Parser
{
    public class Executor
    {
        /// <summary>
        /// The current cursor
        /// </summary>
        public readonly Cursor Cursor;

        /// <summary>
        /// All the objects that implement symbol methods.
        /// </summary>
        private readonly Dictionary<GrammarSymbol, PrometheusObject> _prometheusObjects;

        /// <summary>
        /// Constructor
        /// </summary>
        public Executor()
        {
            Cursor = new Cursor();
            _prometheusObjects = ObjectFactory.Create(new object[] {this});
        }

        /// <summary>
        /// Collects all the objects that implement optimizers.
        /// </summary>
        /// <returns>A collection of optimizers</returns>
        public List<iNodeOptimizer> getOptimizers()
        {
            return (from pair in _prometheusObjects
                    let node = pair.Value as iNodeOptimizer
                    where node != null
                    select node).Distinct().ToList();
        }

        /// <summary>
        /// Executes a node
        /// </summary>
        public Data Execute(Node pNode, Dictionary<string, Data> pVariables)
        {
            using (Cursor.Scope = new VariableScope(Cursor, pVariables))
            {
                return WalkDownChildren(pNode);
            }
        }

        /// <summary>
        /// Walks the node tree propagating data up the tree.
        /// </summary>
        /// <param name="pParent">The parent node</param>
        /// <returns>The resulting data</returns>
        private Data WalkDownChildren(Node pParent)
        {
            switch (pParent.Type)
            {
                case GrammarSymbol.FunctionExpression:
                    return new Data(pParent);

                case GrammarSymbol.Program:
                case GrammarSymbol.Block:
                case GrammarSymbol.Statements:
                {
                    for (int i = 0, c = pParent.Children.Count; i < c; i++)
                    {
                        WalkDownChildren(pParent.Children[i]);
                    }
                    return Data.Undefined;
                }

                case GrammarSymbol.IfControl:
                {
                    if (pParent.Children.Count == 2)
                    {
                        Data exp = WalkDownChildren(pParent.Children[0]);
                        if (!exp.GetBool())
                        {
                            return Data.Undefined;
                        }
                        using (Cursor.Scope = new VariableScope(Cursor))
                        {
                            return WalkDownChildren(pParent.Children[1]);
                        }
                    }
                    if (pParent.Children.Count == 3)
                    {
                        Data _if = WalkDownChildren(pParent.Children[0]);
                        if (_if.GetBool())
                        {
                            using (Cursor.Scope = new VariableScope(Cursor))
                            {
                                return WalkDownChildren(pParent.Children[1]);
                            }
                        }
                        using (Cursor.Scope = new VariableScope(Cursor))
                        {
                            return WalkDownChildren(pParent.Children[2]);
                        }
                    }
                    throw new AssertionException(
                        string.Format("Invalid child count. Expected (2 or 3) Found <{0}>", pParent.Children.Count),
                        pParent);
                }

                case GrammarSymbol.DoWhileControl:
                case GrammarSymbol.DoUntilControl:
                {
#if DEBUG
                    AssertChildren(pParent, 2);
#endif
                    try
                    {
                        while (pParent.Type == GrammarSymbol.DoWhileControl
                            ? WalkDownChildren(pParent.Children[0]).GetBool()
                            : !WalkDownChildren(pParent.Children[0]).GetBool())
                        {
                            try
                            {
                                WalkDownChildren(pParent.Children[1]);
                            }
                            catch (ContinueException)
                            {
                            }
                        }
                    }
                    catch (BreakException)
                    {
                    }
                    return Data.Undefined;
                }

                case GrammarSymbol.LoopWhileControl:
                case GrammarSymbol.LoopUntilControl:
                {
#if DEBUG
                    AssertChildren(pParent, 2);
#endif
                    try
                    {
                        do
                        {
                            try
                            {
                                WalkDownChildren(pParent.Children[0]);
                            }
                            catch (ContinueException)
                            {
                            }
                        } while (pParent.Type == GrammarSymbol.LoopWhileControl
                            ? WalkDownChildren(pParent.Children[1]).GetBool()
                            : !WalkDownChildren(pParent.Children[1]).GetBool());
                    }
                    catch (BreakException)
                    {
                    }
                    return Data.Undefined;
                }

                case GrammarSymbol.ForControl:
                case GrammarSymbol.ForStepControl:
                {
#if DEBUG
                    AssertChildren(pParent, (pParent.Type == GrammarSymbol.ForControl) ? 3 : 4);
                    AssertData(pParent, 1);
#endif
                    return Data.Undefined;
                }

                case GrammarSymbol.BreakControl:
                    throw new BreakException();

                case GrammarSymbol.ContinueControl:
                    throw new ContinueException();
            }

#if DEBUG
            AssertNode(pParent);
#endif

            PrometheusObject proObj = _prometheusObjects[pParent.Type];

            int dCount = pParent.Data.Count;
            object[] values = new object[pParent.Children.Count + dCount];
            for (int i = 0, c = dCount; i < c; i++)
            {
                values[i] = pParent.Data[i];
            }
            for (int i = 0, j = dCount, c = pParent.Children.Count; i < c; i++, j++)
            {
                values[j] = WalkDownChildren(pParent.Children[i]);
            }

            try
            {
                Cursor.Node = pParent;
                return proObj.Execute(values);
            }
            catch (IdentifierException e)
            {
                IdentifierException.Rethrow(e, pParent);
            }

            return Data.Undefined;
        }

#if DEBUG
        /// <summary>
        /// Checks that a node has the required number of children.
        /// </summary>
        /// <param name="pNode">The node to check.</param>
        /// <param name="pChildCount">The expected number of children.</param>
        private static void AssertChildren(Node pNode, int pChildCount)
        {
            if (pNode.Children.Count != pChildCount)
            {
                throw new AssertionException(
                    string.Format("Invalid child count. Expected <{0}> Found <{1}>", pChildCount, pNode.Children.Count),
                    pNode);
            }
        }

        /// <summary>
        /// Checks that a node has the required number of data elements.
        /// </summary>
        /// <param name="pNode">The node to check.</param>
        /// <param name="pDataCount">The expected number of children.</param>
        private static void AssertData(Node pNode, int pDataCount)
        {
            if (pNode.Data.Count != pDataCount)
            {
                throw new AssertionException(
                    string.Format("Invalid data count. Expected <{0}> Found <{1}>", pDataCount, pNode.Data.Count), pNode);
            }
        }

        /// <summary>
        /// Validates that the node is structured as expected.
        /// </summary>
        /// <param name="pNode">The node to validate</param>
        private void AssertNode(Node pNode)
        {
            if (!_prometheusObjects.ContainsKey(pNode.Type))
            {
                throw new AssertionException(string.Format("Symbol <{0}> is not implemented", pNode.Type), pNode);
            }
        }
#endif

        /// <summary>
        /// Performs optimization of a node
        /// </summary>
        /// <param name="pNode"></param>
        /// <returns></returns>
        public Node Optimize(Node pNode)
        {
            // run optimizers on the node
            Cursor.Node = pNode;
            foreach (iNodeOptimizer nodeOp in from pair in _prometheusObjects
                                              let node = pair.Value as iNodeOptimizer
                                              where node != null
                                              select node)
            {
                pNode = nodeOp.Optomize(pNode);
                if (pNode == null)
                {
                    return null;
                }
            }

            return pNode;
        }
    }
}