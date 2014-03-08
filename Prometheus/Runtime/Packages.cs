using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
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
        /// Sets the package for the current executing code.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.PackageID)]
        public UndefinedType PackageID(Node pNode, QualifiedType pID)
        {
            Cursor.Package = pID;
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Set what packages are being used by the current code.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ImportDecl)]
        public UndefinedType Import(Node pNode, QualifiedType pPackage)
        {
            return UndefinedType.Undefined;
        }
    }
}