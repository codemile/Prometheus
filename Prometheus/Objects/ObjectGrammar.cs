using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
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
        public Data ListObjects()
        {
            Executor.Cursor.Packages.Print();
            return Data.Undefined;
        }

        /// <summary>
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public Data New(Data pIdentifier)
        {
            return New(pIdentifier, Data.Undefined);
        }

        /// <summary>
        /// Instantiates an object instance and returns a reference to that object.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public Data New(Data pIdentifier, Data pArguments)
        {
            Declaration decl = Executor.Cursor.Packages.Get(pIdentifier.getIdentifier());

            Instance inst = new Instance();
            Data alias = Executor.Cursor.Heap.Add(inst);

            inst.Members.Create("this", alias);
            MemorySpace prevMemory = Executor.Cursor.Stack;
            Executor.Cursor.Stack = inst.Members;

            try
            {
                Executor.Execute(decl.Constructor, new Dictionary<string, Data>());
            }
            catch (ReturnException)
            {
                // ignore return value from constructors
            }
            finally
            {
                Executor.Cursor.Stack = prevMemory;
                inst.Members.Unset("this");
            }

            return alias;
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public Data ObjectDeclare(Data pBaseType, Data pIdentifier)
        {
            Node obj = Executor.Cursor.Node;
            StaticType type = pBaseType.getStaticType();
            Identifier id = pIdentifier.getIdentifier();

            Declaration decl = new Declaration(null, id, obj);
            Executor.Cursor.Packages.Add(decl);

            return Data.Undefined;
        }
    }
}