using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Properties;

namespace Prometheus.Storage
{
    /// <summary>
    /// A chain of storage spaces. When an identifier is not found
    /// in the current space the parent space is search. This search
    /// will walk up the chain all the way to the root to declare
    /// an identifier as not found.
    /// </summary>
    public class StackSpace : StorageSpace
    {
        /// <summary>
        /// The parent scope
        /// </summary>
        protected iMemorySpace Parent;

        /// <summary>
        /// Constructor
        /// </summary>
        public StackSpace()
        {
            Parent = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public StackSpace(iMemorySpace pParent)
        {
            Parent = pParent;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public StackSpace(iMemorySpace pParent, Dictionary<string, DataType> pStorage)
            : base(pStorage)
        {
            Parent = pParent;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            Parent = null;
            base.Dispose();
        }

        /// <summary>
        /// Prints a list of all variables.
        /// </summary>
        public override IEnumerable<MemoryItem> Dump(int pIndent = 0)
        {
            return Parent == null
                ? base.Dump(pIndent)
                : Parent.Dump(pIndent + 1).Union(base.Dump(pIndent));
        }

        /// <summary>
        /// Looks for the identifier in the current scope, and
        /// all parent scopes.
        /// </summary>
        /// <param name="pName">The name to find</param>
        /// <returns>The data object or Null if not found.</returns>
        public override DataType Get(string pName)
        {
            DataType d = base.Get(pName);
            if (d != null)
            {
                return d;
            }
            if (Parent != null)
            {
                return Parent.Get(pName);
            }
            throw new IdentifierInnerException(string.Format(Errors.IdentifierNotDefined, pName));
        }

        /// <summary>
        /// Looks for the identifier in the current scope, and
        /// all parent scopes.
        /// </summary>
        /// <param name="pName">The identifier to find</param>
        /// <param name="pDataType">The data to assign to the identifier</param>
        public override bool Set(string pName, DataType pDataType)
        {
            if (base.Set(pName, pDataType))
            {
                return true;
            }
            if (Parent != null)
            {
                return Parent.Set(pName, pDataType);
            }
            throw new IdentifierInnerException(string.Format(Errors.IdentifierNotDefined, pName));
        }
    }
}