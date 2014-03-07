using System.Collections.Generic;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Storage;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a reference to a function and the object that should be used
    /// as the "this" reference. The compiled flag just means that the function
    /// has been created as an object in the heap.
    /// </summary>
    public class ClosureType : DataType
    {
        /// <summary>
        /// The function
        /// </summary>
        public readonly FunctionType Function;

        /// <summary>
        /// Name of the instance object.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Reference to "this"
        /// </summary>
        private readonly InstanceType _this;

        /// <summary>
        /// Values to persist
        /// </summary>
        private readonly StorageSpace _with;

        /// <summary>
        /// Constructor
        /// </summary>
        public ClosureType(InstanceType pThis, IEnumerable<DataType> pParameters, StorageSpace pWith, Node pBlock)
        {
            _name = IdentifierType.THIS;
            _this = pThis;
            _with = pWith;
            Function = new FunctionType(pBlock, pParameters);
        }

        /// <summary>
        /// Returns "closure"
        /// </summary>
        public override string ToString()
        {
            return "closure";
        }

        /// <summary>
        /// Creates the variables to be sent when executing the function.
        /// </summary>
        public Dictionary<string, DataType> CreateArguments(DataType[] pArgs = null)
        {
            Dictionary<string, DataType> variables = new Dictionary<string, DataType>(_with.Storage);
            if (pArgs != null)
            {
                Function.CreateArguments(ref variables, pArgs);
            }
            variables.Add(_name, _this);
            return variables;
        }
    }
}