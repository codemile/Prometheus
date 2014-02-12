using Prometheus.Exceptions.Executor;
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

        private StringType ToString(string pOperator, DataType pData)
        {
            StringType str = pData as StringType;
            if (str == null)
            {
                throw DataTypeException.InvalidTypes(pOperator, pData);
            }
            return str;
        }

        /// <summary>
        /// Processes a boolean result for searches.
        /// </summary>
        /// <param name="pHaystack">What to search in</param>
        /// <param name="pNeedle">The terms to find</param>
        /// <returns>Boolean result</returns>
        [ExecuteSymbol(GrammarSymbol.ContainsTerm)]
        public DataType Contains(DataType pHaystack, DataType pNeedle)
        {
            ArrayType haystacks = pHaystack.ToArray();
            ArrayType needles = pNeedle.ToArray();

            foreach (DataType haystack in haystacks)
            {
                StringType hay = ToString("contains",haystack);
                foreach (DataType needle in needles)
                {
                    StringType ndle = ToString("contains", needle);
                    if (hay.Value.Contains(ndle.Value))
                    {
                        return BooleanType.True;
                    }
                }
            }

            return BooleanType.False;
        }
    }
}