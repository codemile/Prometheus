using Prometheus.Compile;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Storage;

namespace Prometheus.Objects
{
    /// <summary>
    /// Holds the data associated with an instance of an object.
    /// </summary>
    public class Instance
    {
        /// <summary>
        /// The constructor method for this instance.
        /// </summary>
        private readonly Node _constructor;

        /// <summary>
        /// Members of this object
        /// </summary>
        private readonly iMemorySpace _members;

        /// <summary>
        /// The number of references to this instance.
        /// </summary>
        private int _references;

        /// <summary>
        /// The class that created this instance.
        /// </summary>
        public readonly ClassNameType ClassName;

        /// <summary>
        /// Constructor
        /// </summary>
        public Instance(ClassNameType pClassName, iMemorySpace pMembers)
        {
            ClassName = pClassName;
            _constructor = new Node(GrammarSymbol.Statements, Location.None);
            _references = 0;
            _members = pMembers;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Instance(ClassNameType pClassName, Node pConstructor = null)
        {
            ClassName = pClassName;
            _constructor = pConstructor;
            _references = 0;
            _members = new StorageSpace();
        }

        /// <summary>
        /// Adds a reference count
        /// </summary>
        public void AddRef()
        {
            _references++;
        }

        /// <summary>
        /// Removes a reference count
        /// </summary>
        public void DecRef()
        {
            _references--;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public Node GetConstructor()
        {
            return _constructor;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public iMemorySpace GetMembers()
        {
            return _members;
        }
    }
}