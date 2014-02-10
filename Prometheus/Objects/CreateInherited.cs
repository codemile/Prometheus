using System.Collections.Generic;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
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
        private static readonly KeyValuePair<Instance, DataType> _empty = new KeyValuePair<Instance, DataType>(null, null);

        /// <summary>
        /// The storage of objects
        /// </summary>
        private readonly HeapSpace _heap;

        /// <summary>
        /// The alias reference
        /// </summary>
        public DataType Alias;

        /// <summary>
        /// The new instance of the object
        /// </summary>
        public Instance Inst;

        /// <summary>
        /// Walks the inheritance of declarations creating each from the
        /// bottom up.
        /// </summary>
        private KeyValuePair<Instance, DataType> CreateAll(Declaration pDecl)
        {
            KeyValuePair<Instance, DataType> baseInst = _empty;
            if (pDecl.Base != null)
            {
                baseInst = CreateAll(pDecl.Base);
            }

            Instance inst = new Instance(pDecl.Constructor);
            DataType alias = _heap.Add(inst);

            inst.Members.Create("this", alias);

            if (baseInst.Value != null)
            {
                inst.Members.Create("base", baseInst.Value);
            }

            return new KeyValuePair<Instance, DataType>(inst, alias);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateInherited(HeapSpace pHeap, Declaration pDecl)
        {
            _heap = pHeap;

            KeyValuePair<Instance, DataType> inst = CreateAll(pDecl);
            Inst = inst.Key;
            Alias = inst.Value;
        }
    }
}