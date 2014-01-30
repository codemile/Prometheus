using Prometheus.Nodes;

namespace Prometheus.Objects.Classifiers
{
    /// <summary>
    /// Handles the converting on data into a primitive type.
    /// </summary>
    public interface iDataConverter
    {
        /// <summary>
        /// Boolean getter
        /// </summary>
        /// <returns>Boolean result</returns>
        bool getBool(Data pData);

        /// <summary>
        /// Float getter
        /// </summary>
        /// <returns>Float result</returns>
        float getFloat(Data pData);

        /// <summary>
        /// Integer getter
        /// </summary>
        /// <returns>Integer result</returns>
        int getInt(Data pData);

        /// <summary>
        /// String getter
        /// </summary>
        /// <returns>String result</returns>
        string getString(Data pData);
    }
}