using System;
using System.Collections.Generic;
using System.Linq;
using Prometheus.Compile.Optomizer;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Parser.Executors.Attributes;
using Prometheus.Storage;

namespace Prometheus.Parser.Executors
{
    /// <summary>
    /// Handles execution of a node in the tree.
    /// </summary>
    public class Executor : IDisposable
    {
        /// <summary>
        /// The current cursor
        /// </summary>
        public readonly Cursor Cursor;

        /// <summary>
        /// All the objects that implement symbol methods.
        /// </summary>
        private readonly Dictionary<GrammarSymbol, ExecutorGrammar> _grammarLookup;

        /// <summary>
        /// All the objects that implement symbol methods.
        /// </summary>
        private readonly Dictionary<string, ExecutorInternal> _internalLookup;

        /// <summary>
        /// Constructor
        /// </summary>
        public Executor()
        {
            Cursor = new Cursor();

            _grammarLookup =
                ObjectFactory.CreateLookupTable<GrammarSymbol, ExecutorGrammar, ExecuteSymbol>(new object[] {this});
            _internalLookup =
                ObjectFactory.CreateLookupTable<string, ExecutorInternal, ExecuteInternal>(new object[] {this});
        }

        /// <summary>
        /// Executes an internal API function.
        /// </summary>
        /// <param name="pInternal">Name of the API to call</param>
        /// <param name="pArguments">The arguments</param>
        /// <returns>The resulting data</returns>
        public Data Execute(string pInternal, List<Data> pArguments)
        {
            object[] values = new object[pArguments.Count];
            for (int i = 0, c = pArguments.Count; i < c; i++)
            {
                values[i] = pArguments[i];
            }

            return _internalLookup[pInternal].Execute(pArguments);
        }

        /// <summary>
        /// Executes a node
        /// </summary>
        public Data Execute(Node pNode, Dictionary<string, Data> pVariables)
        {
            using (Cursor.Stack = new StackSpace(Cursor, pVariables))
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
                        if (!exp.getBool())
                        {
                            return Data.Undefined;
                        }
                        using (Cursor.Stack = new StackSpace(Cursor))
                        {
                            return WalkDownChildren(pParent.Children[1]);
                        }
                    }
                    if (pParent.Children.Count == 3)
                    {
                        Data _if = WalkDownChildren(pParent.Children[0]);
                        if (_if.getBool())
                        {
                            using (Cursor.Stack = new StackSpace(Cursor))
                            {
                                return WalkDownChildren(pParent.Children[1]);
                            }
                        }
                        using (Cursor.Stack = new StackSpace(Cursor))
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
                            ? WalkDownChildren(pParent.Children[0]).getBool()
                            : !WalkDownChildren(pParent.Children[0]).getBool())
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
                            ? WalkDownChildren(pParent.Children[1]).getBool()
                            : !WalkDownChildren(pParent.Children[1]).getBool());
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

            // root of a constructor function, execute children for new objects only.
            bool executeChildren = pParent.Type != GrammarSymbol.ObjectDecl;

            int dCount = pParent.Data.Count;
            int cChild = executeChildren ? pParent.Children.Count : 0;
            object[] values = new object[cChild + dCount];
            for (int i = 0, c = dCount; i < c; i++)
            {
                values[i] = pParent.Data[i];
            }
            for (int i = 0, j = dCount, c = cChild; i < c; i++, j++)
            {
                values[j] = WalkDownChildren(pParent.Children[i]);
            }

            try
            {
                Cursor.Node = pParent;
                return _grammarLookup[pParent.Type].Execute(values);
            }
            catch (IdentifierInnerException e)
            {
                throw new IdentifierException(e.Message, pParent);
            }
        }

        /// <summary>
        /// Executes the base implementation of the node. This is where the parser
        /// transitions from walking the node tree to executing C# code for a grammar
        /// command.
        /// </summary>
        /// <param name="pNode">The node to execute</param>
        /// <param name="pBase">The object that implements the node</param>
        /// <returns>The returning data</returns>
        private Data ExecuteBase(Node pNode, ExecutorBase pBase)
        {
            int dCount = pNode.Data.Count;
            object[] values = new object[pNode.Children.Count + dCount];
            for (int i = 0, c = dCount; i < c; i++)
            {
                values[i] = pNode.Data[i];
            }
            for (int i = 0, j = dCount, c = pNode.Children.Count; i < c; i++, j++)
            {
                values[j] = WalkDownChildren(pNode.Children[i]);
            }

            try
            {
                Cursor.Node = pNode;
                return pBase.Execute(values);
            }
            catch (IdentifierInnerException e)
            {
                throw new IdentifierException(e.Message, pNode);
            }
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
            if (!_grammarLookup.ContainsKey(pNode.Type))
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
            foreach (iNodeOptimizer nodeOp in from pair in _grammarLookup
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

        /// <summary>
        /// Returns a list of internal API functions that are reserved words.
        /// </summary>
        /// <returns>A collection of internal names.</returns>
        public IEnumerable<string> GetInternalIds()
        {
            return _internalLookup.Keys.ToList();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Cursor.Dispose();
        }
    }
}