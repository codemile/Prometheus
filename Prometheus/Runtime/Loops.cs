using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;
using Prometheus.Storage;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Implements grammar for while/for loops.
    /// </summary>
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class Loops : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Loops(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Handles until loop block.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.DoUntilControl)]
        public UndefinedType LoopDoUntil(Node pNode, FunctionType pBlock, FunctionType pExpression)
        {
            try
            {
                do
                {
                    Executor.ExecuteContinuable(pBlock);
                } while (!ResolveBool(Executor.WalkDownChildren(pExpression.Entry)));
            }
            catch (BreakException)
            {
            }
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Handles while loop block.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.DoWhileControl)]
        public UndefinedType LoopDoWhile(Node pNode, FunctionType pBlock, FunctionType pExpression)
        {
            try
            {
                do
                {
                    Executor.ExecuteContinuable(pBlock);
                } while (ResolveBool(Executor.WalkDownChildren(pExpression.Entry)));
            }
            catch (BreakException)
            {
            }
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Handles execution of a for loop.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ForControl)]
        public UndefinedType LoopFor(Node pNode, FunctionType pDeclare, FunctionType pExpression, FunctionType pStep,
                                     FunctionType pBlock)
        {
            using (Cursor.Stack = new CursorSpace(Cursor))
            {
                Executor.WalkDownChildren(pDeclare.Entry);
                try
                {
                    while (ResolveBool(Executor.WalkDownChildren(pExpression.Entry)))
                    {
                        Executor.ExecuteContinuable(pBlock);
                        Executor.WalkDownChildren(pStep.Entry);
                    }
                }
                catch (BreakException)
                {
                }
            }
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Handles until loop block.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.UntilControl)]
        public UndefinedType LoopUntil(Node pNode, FunctionType pExpression, FunctionType pBlock)
        {
            try
            {
                while (!ResolveBool(Executor.WalkDownChildren(pExpression.Entry)))
                {
                    Executor.ExecuteContinuable(pBlock);
                }
            }
            catch (BreakException)
            {
            }
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Handles while loop block.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.WhileControl)]
        public UndefinedType LoopWhile(Node pNode, FunctionType pExpression, FunctionType pBlock)
        {
            try
            {
                while (ResolveBool(Executor.WalkDownChildren(pExpression.Entry)))
                {
                    Executor.ExecuteContinuable(pBlock);
                }
            }
            catch (BreakException)
            {
            }
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Handles the execution of an each loop.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.EachControl)]
        public ArrayType Each(Node pNode, PluralType pPlural, FunctionType pBlock)
        {
            Dictionary<string, DataType> variables = new Dictionary<string, DataType>
                                                     {
                                                         {pPlural.Singular.Name, UndefinedType.Undefined}
                                                     };

            ArrayType arr = new ArrayType();

            try
            {
                foreach (DataType item in pPlural.Array)
                {
                    variables[pPlural.Singular.Name] = item;
                    try
                    {
                        Executor.ExecuteContinuable(pBlock, variables);
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
    }
}