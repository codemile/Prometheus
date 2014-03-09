using System;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Storage;

namespace Prometheus.Parser
{
    /// <summary>
    /// The currently executing cursor. Holds the current state of the parser.
    /// </summary>
    public class Cursor : IDisposable
    {
        /// <summary>
        /// The name of the unit test to run.
        /// </summary>
        public readonly string UnitTest;

        /// <summary>
        /// The current namespace.
        /// </summary>
        public QualifiedType Package;

        /// <summary>
        /// The current stack of local variables.
        /// </summary>
        public iMemorySpace Stack;

        /// <summary>
        /// The root reference.
        /// </summary>
        private iMemorySpace _root;

        /// <summary>
        /// The root for the stack space.
        /// </summary>
        public iMemorySpace Root
        {
            get { return _root; }
            set { _root = Stack = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Cursor()
        {
            Stack = null;
            UnitTest = null;
            Package = new QualifiedType("Global");
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pUnitTest">Name of a unit test to run.</param>
        public Cursor(string pUnitTest)
            : this()
        {
            UnitTest = pUnitTest;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (Stack != null)
            {
                Stack.Dispose();
            }
        }

        /// <summary>
        /// Results to a specific DataType
        /// </summary>
        public T Get<T>(QualifiedType pID) where T : DataType
        {
            DataType value = Resolve(pID).Read();
            T result = value as T;
            if (result == null)
            {
                throw new IdentifierInnerException(
                    string.Format("Expected <{0}> but found <{1}> instead", typeof (T).Name, value.GetType().Name));
            }
            return result;
        }

        /// <summary>
        /// Finds a reference to a variable in memory for read/write access.
        /// </summary>
        public iVariablePointer Resolve(QualifiedType pID)
        {
            iMemorySpace stack = Stack;
            DataType member = null;
            iVariablePointer pointer = null;
            int last = pID.Count - 1;
            for (int i = 0, c = pID.Count; i < c; i++)
            {
                // follow member references to objects
                InstanceType inst = member as InstanceType;
                if (inst != null)
                {
                    stack = inst.GetMembers();
                }
                // first has to be id
                IdentifierType id = pID[i] as IdentifierType;
                if (id != null)
                {
                    if (i == last)
                    {
                        pointer = new MemoryPointer(stack, id.Name);
                        break;
                    }
                    member = stack.Get(id.Name);
                    NameSpaceType spaceType = member as NameSpaceType;
                    if (spaceType != null)
                    {
                        stack = spaceType;
                    }
                    continue;
                }

                NumericType num = pID[i] as NumericType;
                if (member == null || num == null)
                {
                    throw new IdentifierInnerException(string.Format("Expecting identifier but found <{0}> instead",
                        pID[i].GetType().Name));
                }

                // must be an array reference
                ArrayType array = member as ArrayType;
                if (!num.isLong || array == null)
                {
                    throw new InvalidIndexException(string.Format("Cannot apply indexing <{0}> to a type of <{1}>",
                        num.GetType().Name, member.GetType().Name));
                }

                int index = (int)num.Long;
                if (index < 0 || index >= array.Count)
                {
                    throw new InvalidIndexException(string.Format("Index parameter is out of range <{0}>", index));
                }
                if (i == last)
                {
                    pointer = new ArrayPointer(array, index);
                    break;
                }
                member = array[index];
            }

            if (pointer == null)
            {
                throw new IdentifierInnerException("Unable to resolve reference.");
            }

            return pointer;
        }
    }
}