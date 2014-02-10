using System.Collections.Generic;
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
        /// Lists object declarations.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ListObjects)]
        public void ListObjects()
        {
            Executor.Cursor.Packages.Print();
        }

        /// <summary>
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public iDataType New(IdentifierType pIdentifierType)
        {
            return New(pIdentifierType, UndefinedType.UNDEFINED);
        }

        /// <summary>
        /// Instantiates an object instance and returns a reference to that object.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public AliasType New(IdentifierType pIdentifierType, iDataType pArguments)
        {
            Declaration decl = Executor.Cursor.Packages.Get(pIdentifierType);

            CreateInherited created = new CreateInherited(Executor.Cursor.Heap, decl);

            MemorySpace prevMemory = Executor.Cursor.Stack;
            Executor.Cursor.Stack = created.Inst.Members;

            try
            {
                Executor.Execute(created.Inst.Constructor, new Dictionary<string, iDataType>());
            }
            catch (ReturnException)
            {
                // ignore return value from constructors
            }
            finally
            {
                Executor.Cursor.Stack = prevMemory;
                created.Inst.Members.Unset("this");
            }

            return created.AliasType;
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public void ObjectDeclare(StaticType pBaseType, IdentifierType pIdentifierType)
        {
            Executor.Cursor.Packages.Add(new Declaration(null, pIdentifierType, Executor.Cursor.Node));
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public void ObjectDeclare(QualifiedType pBaseType, IdentifierType pIdentifierType)
        {
            Node obj = Executor.Cursor.Node;
            Declaration baseDecl = Executor.Cursor.Packages.Get(pBaseType);
            Declaration decl = new Declaration(baseDecl, pIdentifierType, obj);
            Executor.Cursor.Packages.Add(decl);
        }
    }
}