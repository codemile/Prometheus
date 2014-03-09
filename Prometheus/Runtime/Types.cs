using System;
using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles symbols related to variable types.
    /// </summary>
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class Types : ExecutorGrammar
    {
        private static readonly Dictionary<GrammarSymbol, Type>
            _complexTypes = new Dictionary<GrammarSymbol, Type>
                            {
                                {GrammarSymbol.@integer, typeof (NumericType)},
                                {GrammarSymbol.@float, typeof (NumericType)},
                                {GrammarSymbol.@number, typeof (NumericType)},
                                {GrammarSymbol.@string, typeof (StringType)},
                                {GrammarSymbol.@regex, typeof (StringType)}
                            };

        private static readonly Dictionary<GrammarSymbol, Type>
            _simpleTypes = new Dictionary<GrammarSymbol, Type>
                           {
                               {GrammarSymbol.@function, typeof (ClosureType)},
                               {GrammarSymbol.@object, typeof (InstanceType)},
                               {GrammarSymbol.@class, typeof (DeclarationType)},
                               {GrammarSymbol.@array, typeof (ArrayType)},
                               {GrammarSymbol.@Undefined, typeof (UndefinedType)}
                           };

        /// <summary>
        /// Constructor
        /// </summary>
        public Types(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Checks if a variable is of a type.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.IsOperator)]
        public BooleanType Is(Node pNode, IsType pType, QualifiedType pId)
        {
            DataType value = Resolve<DataType>(pId);

            // unsupported types throw an error
            if (!_simpleTypes.ContainsKey(pType.Type)
                && !_complexTypes.ContainsKey(pType.Type))
            {
                throw new DataTypeException(string.Format("Operator <is> can not be applied to <{0}>", pType.Type),
                    pNode);
            }

            // simple type check
            if (_simpleTypes.ContainsKey(pType.Type))
            {
                return new BooleanType(value.GetType() == _simpleTypes[pType.Type]);
            }

            // if not numeric, then must be a string
            NumericType num = value as NumericType;
            if (num == null)
            {
                return pType.Type == GrammarSymbol.@regex
                    ? new BooleanType(((StringType)value).IsRegex)
                    : BooleanType.True;
            }

            // numeric specific type
            switch (pType.Type)
            {
                case GrammarSymbol.@integer:
                    return new BooleanType(num.isLong);
                case GrammarSymbol.@float:
                    return new BooleanType(num.isDouble);
            }
            return BooleanType.True;
        }

        /// <summary>
        /// Checks if a variable is not of a type.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.IsNotOperator)]
        public BooleanType IsNot(Node pNode, IsType pType, QualifiedType pId)
        {
            return Is(pNode, pType, pId).Value
                ? BooleanType.False
                : BooleanType.True;
        }
    }
}