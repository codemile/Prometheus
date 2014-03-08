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
    /// Handles grammar for creating instances of objects.
    /// </summary>
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class Instancing : ExecutorGrammar
    {
        /// <summary>
        /// Walks the inheritance of declarations creating each from the
        /// bottom up.
        /// </summary>
        private InstanceType CreateInstance(iMemorySpace pSpace, DeclarationType pDecl)
        {
            InstanceType inst = new InstanceType(pSpace);
            if (pDecl.Base == null)
            {
                return inst;
            }

            DeclarationType baseType = Cursor.Get<DeclarationType>(pDecl.Base);
            StackSpace baseSpace = new StackSpace(pSpace);
            InstanceType baseInst = CreateInstance(baseSpace, baseType);
            ClosureType baseFunc = new ClosureType(baseInst, new DataType[0], new StorageSpace(), baseType.Constructor.Entry);
            inst.GetMembers().Create(IdentifierType.BASE, baseFunc);

            return inst;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Instancing(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Instantiates an object instance and returns a reference to that object.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public DataType New(Node pNode, QualifiedType pId)
        {
            return New(pNode, pId, ArrayType.Empty);
        }

        /// <summary>
        /// Instantiates an object instance and returns a reference to that object.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public DataType New(Node pNode, QualifiedType pId, ArrayType pArguments)
        {
            // TODO: Create a place to store declarations
            //QualifiedType className = new QualifiedType(new IdentifierType(pId.ToString()));
            DeclarationType decl = Cursor.Get<DeclarationType>(pId);

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
                Dictionary<string, DataType> dataTypes = new Dictionary<string, DataType>();
                decl.Constructor.CreateArguments(ref dataTypes, arguments);
                dataTypes.Add(IdentifierType.THIS, inst);
                Executor.Execute(decl.Constructor.Entry, dataTypes);
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
    }
}