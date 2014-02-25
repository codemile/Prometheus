using System;
using System.Collections.Generic;
using Prometheus.Exceptions;
using Prometheus.Exceptions.Executor;
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
            if (pParent.Handler != 0)
            {
                return _handlers[pParent.Handler].Handle(pParent);
            }

            int dCount = pParent.Data.Count;

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
#if DEBUG
                ExecutorAssert.Node(_grammarLookup, pParent.Type, pParent);
#endif
                ExecutorBase _base = _grammarLookup[pParent.Type];
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
        /// Executes a function reference.
        /// </summary>
        public DataType Execute(FunctionType pBlock)
        {
            using (_cursor.Stack = new CursorSpace(_cursor))
            {
                return WalkDownChildren(pBlock.Entry);
            }
        }

        /// <summary>
        /// Executes a block of code that supports the continue statement
        /// to forward a loop.
        /// </summary>
        public DataType ExecuteContinuable(FunctionType pBlock)
        {
            try
            {
                return Execute(pBlock);
            }
            catch (ContinueException)
            {
            }
            return UndefinedType.Undefined;
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