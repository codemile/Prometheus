using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;
using Prometheus.Storage;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Implements grammar for while/for loops.
    /// </summary>
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
        public UndefinedType LoopDoUntil(Node pNode, FunctionType pExpression, FunctionType pBlock)
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
        public UndefinedType LoopDoWhile(Node pNode, FunctionType pExpression, FunctionType pBlock)
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
    }
}