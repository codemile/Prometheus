using System.Collections.Generic;
using System.Linq;
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
    public class Search : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Search(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Processes a boolean result for searches.
        /// </summary>
        /// <param name="pHaystacks">What to search in</param>
        /// <param name="pNeedles">The terms to find</param>
        /// <returns>Boolean result</returns>
        [ExecuteSymbol(GrammarSymbol.ContainsTerm)]
        public DataType Contains(Node pNode, DataType pHaystacks, DataType pNeedles)
        {
            pHaystacks = Resolve(pHaystacks);
            pNeedles = Resolve(pNeedles);

            IEnumerable<iSearchHaystack> haystacks = DataType.ToArray<iSearchHaystack>(pHaystacks);
            IEnumerable<iSearchNeedle> needles = DataType.ToArray<iSearchNeedle>(pNeedles);

            return needles.Any(pNeedle=>haystacks.Any(pStack=>pStack.Contains(pNeedle)))
                ? BooleanType.True
                : BooleanType.False;
        }
    }
}