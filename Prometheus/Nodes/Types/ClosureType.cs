using System.Collections.Generic;
using System.Security.Cryptography;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types.Bases;

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
        public readonly Node Function;

        /// <summary>
        /// The function parameters
        /// </summary>
        public readonly ArrayType Parameters;

        /// <summary>
        /// Reference to "this"
        /// </summary>
        public readonly InstanceType This;

        /// <summary>
        /// Constructor
        /// </summary>
        public ClosureType(InstanceType pThis, ClosureType pFunction)
        {
            This = pThis;
            Function = pFunction.Function;
            Parameters = pFunction.Parameters.Clone();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ClosureType(Node pFunction)
        {
            Function = pFunction;
            Parameters = new ArrayType();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ClosureType(Node pFunction, IEnumerable<DataType> pParameters)
            : this(pFunction)
        {
            Parameters.Values.AddRange(pParameters);
        }

        /// <summary>
        /// Returns "function"
        /// </summary>
        public override string ToString()
        {
            return "function";
        }

        /// <summary>
        /// True if this closure has been compiled.
        /// </summary>
        public bool HasThis()
        {
            return This != null;
        }

        /// <summary>
        /// Creates the variables to be sent when executing the function.
        /// </summary>
        public Dictionary<string, DataType> CreateArguments(DataType[] pArgs)
        {
            if (pArgs.Length != Parameters.Count)
            {
                throw new InvalidArgumentException(string.Format(
                    "Function was expecting {0} parameters but was past {1} instead.", Parameters.Count,
                    pArgs.Length));
            }

            Dictionary<string, DataType> variables = new Dictionary<string, DataType>();

            for (int i = 0, c = pArgs.Length; i < c; i++)
            {
                IdentifierType name = (IdentifierType)Parameters[i];
                variables.Add(name.Name, pArgs[i]);
            }

            if (This != null)
            {
                variables.Add(IdentifierType.THIS, This);
            }

            return variables;
        }
    }
}