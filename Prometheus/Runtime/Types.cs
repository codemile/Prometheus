using System;
using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Attributes;
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
        /// <summary>
        /// All the supported data types.
        /// </summary>
        private readonly List<string> _types;

        /// <summary>
        /// Constructor
        /// </summary>
        public Types(Executor pExecutor)
            : base(pExecutor)
        {
            _types = new List<string>();
            foreach (Type type in ObjectFactory.GetTypes<DataType>())
            {
                _types.AddRange(
                    type.GetCustomAttributes(typeof (DataTypeInfoAttribute), true)
                    .Select(pInfo=>((DataTypeInfoAttribute)pInfo).Name));
            }
        }

        /// <summary>
        /// Calls the current method based upon argument types.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.IsOperator)]
        public BooleanType Is(Node pNode, DataType pArg1, DataType pArg2)
        {
            return (pArg1 is IsType)
                ? Is(pNode, (IsType)pArg1, (QualifiedType)pArg2)
                : Is(pNode, (QualifiedType)pArg1, (QualifiedType)pArg2);
        }

        /// <summary>
        /// Checks if a variable is of a type.
        /// </summary>
        public BooleanType Is(Node pNode, QualifiedType pId, QualifiedType pType)
        {
            DataType value = Resolve<DataType>(pId);
            DataType decl = Resolve<DataType>(pType);

            DeclarationType declType = decl as DeclarationType;
            InstanceType instType = value as InstanceType;
            if (instType != null
                && declType != null)
            {
                return new BooleanType(instType.ClassName == declType.ClassName);
            }

            return BooleanType.False;
        }

        /// <summary>
        /// Checks if a variable is of a type.
        /// </summary>
        public BooleanType Is(Node pNode, IsType pType, QualifiedType pId)
        {
            DataType value = Resolve<DataType>(pId);
            return new BooleanType(value.GetTypes().Any(pValueType => pValueType == pType.Name));
        }

        /// <summary>
        /// Checks if a variable is not of a type.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.IsNotOperator)]
        public BooleanType IsNot(Node pNode, DataType pArg1, DataType pArg2)
        {
            return Is(pNode, pArg1, pArg2).Value
                ? BooleanType.False
                : BooleanType.True;
        }

        /// <summary>
        /// Returns the type of a variable as a string.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.TypeOfFunc)]
        public StringType TypeOf(Node pNode, QualifiedType pId)
        {
            DataType value = Resolve<DataType>(pId);
            string first = value.GetTypes().First();
            return new StringType(false, first, StringType.eMODE.WORD_BOUNDARIES, StringType.eFLAGS.NONE);
        }
    }
}