using System;
using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors.Attributes;
using Prometheus.Parser.Executors.Handlers;
using Prometheus.Storage;

namespace Prometheus.Parser.Executors
{
    /// <summary>
    /// Handles execution of a node in the tree.
    /// </summary>
    public class Executor : IDisposable, iExecutor
    {
        /// <summary>
        /// The current cursor
        /// </summary>
        private readonly Cursor _cursor;

        /// <summary>
        /// All the objects that implement symbol methods.
        /// </summary>
        private readonly Dictionary<GrammarSymbol, ExecutorGrammar> _grammarLookup;

        /// <summary>
        /// Objects that handle specific types of nodes.
        /// </summary>
        private readonly Dictionary<int, iExecutorHandler> _handlers;

        /// <summary>
        /// Adds a handler using the hash code of the classname for quicker access.
        /// </summary>
        private void AddHandler(iExecutorHandler pHandler)
        {
            _handlers.Add(pHandler.GetHandlerCode(), pHandler);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Executor(Cursor pCursor)
        {
            _cursor = pCursor;

            _grammarLookup =
                ObjectFactory.CreateLookupTable<GrammarSymbol, ExecutorGrammar, ExecuteSymbol>(new object[] {this});

            _handlers = new Dictionary<int, iExecutorHandler>();
            ObjectFactory.CreateExecutorHandlers(this).ForEach(AddHandler);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _cursor.Dispose();
        }

        /// <summary>
        /// The current position in the node tree.
        /// </summary>
        public Cursor GetCursor()
        {
            return _cursor;
        }

        /// <summary>
        /// Walks the node tree propagating data up the tree.
        /// </summary>
        /// <param name="pParent">The parent node</param>
        /// <returns>The resulting data</returns>
        public DataType WalkDownChildren(Node pParent)
        {
/*
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
                        throw new TestException(
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
*/
            if (pParent.Handler != 0)
            {
                return _handlers[pParent.Handler].Handle(pParent);
            }

            ExecutorBase _base;
            int dCount = pParent.Data.Count;

#if DEBUG
                ExecutorAssert.Node(_grammarLookup, pParent.Type, pParent);
#endif
            _base = _grammarLookup[pParent.Type];

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
                _cursor.Node = pParent;
                return _base.Execute(values);
            }
            catch (PrometheusException e)
            {
                if (e.Where == null)
                {
                    e.Where = pParent.Location;
                }
                throw;
            }
        }

        /// <summary>
        /// Executes a node
        /// </summary>
        public DataType Execute(Node pNode, Dictionary<string, DataType> pVariables = null)
        {
            pVariables = pVariables ?? new Dictionary<string, DataType>();
            using (_cursor.Stack = new CursorSpace(_cursor, pVariables))
            {
                return WalkDownChildren(pNode);
            }
        }
    }
}