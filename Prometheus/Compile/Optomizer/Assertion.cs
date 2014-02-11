using System;
using Prometheus.Exceptions.Compiler;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Compile.Optomizer
{
    /// <summary>
    /// Optimization safety checks.
    /// </summary>
    public static class Assertion
    {
        /// <summary>
        /// Node must have these many children.
        /// </summary>
        public static void Children(int pCount, Node pNode)
        {
            if (pNode.Children.Count != pCount)
            {
                throw new OptimizationException(
                    string.Format("Expected <{0}> to have <{1}> children, but has {2} children instead",
                        pNode.Type,
                        pCount,
                        pNode.Children.Count),
                    pNode.Location);
            }
        }

        /// <summary>
        /// Node must have this many data elements.
        /// </summary>
        public static void Data(int pCount, Node pNode)
        {
            if (pNode.Data.Count != pCount)
            {
                throw new OptimizationException(
                    string.Format("Expected <{0}> to have {1} data, but has {2} data instead",
                        pNode.Type,
                        pCount,
                        pNode.Data.Count),
                    pNode.Location);
            }
        }

        /// <summary>
        /// Node must not have any children or data.
        /// </summary>
        public static void Empty(Node pNode)
        {
            if (pNode.Children.Count == 0 && pNode.Data.Count == 0)
            {
                throw new OptimizationException(
                    string.Format("Node <{0}> is not empty", pNode.Type),
                    pNode.Location);
            }
        }

        /// <summary>
        /// Data must be of expected type.
        /// </summary>
        public static T Get<T>(Node pNode, int pIndex) where T : DataType
        {
            if (pIndex >= pNode.Data.Count)
            {
                throw new OptimizationException(
                    string.Format("<{0}> has {1} data, but expected at least {2}",
                        pNode.Type,
                        pNode.Data.Count,
                        pIndex),
                    pNode.Location);
            }
            DataType dataType = pNode.Data[pIndex];
            Type type = typeof (T);
            if (dataType.GetType() != type)
            {
                throw new OptimizationException(
                    string.Format("Expected <{0}> data {1} to be type <{2}> but found <{3}> instead",
                        pNode.Type,
                        pIndex,
                        type.Name,
                        dataType.GetType().Name),
                    pNode.Location);
            }
            return (T)dataType;
        }

        /// <summary>
        /// Node must match a symbol.
        /// </summary>
        public static void Symbol(GrammarSymbol pSymbol, Node pNode)
        {
            if (pNode.Type != pSymbol)
            {
                throw new OptimizationException(
                    string.Format("Unexpected node <{0}> in tree graph", pNode.Type),
                    pNode.Location);
            }
        }
    }
}