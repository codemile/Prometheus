using System.Collections.Generic;
using Prometheus.Nodes.Types;
using Prometheus.Storage;

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
        private static readonly KeyValuePair<Instance, AliasType> _empty = new KeyValuePair<Instance, AliasType>(null,
            null);

        /// <summary>
        /// The storage of objects
        /// </summary>
        private readonly HeapSpace _heap;

        /// <summary>
        /// The alias reference
        /// </summary>
        public AliasType AliasType;

        /// <summary>
        /// The new instance of the object
        /// </summary>
        public Instance Inst;

        /// <summary>
        /// Walks the inheritance of declarations creating each from the
        /// bottom up.
        /// </summary>
        private KeyValuePair<Instance, AliasType> CreateAll(Declaration pDecl)
        {
            KeyValuePair<Instance, AliasType> baseInst = _empty;
            if (pDecl.Base != null)
            {
                baseInst = CreateAll(pDecl.Base);
            }

            Instance inst = new Instance(pDecl.Constructor);
            AliasType aliasType = _heap.Add(inst);

            inst.Members.Create("this", aliasType);

            if (baseInst.Value != null)
            {
                inst.Members.Create("base", baseInst.Value);
            }

            return new KeyValuePair<Instance, AliasType>(inst, aliasType);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateInherited(HeapSpace pHeap, Declaration pDecl)
        {
            _heap = pHeap;

            KeyValuePair<Instance, AliasType> inst = CreateAll(pDecl);
            Inst = inst.Key;
            AliasType = inst.Value;
        }
    }
}