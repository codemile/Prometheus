using System.Collections.Generic;
using System.Text;
using Logging;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;
using Prometheus.Storage;

namespace Prometheus.Objects
{
    /// <summary>
    /// Handles grammar related to declaring objects.
    /// </summary>
    public class ObjectGrammar : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectGrammar(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public DataType New(QualifiedType pId)
        {
            return New(pId, UndefinedType.Undefined);
        }

        /// <summary>
        /// Instantiates an object instance and returns a reference to that object.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public DataType New(QualifiedType pId, DataType pArguments)
        {
            DeclarationType decl = Executor.Cursor.Get<DeclarationType>(pId);

            CreateInherited created = new CreateInherited(Executor.Cursor, decl);

            iMemorySpace prevStorage = Executor.Cursor.Stack;
            Executor.Cursor.Stack = created.Inst.GetMembers();

            try
            {
                Dictionary<string, DataType> variables = new Dictionary<string, DataType>
                                                         {
                                                             {
                                                                 IdentifierType.THIS,
                                                                 created.Alias
                                                             }
                                                         };
                Executor.Execute(decl.Constructor.Function, variables);
            }
            catch (ReturnException)
            {
                // ignore return value from constructors
            }
            finally
            {
                Executor.Cursor.Stack = prevStorage;
            }

            return created.Alias;
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
/*
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DataType ObjectDeclare(QualifiedType pBaseClass, IdentifierType pIdentifier)
        {
            DataType baseType = Executor.Cursor.Resolve(pBaseClass).Read();
            if (baseType.GetType() != typeof (DeclarationType))
            {
                throw new UnexpectedErrorException(
                    string.Format("Base object <{0}> can not be used in declaration of new object type", baseType.GetType().Name));
            }

            DeclarationType decl = new DeclarationType(pBaseClass, Executor.Cursor.Node);
            Executor.Cursor.Stack.Create(pIdentifier.Name,decl);

            return decl;
        }
*/

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DataType ObjectDeclare(QualifiedType pObjectName, ClosureType pConstructor)
        {
            IdentifierType name = pObjectName.Members[0].Cast<IdentifierType>();
            DeclarationType decl = new DeclarationType(pObjectName, pConstructor);
            Executor.Cursor.Stack.Create(name.Name, decl);
            return decl;
        }

        /// <summary>
        /// Declares a new function type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.FunctionDecl)]
        public DataType FunctionDeclare(IdentifierType pFuncName, ClosureType pFunc)
        {
            Executor.Cursor.Stack.Create(pFuncName.Name, pFunc);
            return UndefinedType.Undefined;
        }
    }
}