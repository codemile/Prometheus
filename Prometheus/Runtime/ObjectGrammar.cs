using System.Collections.Generic;
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
    /// Handles grammar related to declaring objects.
    /// </summary>
    public class ObjectGrammar : ExecutorGrammar
    {
        /// <summary>
        /// Walks the inheritance of declarations creating each from the
        /// bottom up.
        /// </summary>
        private InstanceType CreateInstance(DeclarationType pDecl)
        {
            InstanceType baseInst = null;
            if (pDecl.Base != null)
            {
                DeclarationType baseType = Executor.Cursor.Get<DeclarationType>(pDecl.Base);
                baseInst = CreateInstance(baseType);
            }

            InstanceType inst = new InstanceType();

            /*
                        inst.GetMembers().Create(IdentifierType.THIS, inst);
                        if (baseInst != null)
                        {
                            inst.GetMembers().Create(IdentifierType.BASE, baseInst);
                        }
            */

            return inst;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectGrammar(Executor pExecutor)
            : base(pExecutor)
        {
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

        /// <summary>
        /// Declares a new function type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.FunctionDecl)]
        public DataType FunctionDeclare(IdentifierType pFuncName, ArrayType pParameters, ClosureType pFunc)
        {
            Executor.Cursor.Stack.Create(pFuncName.Name, new ClosureType(pFunc.Function, pParameters));
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Instantiates an object instance and returns a reference to that object.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public DataType New(QualifiedType pId)
        {
            return New(pId, ArrayType.Empty);
        }

        /// <summary>
        /// Instantiates an object instance and returns a reference to that object.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public DataType New(QualifiedType pId, ArrayType pArguments)
        {
            DeclarationType decl = Executor.Cursor.Get<DeclarationType>(pId);
            InstanceType inst = CreateInstance(decl);

            iMemorySpace prevStorage = Executor.Cursor.Stack;
            Executor.Cursor.Stack = inst.GetMembers();

            try
            {
                DataType[] arguments = new DataType[pArguments.Count];
                for (int i = 0, c = arguments.Length; i < c ;i++)
                {
                    arguments[i] = Resolve(pArguments[i]);
                }
                Dictionary<string, DataType> dataTypes = decl.Constructor.CreateArguments(arguments);
                dataTypes.Add(IdentifierType.THIS, inst);
                Executor.Execute(decl.Constructor.Function, dataTypes);
            }
            catch (ReturnException)
            {
                // ignore return value from constructors
            }
            finally
            {
                Executor.Cursor.Stack = prevStorage;
            }

            return inst;
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DataType ObjectDeclare(QualifiedType pObjectName, ClosureType pConstructor)
        {
            return ObjectDeclare(pObjectName, ArrayType.Empty, pConstructor);
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DataType ObjectDeclare(QualifiedType pObjectName, ArrayType pParameters, ClosureType pConstructor)
        {
            IdentifierType name = pObjectName.Members[0].Cast<IdentifierType>();
            DeclarationType decl = new DeclarationType(pObjectName, new ClosureType(pConstructor.Function, pParameters));
            Executor.Cursor.Stack.Create(name.Name, decl);
            return decl;
        }
    }
}