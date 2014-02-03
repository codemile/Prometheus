using Prometheus.Grammar;

namespace Prometheus.Executors.Attributes
{
    /// <summary>
    /// Defines a method that executes code for a Grammar Symbol.
    /// </summary>
    public class ExecuteSymbol : ExecuteAttribute
    {
        /// <summary>
        /// The symbol the method implement.
        /// </summary>
        private readonly GrammarSymbol _symbol;

        /// <summary>
        /// Construct
        /// </summary>
        /// <param name="pSymbol">The symbol the method implement.</param>
        public ExecuteSymbol(GrammarSymbol pSymbol)
        {
            _symbol = pSymbol;
        }

        /// <summary>
        /// Returns an identifier of the kind of method the derived attribute is defining.
        /// </summary>
        /// <typeparam name="T">Must match the property type in the derived class.</typeparam>
        /// <returns>The identifier</returns>
        public override T GetExecutorType<T>()
        {
            // trick the compiler into casting
            object obj = _symbol;
            return (T)obj;
        }
    }
}