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
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof(ObjectGrammar));

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
        public DataType ListObjects()
        {
            List<string> lines = new List<string>();
            Executor.Cursor.Packages.Print(ref lines);
            foreach (string line in lines)
            {
                _logger.Fine(line);
            }
            return DataType.Undefined;
        }

        /// <summary>
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public DataType New(ClassNameType pClassName)
        {
            return New(pClassName, DataType.Undefined);
        }

        /// <summary>
        /// Instantiates an object instance and returns a reference to that object.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.NewExpression)]
        public DataType New(ClassNameType pClassName, DataType pArguments)
        {
            Declaration decl = Executor.Cursor.Packages.Get(pClassName);

            CreateInherited created = new CreateInherited(Executor.Cursor.Heap, decl);

            iMemorySpace prevStorage = Executor.Cursor.Stack;
            Executor.Cursor.Stack = created.Inst.GetMembers();

            try
            {
                Executor.Execute(created.Inst.GetConstructor(), new Dictionary<string, DataType>());
            }
            catch (ReturnException)
            {
                // ignore return value from constructors
            }
            finally
            {
                Executor.Cursor.Stack = prevStorage;
                created.Inst.GetMembers().Unset(IdentifierType.This.Name);
            }

            return created.Alias;
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DataType ObjectDeclare(DataType pBaseClass, IdentifierType pIdentifier)
        {
            Node obj = Executor.Cursor.Node;
            Declaration baseDecl = null;
            if (pBaseClass.GetType() == typeof (ClassNameType))
            {
                ClassNameType baseType = (ClassNameType)pBaseClass;
                baseDecl = Executor.Cursor.Packages.Get(baseType);
            }
            else
            {
                throw new UnexpectedErrorException(
                    string.Format("Can not declare object of base type <{0}>", pBaseClass.GetType().FullName), obj);
            }

            Declaration decl = new Declaration(new ClassNameType(QualifiedType.Global, pIdentifier), baseDecl, obj);

            // TODO: Need to find the current namespace to declare an object.

            Executor.Cursor.Packages.Add(decl);

            return DataType.Undefined;
        }

        /// <summary>
        /// Declares a new object type
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ObjectDecl)]
        public DataType ObjectDeclare(IdentifierType pIdentifier)
        {
            Node obj = Executor.Cursor.Node;
            Declaration baseDecl = null;
            Declaration decl = new Declaration(new ClassNameType(QualifiedType.Global, pIdentifier), null, obj);

            // TODO: Need to find the current namespace to declare an object.
            Executor.Cursor.Packages.Add(decl);

            return DataType.Undefined;
        }
    }
}