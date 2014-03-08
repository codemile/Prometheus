using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles grammar related to declaring objects.
    /// </summary>
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class Objects : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Objects(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DeclarationType ObjectDeclare(Node pNode, IdentifierType pObjectName, FunctionType pConstructor)
        {
            return ObjectDeclare(pNode, pObjectName, ArrayType.Empty, pConstructor);
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DeclarationType ObjectDeclare(Node pNode, IdentifierType pObjectName, IEnumerable<DataType> pParameters,
                                             FunctionType pConstructor)
        {
            QualifiedType className = new QualifiedType(Cursor.Package, pObjectName);
            DeclarationType decl = new DeclarationType(
                className,
                new FunctionType(pConstructor.Entry, pParameters));
            Cursor.Stack.Create(className.ToString(), decl);
            return decl;
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DeclarationType ObjectDeclare(Node pNode, QualifiedType pBaseName, IdentifierType pObjectName,
                                             IEnumerable<DataType> pParameters,
                                             FunctionType pConstructor)
        {
            QualifiedType className = new QualifiedType(Cursor.Package, pObjectName);
            DeclarationType decl = new DeclarationType(
                pBaseName,
                className,
                new FunctionType(pConstructor.Entry, pParameters));
            Cursor.Stack.Create(className.ToString(), decl);
            return decl;
        }
    }
}