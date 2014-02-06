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
        private static readonly KeyValuePair<Instance, Data> _empty = new KeyValuePair<Instance, Data>(null, null);

        /// <summary>
        /// The storage of objects
        /// </summary>
        private readonly HeapSpace _heap;

        /// <summary>
        /// The alias reference
        /// </summary>
        public Data Alias;

        /// <summary>
        /// The new instance of the object
        /// </summary>
        public Instance Inst;

        /// <summary>
        /// Walks the inheritance of declarations creating each from the
        /// bottom up.
        /// </summary>
        private KeyValuePair<Instance, Data> CreateAll(Declaration pDecl)
        {
            KeyValuePair<Instance, Data> baseInst = _empty;
            if (pDecl.Base != null)
            {
                baseInst = CreateAll(pDecl.Base);
            }

            Instance inst = new Instance(pDecl.Constructor);
            Data alias = _heap.Add(inst);

            inst.Members.Create("this", alias);

            if (baseInst.Value != null)
            {
                inst.Members.Create("base", baseInst.Value);
            }

            return new KeyValuePair<Instance, Data>(inst, alias);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateInherited(HeapSpace pHeap, Declaration pDecl)
        {
            _heap = pHeap;

            KeyValuePair<Instance, Data> inst = CreateAll(pDecl);
            Inst = inst.Key;
            Alias = inst.Value;
        }
    }
}