using System;
using System.Collections.Generic;
using System.Diagnostics;
using Prometheus.Exceptions.Executor;

namespace Prometheus.Nodes.Types.Bases
{
    /// <summary>
    /// The data for a node.
    /// </summary>
    [DebuggerDisplay("{Type}:{_value}")]
    public class DataType
    {
#if DEBUG
        private static readonly HashSet<Type> _supported = new HashSet<Type>
                                                           {
                                                               typeof (long),
                                                               typeof (double),
                                                               typeof (string),
                                                               typeof (UndefinedType),
                                                               typeof (bool),
                                                               typeof (IdentifierType),
                                                               typeof (QualifiedType),
                                                               typeof (Node),
                                                               typeof (StaticType),
                                                               typeof (AliasType),
                                                               typeof (ClosureType)
                                                           };
#endif

        /// <summary>
        /// The floating point degree of error.
        /// </summary>
        public const double PRECISE_EPSILON = double.Epsilon;

        /// <summary>
        /// The non-decimal type for the engine.
        /// </summary>
        public static readonly Type Integer = typeof (long);

        /// <summary>
        /// The floating point type for the engine.
        /// </summary>
        public static readonly Type Precise = typeof (double);

        /// <summary>
        /// Represents an undefined data type.
        /// </summary>
        public static readonly DataType Undefined = new DataType();

        /// <summary>
        /// The data type.
        /// </summary>
        public readonly Type Type;

        /// <summary>
        /// The data value
        /// </summary>
        private readonly object _value;

        /// <summary>
        /// Access the value by a given type. The type will be converted
        /// if conversion is possible.
        /// </summary>
        /// <typeparam name="T">The required type.</typeparam>
        /// <returns>The converted value.</returns>
        private T Get<T>()
        {
            return (_value is T)
                ? (T)_value
                : (T)Convert.ChangeType(_value, typeof (T));
        }

        /// <summary>
        /// Access the value by a give type. The type will be converted if
        /// conversion is possible.
        /// </summary>
        /// <param name="pType">The target type</param>
        /// <returns>The value as an object</returns>
        public object Get(Type pType)
        {
            return (_value.GetType() == pType)
                ? _value
                : Convert.ChangeType(_value, pType);
        }

        /// <summary>
        /// Undefined constructor
        /// </summary>
        private DataType()
        {
            _value = new UndefinedType();
            Type = typeof (UndefinedType);
        }

        /// <summary>
        /// Generic constructor. Only pass supported types.
        /// </summary>
        public DataType(object pObj)
        {
#if DEBUG
            if (!_supported.Contains(pObj.GetType()))
            {
                throw new UnexpectedErrorException(string.Format("{0} type is not supported by Data.",
                    pObj.GetType().Name));
            }
#endif
            _value = pObj;
            Type = pObj.GetType();
        }

        /// <summary>
        /// Converts the data to a debug message.
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}:{1}", Type.Name, _value);
        }

        /// <summary>
        /// Access the data as a boolean
        /// </summary>
        /// <returns>The converted value.</returns>
        public bool getBool()
        {
            return (Type == typeof (bool))
                ? (bool)_value
                : Get<bool>();
        }

        /// <summary>
        /// Access the data as an integer value.
        /// </summary>
        /// <returns>The converted value.</returns>
        public long getInteger()
        {
            return (Type == Integer)
                ? (long)_value
                : Get<long>();
        }

        /// <summary>
        /// Access the data as a floating point value.
        /// </summary>
        /// <returns>The converted value.</returns>
        public double getPrecise()
        {
            return (Type == Precise)
                ? (double)_value
                : Get<double>();
        }

        /// <summary>
        /// Access the data as a string.
        /// </summary>
        /// <returns>The converted value.</returns>
        public string getString()
        {
            if (Type == typeof (Node))
            {
                return "function";
            }
            return Type == typeof (AliasType) ? "object" : Get<string>();
        }

        /// <summary>
        /// Accesses the data as a list of arguments.
        /// </summary>
        /// <returns>An argument collection</returns>
        public ArgumentListType getArgumentList()
        {
            if (Type == typeof (ArgumentListType))
            {
                return (ArgumentListType)_value;
            }
            return new ArgumentListType {this};
        }

        /// <summary>
        /// Access the value as an identifier.
        /// </summary>
        /// <returns>The identifier</returns>
        public IdentifierType getIdentifier()
        {
            return (IdentifierType)_value;
        }

        /// <summary>
        /// Access the value as a qualified ID.
        /// </summary>
        public QualifiedType getQualified()
        {
            return (QualifiedType)_value;
        }

        /// <summary>
        /// Access the value as a static type.
        /// </summary>
        /// <returns>The static type.</returns>
        public StaticType getStaticType()
        {
            return (StaticType)_value;
        }

        /// <summary>
        /// Access the value as an executable node.
        /// </summary>
        /// <returns>The node</returns>
        public Node getNode()
        {
            return (Node)_value;
        }

        /// <summary>
        /// Access the value as an alias.
        /// </summary>
        /// <returns>The alias</returns>
        public AliasType getAlias()
        {
            return (AliasType)_value;
        }

        /// <summary>
        /// Access the value as a closure function
        /// </summary>
        public ClosureType getClosure()
        {
            return (ClosureType)_value;
        }

        /// <summary>
        /// Access the raw object value.
        /// </summary>
        public object getValue()
        {
            return _value;
        }
    }
}