using System;
using System.Collections.Generic;
using System.Linq;
using Prometheus.Compile.Optomizer;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
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
        private readonly Dictionary<string, ExecutorGeneric> _genericLookup;

        /// <summary>
        /// Creates an array object.
        /// </summary>
        private DataType CreateArray(Node pParent)
        {
            IList<DataType> array;
            switch (pParent.Type)
            {
                case GrammarSymbol.QualifiedID:
                case GrammarSymbol.ClassNameID:
                    array = new QualifiedType();
                    break;
                default:
                    array = new ArrayType();
                    break;
            }
            for (int i = 0, c = pParent.Children.Count; i < c; i++)
            {
#if DEBUG
                if (pParent.Type == GrammarSymbol.ParameterArray)
                {
                    ExecutorAssert.Data(pParent.Children[i], 1);
                    ExecutorAssert.DataType(pParent.Children[i], 0, typeof (IdentifierType));
                }
#endif
                array.Add(pParent.Type == GrammarSymbol.ParameterArray
                    ? pParent.Children[i].Data[0]
                    : WalkDownChildren(pParent.Children[i]));
            }
            return (DataType)array;
        }

        /// <summary>
        /// Executes the base implementation of the node. This is where the parser
        /// transitions from walking the node tree to executing C# code for a grammar
        /// command.
        /// </summary>
        /// <param name="pNode">The node to execute</param>
        /// <param name="pBase">The object that implements the node</param>
        /// <returns>The returning data</returns>
        private DataType ExecuteBase(Node pNode, ExecutorBase pBase)
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

        /// <summary>
        /// Walks the node tree propagating data up the tree.
        /// </summary>
        /// <param name="pParent">The parent node</param>
        /// <returns>The resulting data</returns>
        private DataType WalkDownChildren(Node pParent)
        {
            switch (pParent.Type)
            {
                // these are just holders for constant values
                case GrammarSymbol.ValidID:
                case GrammarSymbol.Value:
                case GrammarSymbol.MemberID:
                case GrammarSymbol.ImportDecl:
#if DEBUG
                    ExecutorAssert.Data(pParent, 1);
#endif
                    return pParent.Data[0];

                case GrammarSymbol.ObjectBlock:
                case GrammarSymbol.FunctionBlock:
                case GrammarSymbol.TestBlock:
                case GrammarSymbol.FunctionExpression:
                    return new ClosureType(pParent.FirstChild());

                case GrammarSymbol.Program:
                case GrammarSymbol.Block:
                case GrammarSymbol.Statements:
                {
                    for (int i = 0, c = pParent.Children.Count; i < c; i++)
                    {
                        WalkDownChildren(pParent.Children[i]);
                    }
                    return UndefinedType.Undefined;
                }

                case GrammarSymbol.IfControl:
                {
                    if (pParent.Children.Count == 2)
                    {
                        DataType exp = WalkDownChildren(pParent.Children[0]);
                        if (!exp.getBool())
                        {
                            return UndefinedType.Undefined;
                        }
                        using (Cursor.Stack = new CursorSpace(Cursor))
                        {
                            return WalkDownChildren(pParent.Children[1]);
                        }
                    }
                    if (pParent.Children.Count == 3)
                    {
                        DataType _if = WalkDownChildren(pParent.Children[0]);
                        if (_if.getBool())
                        {
                            using (Cursor.Stack = new CursorSpace(Cursor))
                            {
                                return WalkDownChildren(pParent.Children[1]);
                            }
                        }
                        using (Cursor.Stack = new CursorSpace(Cursor))
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
                    ExecutorAssert.Children(pParent, 2);
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
                    return UndefinedType.Undefined;
                }

                case GrammarSymbol.LoopWhileControl:
                case GrammarSymbol.LoopUntilControl:
                {
#if DEBUG
                    ExecutorAssert.Children(pParent, 2);
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
                    return UndefinedType.Undefined;
                }

                case GrammarSymbol.ForControl:
                case GrammarSymbol.ForStepControl:
                {
#if DEBUG
                    ExecutorAssert.Children(pParent, (pParent.Type == GrammarSymbol.ForControl) ? 3 : 4);
                    ExecutorAssert.Data(pParent, 1);
#endif
                    return UndefinedType.Undefined;
                }

                case GrammarSymbol.BreakControl:
                    throw new BreakException();

                case GrammarSymbol.ContinueControl:
                    throw new ContinueException();

                case GrammarSymbol.ArrayLiteral:
                case GrammarSymbol.ArgumentArray:
                case GrammarSymbol.ParameterArray:
                case GrammarSymbol.TestSuiteArray:
                case GrammarSymbol.QualifiedID:
                case GrammarSymbol.ClassNameID:
                    return CreateArray(pParent);
            }

            ExecutorBase _base;
            int dCount = pParent.Data.Count;

            if (pParent.Type == GrammarSymbol.Generic0Args
                || pParent.Type == GrammarSymbol.Generic1Args
                || pParent.Type == GrammarSymbol.GenericNArgs)
            {
                string name = pParent.Data[0].Cast<IdentifierType>().Name;
#if DEBUG
                ExecutorAssert.Node(_genericLookup, name, pParent);
#endif
                _base = _genericLookup[name];
                dCount--;
            }
            else
            {
#if DEBUG
                ExecutorAssert.Node(_grammarLookup, pParent.Type, pParent);
#endif
                _base = _grammarLookup[pParent.Type];
            }

            int cChild = pParent.Children.Count;
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
                return _base.Execute(values);
            }
            catch (IdentifierInnerException e)
            {
                throw new IdentifierException(e.Message, pParent);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Executor(Cursor pCursor)
        {
            Cursor = pCursor;

            _grammarLookup =
                ObjectFactory.CreateLookupTable<GrammarSymbol, ExecutorGrammar, ExecuteSymbol>(new object[] {this});
            _genericLookup =
                ObjectFactory.CreateLookupTable<string, ExecutorGeneric, ExecuteGeneric>(new object[] {this});
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Cursor.Dispose();
        }

        /// <summary>
        /// Executes an internal API function.
        /// </summary>
        /// <param name="pInternal">Name of the API to call</param>
        /// <param name="pArguments">The arguments</param>
        /// <returns>The resulting data</returns>
        public DataType Execute(IdentifierType pInternal, ArrayType pArguments)
        {
            object[] values = new object[pArguments.Count];
            for (int i = 0, c = pArguments.Count; i < c; i++)
            {
                values[i] = pArguments[i];
            }

            return _genericLookup[pInternal.Name].Execute(values);
        }

        /// <summary>
        /// Executes a node
        /// </summary>
        public DataType Execute(Node pNode, Dictionary<string, DataType> pVariables = null)
        {
            pVariables = pVariables ?? new Dictionary<string, DataType>();
            using (Cursor.Stack = new CursorSpace(Cursor, pVariables))
            {
                return WalkDownChildren(pNode);
            }
        }

        /// <summary>
        /// Returns a list of internal API functions that are reserved words.
        /// </summary>
        /// <returns>A collection of internal names.</returns>
        public IEnumerable<string> GetInternalIds()
        {
            return _genericLookup.Keys.ToList();
        }

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
    }
}