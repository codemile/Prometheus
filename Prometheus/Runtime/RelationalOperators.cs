using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prometheus.Compile.Optomizer;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Implements the operators for greater than and less than.
    /// </summary>
    public class RelationalOperators : PrometheusObject, iNodeOptimizer
    {
        /// <summary>
        /// A list of relational operators
        /// </summary>
        private readonly HashSet<GrammarSymbol> _compareSymbols;

        /// <summary>
        /// Checks if a node performs math operations on two constant values.
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <returns>True if it can be reduced.</returns>
        private bool CanReduce(Node pNode)
        {
            return (_compareSymbols.Contains(pNode.Type) &&
                    pNode.Children[0].Type == GrammarSymbol.Value &&
                    pNode.Children[1].Type == GrammarSymbol.Value);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public RelationalOperators()
        {
            _compareSymbols = new HashSet<GrammarSymbol>
                           {
                               GrammarSymbol.GtOperator,
                               GrammarSymbol.LtOperator,
                               GrammarSymbol.GteOperator,
                               GrammarSymbol.LteOperator
                           };
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [SymbolHandler(GrammarSymbol.GtOperator)]
        public Data GreaterThan(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof(long)
                ? new Data(pValue1.Get<long>() > pValue2.Get<long>())
                : new Data(pValue1.Get<double>() > pValue2.Get<double>());
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [SymbolHandler(GrammarSymbol.LtOperator)]
        public Data LessThan(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof(long)
                ? new Data(pValue1.Get<long>() < pValue2.Get<long>())
                : new Data(pValue1.Get<double>() < pValue2.Get<double>());
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [SymbolHandler(GrammarSymbol.GteOperator)]
        public Data GreaterThanEqual(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof(long)
                ? new Data(pValue1.Get<long>() >= pValue2.Get<long>())
                : new Data(pValue1.Get<double>() >= pValue2.Get<double>());
        }

        /// <summary>
        /// Greater Than
        /// </summary>
        [SymbolHandler(GrammarSymbol.LteOperator)]
        public Data LessThanEqual(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof(long)
                ? new Data(pValue1.Get<long>() <= pValue2.Get<long>())
                : new Data(pValue1.Get<double>() <= pValue2.Get<double>());
        }

        /// <summary>
        /// Inspect a node
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <returns>Same node, a new node or null to remove it.</returns>
        public Node Optomize(Node pNode)
        {
            if (pNode.Children.Count != 2 ||
                pNode.Data.Count != 0 ||
                !CanReduce(pNode))
            {
                return pNode;
            }

            // do relational operation now
            Node reduced = new Node(GrammarSymbol.Value, pNode.Location);

            Data valueA = pNode.Children[0].Data[0];
            Data valueB = pNode.Children[1].Data[0];

            switch (pNode.Type)
            {
                case GrammarSymbol.GtOperator:
                    reduced.Data.Add(GreaterThan(valueA, valueB));
                    break;
                case GrammarSymbol.LtOperator:
                    reduced.Data.Add(LessThan(valueA, valueB));
                    break;
                case GrammarSymbol.GteOperator:
                    reduced.Data.Add(GreaterThanEqual(valueA, valueB));
                    break;
                case GrammarSymbol.LteOperator:
                    reduced.Data.Add(LessThanEqual(valueA, valueB));
                    break;
            }

            return reduced;
        }
    }
}
