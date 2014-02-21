namespace Prometheus.Parser.Executors.Attributes
{
    /// <summary>
    /// Allows a class to expose it's methods as built-in function APIs.
    /// </summary>
    public class ExecuteGeneric : ExecuteAttribute
    {
        /// <summary>
        /// The symbol the method implement.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Construct
        /// </summary>
        /// <param name="pName">The internal name the method implement.</param>
        public ExecuteGeneric(string pName)
        {
            _name = pName;
        }

        /// <summary>
        /// Returns an identifier of the kind of method the derived attribute is defining.
        /// </summary>
        /// <typeparam name="T">Must match the property type in the derived class.</typeparam>
        /// <returns>The identifier</returns>
        public override T GetExecutorType<T>()
        {
            // trick the compiler into casting
            object obj = _name;
            return (T)obj;
        }
    }
}