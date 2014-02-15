using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser;

namespace Prometheus.Objects
{
    /// <summary>
    /// Handles the creation of multiple instances and chaining them
    /// together to form their inheritance.
    /// </summary>
    public class CreateInherited
    {
        /// <summary>
        /// An empty base reference
        /// </summary>
        private static readonly KeyValuePair<Instance, DataType> _empty = new KeyValuePair<Instance, DataType>(null,
            null);

        /// <summary>
        /// The alias reference
        /// </summary>
        public readonly DataType Alias;

        /// <summary>
        /// The new instance of the object
        /// </summary>
        public readonly Instance Inst;

        /// <summary>
        /// Walks the inheritance of declarations creating each from the
        /// bottom up.
        /// </summary>
        private KeyValuePair<Instance, DataType> CreateAll(Cursor pCursor, DeclarationType pDecl)
        {
            KeyValuePair<Instance, DataType> baseInst = _empty;
            if (pDecl.Base != null)
            {
                DataType baseData = pCursor.Resolve(pDecl.Base).Read();
                DeclarationType baseType = baseData as DeclarationType;
                if (baseType == null)
                {
                    throw new IdentifierInnerException(
                        string.Format("Expected base declaration type but found <{0}> instead", baseData.GetType().Name));
                }
                baseInst = CreateAll(pCursor, baseType);
            }

            Instance inst = new Instance();
            AliasType alias = pCursor.Heap.Add(inst);

            //inst.GetMembers().Create(IdentifierType.THIS, alias);

            if (baseInst.Value != null)
            {
                //inst.GetMembers().Create(IdentifierType.BASE, baseInst.Value);
            }

            return new KeyValuePair<Instance, DataType>(inst, alias);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateInherited(Cursor pCursor, DeclarationType pDecl)
        {
            KeyValuePair<Instance, DataType> inst = CreateAll(pCursor, pDecl);
            Inst = inst.Key;
            Alias = inst.Value;
        }
    }
}