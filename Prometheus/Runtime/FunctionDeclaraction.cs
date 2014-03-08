using System.Collections.Generic;
using System.Linq;
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
    /// </summary>
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class FunctionDeclaraction : ExecutorGrammar
    {
        /// <summary>
        /// Generates a collection of variables to persist in a closure.
        /// </summary>
        private StorageSpace CreateWith(IEnumerable<DataType> pWith)
        {
            StorageSpace withValues = new StorageSpace();
            foreach (IdentifierType id in pWith.Select(pType=>pType.Cast<IdentifierType>()))
            {
                withValues.Create(id.Name, Resolve(new QualifiedType(id)));
            }
            return withValues;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FunctionDeclaraction(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Declares a new function type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.FunctionDecl)]
        public DataType Declare(
            Node pNode,
            IdentifierType pFuncName,
            IEnumerable<DataType> pParameters,
            FunctionType pBlock)
        {
            return Declare(pNode, pFuncName, pParameters, ArrayType.Empty, pBlock);
        }

        /// <summary>
        /// Declares a new function type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.FunctionDecl)]
        public DataType Declare(
            Node pNode,
            IdentifierType pFuncName,
            IEnumerable<DataType> pParameters,
            IEnumerable<DataType> pWith,
            FunctionType pBlock)
        {
            InstanceType inst = Resolve<InstanceType>(IdentifierType.This);
            ClosureType closure = new ClosureType(inst, pParameters, CreateWith(pWith), pBlock.Entry);
            Cursor.Stack.Create(pFuncName.Name, closure);
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Creates a new function as part of an expression.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.FunctionExpression)]
        public ClosureType Expression(
            Node pNode,
            IEnumerable<DataType> pParameters,
            FunctionType pBlock)
        {
            return Expression(pNode, pParameters, ArrayType.Empty, pBlock);
        }

        /// <summary>
        /// Creates a new function as part of an expression.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.FunctionExpression)]
        public ClosureType Expression(
            Node pNode,
            IEnumerable<DataType> pParameters,
            IEnumerable<DataType> pWith,
            FunctionType pBlock)
        {
            InstanceType inst = Resolve<InstanceType>(IdentifierType.This);
            return new ClosureType(inst, pParameters, CreateWith(pWith), pBlock.Entry);
        }
    }
}