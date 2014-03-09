using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Implements the search operators and terms.
    /// </summary>
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    public class Search : ExecutorGrammar
    {
        /// <summary>
        /// Default quantifier
        /// </summary>
        private readonly static TerminalType _all = new TerminalType("any");

        /// <summary>
        /// Constructor
        /// </summary>
        public Search(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// True if the haystack contains one of the needles.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ContainsTerm)]
        public BooleanType Contains(Node pNode, DataType pHaystacks, DataType pNeedles)
        {
            return Contains(pNode, _all, pHaystacks, pNeedles);
        }

        /// <summary>
        /// True if the haystack contains one of the needles.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ContainsTerm)]
        public BooleanType Contains(Node pNode, TerminalType pQuantifier, DataType pHaystacks, DataType pNeedles)
        {
            pHaystacks = Resolve(pHaystacks);
            pNeedles = Resolve(pNeedles);

            IEnumerable<iSearchHaystack> haystacks = DataType.ToArray<StringType>(pHaystacks);
            IEnumerable<iSearchNeedle> needles = DataType.ToArray<StringType>(pNeedles);

            switch (pQuantifier.Name)
            {
                case "all":
                    return needles.All(pNeedle=>haystacks.Any(pStack=>pStack.Contains(pNeedle)))
                        ? BooleanType.True
                        : BooleanType.False;
                case "any":
                    return needles.Any(pNeedle=>haystacks.Any(pStack=>pStack.Contains(pNeedle)))
                        ? BooleanType.True
                        : BooleanType.False;
                case "none":
                    return needles.Any(pNeedle=>haystacks.Any(pStack=>pStack.Contains(pNeedle)))
                        ? BooleanType.False
                        : BooleanType.True;
            }

            throw new InvalidArgumentException(string.Format("<contains> operator does not support quantifier <{0}>", pQuantifier.Name),pNode);
        }
    }
}