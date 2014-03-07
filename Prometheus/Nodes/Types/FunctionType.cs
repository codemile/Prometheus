using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// A reference to a function declaration.
    /// </summary>
    public class FunctionType : DataType
    {
        /// <summary>
        /// The function entry point.
        /// </summary>
        public readonly Node Entry;

        /// <summary>
        /// The function parameters
        /// </summary>
        private readonly ArrayType _parameters;

        /// <summary>
        /// Constructor
        /// </summary>
        public FunctionType(Node pEntry)
        {
            Entry = pEntry;
            _parameters = new ArrayType();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FunctionType(Node pEntry, IEnumerable<DataType> pParameters)
            : this(pEntry)
        {
            _parameters.Values.AddRange(pParameters);
        }

        /// <summary>
        /// Returns "function"
        /// </summary>
        public override string ToString()
        {
            return "function";
        }

        /// <summary>
        /// Creates the variables to be sent when executing the function.
        /// </summary>
        public void CreateArguments(ref Dictionary<string, DataType> pSpace, DataType[] pArgs)
        {
            if (pArgs.Length != _parameters.Count)
            {
                throw new InvalidArgumentException(string.Format(
                    "Function was expecting {0} parameters but was past {1} instead.", _parameters.Count,
                    pArgs.Length));
            }

            for (int i = 0, c = pArgs.Length; i < c; i++)
            {
                IdentifierType name = (IdentifierType)_parameters[i];
                pSpace.Add(name.Name, pArgs[i]);
            }
        }
    }
}