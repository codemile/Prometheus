namespace Prometheus.Nodes.Types.Bases
{
    /// <summary>
    /// Variables can be stored in different locations. Memory storage classes and arrays. Different
    /// parts of the code want read/write access from a qualified ID reference. This interface
    /// provides boxing around a reference so that data can be read/write to a location.
    /// </summary>
    public interface iVariablePointer
    {
        /// <summary>
        /// Reads the value
        /// </summary>
        DataType Read();

        /// <summary>
        /// Writes over the value.
        /// </summary>
        bool Write(DataType pValue);
    }
}