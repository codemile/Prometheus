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
        /// The current cursor
        /// </summary>
        private Cursor _cursor;

        /// <summary>
        /// Repository of objects.
        /// </summary>
        private ObjectRepo _repo;

        /// <summary>
        /// Executes an object as a statement
        /// </summary>
        private Data Execute(Node pNode)
        {
            switch (pNode.Type)
            {
                case GrammarSymbol.Program:
                case GrammarSymbol.Block:
                case GrammarSymbol.Statements:
                {
                    for (int i = 0, c = pNode.Children.Count; i < c; i++)
                    {
                        Execute(pNode.Children[i]);
                    }
                    return Data.Undefined;
                }
                case GrammarSymbol.IfControl:
                {
                    if (pNode.Children.Count == 2)
                    {
                        Data exp = Execute(pNode.Children[0]);
                        if (!exp.GetBool())
                        {
                            return Data.Undefined;
                        }
                        using (_cursor.Scope = new VariableScope(_cursor))
                        {
                            return Execute(pNode.Children[1]);
                        }
                    }
                    if (pNode.Children.Count == 3)
                    {
                        Data _if = Execute(pNode.Children[0]);
                        if (_if.GetBool())
                        {
                            using (_cursor.Scope = new VariableScope(_cursor))
                            {
                                return Execute(pNode.Children[1]);
                            }
                        }
                        using (_cursor.Scope = new VariableScope(_cursor))
                        {
                            return Execute(pNode.Children[2]);
                        }
                    }
                    throw new AssertionException(
                        string.Format("Invalid child count. Expected (2 or 3) Found <{0}>", pNode.Children.Count),
                        pNode);
                }
                case GrammarSymbol.DoWhileControl:
                case GrammarSymbol.DoUntilControl:
                {
#if DEBUG
                    AssertChildren(pNode, 2);
#endif
                    try
                    {
                        while (pNode.Type == GrammarSymbol.DoWhileControl
                            ? Execute(pNode.Children[0]).GetBool()
                            : !Execute(pNode.Children[0]).GetBool())
                        {
                            try
                            {
                                Execute(pNode.Children[1]);
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
                    AssertChildren(pNode, 2);
#endif
                    try
                    {
                        do
                        {
                            try
                            {
                                Execute(pNode.Children[0]);
                            }
                            catch (ContinueException)
                            {
                            }
                        } while (pNode.Type == GrammarSymbol.LoopWhileControl
                            ? Execute(pNode.Children[1]).GetBool()
                            : !Execute(pNode.Children[1]).GetBool());
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
                    AssertChildren(pNode, (pNode.Type == GrammarSymbol.ForControl) ? 3 : 4);
                    AssertData(pNode, 1);
#endif
                    return Data.Undefined;
                }
                case GrammarSymbol.BreakControl:
                    throw new BreakException();
                case GrammarSymbol.ContinueControl:
                    throw new ContinueException();
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
            for (int i = 0, j = dCount, c = pNode.Children.Count; i < c; i++, j++)
            {
                values[j] = Execute(pNode.Children[i]);
            }

            try
            {
                _cursor.Node = pNode;
                return proObj.Execute(values);
            }
            catch (IdentifierException e)
            {
                IdentifierException.Rethrow(e, pNode);
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
            if (!_repo.Objects.ContainsKey(pNode.Type))
            {
                throw new AssertionException(string.Format("Symbol <{0}> is not implemented", pNode.Type), pNode);
            }
        }
#endif

        /// <summary>
        /// Runs the code
        /// </summary>
        public void Run(TargetCode pCode)
        {
            _cursor = new Cursor(pCode.Root);
            _repo = new ObjectRepo(_cursor);

            using (_cursor.Scope = new VariableScope(_cursor))
            {
                Execute(_cursor.Node);
            }
        }
    }
}