using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
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
        /// Handles while loop block.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LoopWhileControl)]
        public UndefinedType LoopWhile(DataType pCondition, FunctionType pBlock)
        {
            try
            {
                while (ResolveBool(pCondition))
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
        /// Handles until loop block.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.LoopUntilControl)]
        public UndefinedType LoopUntil(DataType pCondition, FunctionType pBlock)
        {
            try
            {
                while (!ResolveBool(pCondition))
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
        [ExecuteSymbol(GrammarSymbol.DoWhileControl)]
        public UndefinedType LoopDoWhile(DataType pCondition, FunctionType pBlock)
        {
            try
            {
                do
                {
                    Executor.ExecuteContinuable(pBlock);
                } while (ResolveBool(pCondition));
            }
            catch (BreakException)
            {
            }
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Handles until loop block.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.DoUntilControl)]
        public UndefinedType LoopDoUntil(DataType pCondition, FunctionType pBlock)
        {
            try
            {
                do
                {
                    Executor.ExecuteContinuable(pBlock);
                } while (!ResolveBool(pCondition));
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
        public UndefinedType LoopFor(FunctionType pDeclare, FunctionType pExpression, FunctionType pStep, FunctionType pBlock)
        {
            using (Cursor.Stack = new CursorSpace(Cursor))
            {
                Executor.WalkDownChildren(pDeclare.Entry);
                try
                {
                    DataType value = Executor.WalkDownChildren(pExpression.Entry);
                    while (ResolveBool(value))
                    {
                        Executor.ExecuteContinuable(pBlock);
                        Executor.WalkDownChildren(pStep.Entry);
                        value = Executor.WalkDownChildren(pExpression.Entry);
                    }
                }
                catch (BreakException)
                {
                }
            }
            return UndefinedType.Undefined;
        }

    }
}