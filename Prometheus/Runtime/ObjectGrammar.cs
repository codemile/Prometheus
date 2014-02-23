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
        private InstanceType CreateInstance(StackSpace pSpace, DeclarationType pDecl)
        {
            InstanceType inst = new InstanceType(pSpace);
            if (pDecl.Base == null)
            {
                return inst;
            }

            DeclarationType baseType = Cursor.Get<DeclarationType>(pDecl.Base);
            StackSpace baseSpace = new StackSpace(pSpace);
            InstanceType baseInst = CreateInstance(baseSpace, baseType);
            ClosureType baseFunc = new ClosureType(baseInst, baseType.Constructor);
            inst.GetMembers().Create(IdentifierType.BASE, baseFunc);

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
        /// Set what packages are being used by the current code.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ImportDecl)]
        public DataType Import(QualifiedType pPackage)
        {
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Sets the current namespace
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NameSpace)]
        public DataType NameSpace(QualifiedType pNameSpace)
        {
            Cursor.NameSpace = pNameSpace;
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
            // TODO: Create a place to store declarations
            QualifiedType className = new QualifiedType(new IdentifierType(pId.ToString()));
            DeclarationType decl = Cursor.Get<DeclarationType>(className);

            StackSpace objSpace = new StackSpace();

            InstanceType inst = CreateInstance(objSpace, decl);

            iMemorySpace prevStorage = Cursor.Stack;
            Cursor.Stack = inst.GetMembers();

            try
            {
                DataType[] arguments = new DataType[pArguments.Count];
                for (int i = 0, c = arguments.Length; i < c; i++)
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
                Cursor.Stack = prevStorage;
            }

            return inst;
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DataType ObjectDeclare(IdentifierType pObjectName, ClosureType pConstructor)
        {
            return ObjectDeclare(pObjectName, ArrayType.Empty, pConstructor);
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DataType ObjectDeclare(IdentifierType pObjectName, ArrayType pParameters, ClosureType pConstructor)
        {
            QualifiedType className = new QualifiedType(Cursor.NameSpace, pObjectName);
            DeclarationType decl = new DeclarationType(
                className,
                new ClosureType(pConstructor.Function, pParameters));
            Cursor.Stack.Create(className.ToString(), decl);
            return decl;
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DataType ObjectDeclare(QualifiedType pBaseName, IdentifierType pObjectName, ArrayType pParameters,
                                      ClosureType pConstructor)
        {
            QualifiedType className = new QualifiedType(Cursor.NameSpace, pObjectName);
            DeclarationType decl = new DeclarationType(
                pBaseName,
                className,
                new ClosureType(pConstructor.Function, pParameters));
            Cursor.Stack.Create(className.ToString(), decl);
            return decl;
        }
    }
}