using System.Collections.Generic;
using System.Linq;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Implements the search operators and terms.
    /// </summary>
    public class SearchOperators : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SearchOperators(Executor pExecutor)
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
        public DataType Contains(DataType pHaystacks, DataType pNeedles)
        {
            IEnumerable<iSearchHaystack> haystacks = DataType.ToArray<iSearchHaystack>(pHaystacks);
            IEnumerable<iSearchNeedle> needles = DataType.ToArray<iSearchNeedle>(pNeedles);

            return needles.Any(pNeedle=>haystacks.Any(pStack=>pStack.Contains(pNeedle)))
                ? BooleanType.True
                : BooleanType.False;
        }
    }
}