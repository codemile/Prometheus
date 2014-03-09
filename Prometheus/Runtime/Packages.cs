using System.Linq;
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
    /// Handles grammar related to declaring objects.
    /// </summary>
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class Packages : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Packages(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Set what packages are being used by the current code.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ImportDecl)]
        public UndefinedType Import(Node pNode, QualifiedType pPackage)
        {
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Creates the name spaces for the current package.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PackageID)]
        public UndefinedType PackageID(Node pNode, QualifiedType pID)
        {
            iMemorySpace package = Cursor.Root;
            foreach (IdentifierType id in from i in pID select i.Cast<IdentifierType>())
            {
                if (package.Has(id.Name))
                {
                    DataType value = package.Get(id.Name);
                    package = value as NameSpace;
                    if (package == null)
                    {
                        throw new NameSpaceException(
                            string.Format("Package <{0}> already defined as different type <{1}>", id.Name,
                                value.GetType().Name), pNode);
                    }
                    continue;
                }

                NameSpace newSpace = new NameSpace();
                package.Create(id.Name, newSpace);
                package = newSpace;
            }

            Cursor.Package = pID;
            return UndefinedType.Undefined;
        }
    }
}