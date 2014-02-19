using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;

namespace Prometheus.Runtime
{
    /// <summary>
    /// General statements that take different argument counts.
    /// </summary>
    public class GenericGrammar : ExecutorGrammar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GenericGrammar(Executor pExecutor) 
            : base(pExecutor)
        {
        }

        /// <summary>
        /// No arguments
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Generic0Args)]
        public DataType Generic(IdentifierType pName)
        {
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// One argument
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Generic1Args)]
        public DataType Generic(IdentifierType pName, DataType pArg1)
        {
            return UndefinedType.Undefined;
        }
    }
}
