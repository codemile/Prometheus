using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Storage
{
    /// <summary>
    /// Turns a C# object into a storage location for variables. This space does
    /// not support the creating or removing of variables as they are set by the
    /// objects properties.
    /// </summary>
    public class ObjectSpace : iMemorySpace
    {
        /// <summary>
        /// The type of member properties that are supported.
        /// </summary>
        private static readonly HashSet<Type> _supportedTypes = new HashSet<Type>
                                                                {
                                                                    typeof (string),
                                                                    typeof (int),
                                                                    typeof (long),
                                                                    typeof (float),
                                                                    typeof (double)
                                                                };

        /// <summary>
        /// The object's properties
        /// </summary>
        private Dictionary<string, PropertyInfo> _properties;

        /// <summary>
        /// The object reference
        /// </summary>
        private object _ref;

        /// <summary>
        /// Finds a property description.
        /// </summary>
        private PropertyInfo GetInfo(string pName)
        {
            if (!_properties.ContainsKey(pName))
            {
                throw new ObjectSpaceException(string.Format("Property <{0}> does not exist for", pName), _ref);
            }
            return _properties[pName];
        }

        /// <summary>
        /// Get the property for read access.
        /// </summary>
        private PropertyInfo GetInfoReadable(string pName)
        {
            PropertyInfo info = GetInfo(pName);
            if (!info.CanRead)
            {
                throw new ObjectSpaceException(string.Format("Cannot read <{0}> property for", info.Name), _ref);
            }
            return info;
        }

        /// <summary>
        /// Get the property for write access.
        /// </summary>
        private PropertyInfo GetInfoWritable(string pName)
        {
            PropertyInfo info = GetInfo(pName);
            if (!info.CanWrite)
            {
                throw new ObjectSpaceException(string.Format("Cannot write <{0}> property for", info.Name),_ref);
            }
            return info;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectSpace(object pRef)
        {
            if (pRef == null)
            {
                throw new UnexpectedErrorException("ObjectSpace can not accept a null argument.");
            }
            _ref = pRef;

            // TODO: this will trigger an exception if two Properties are spelled the same but have different letter case
            _properties = (from prop in _ref.GetType().GetProperties()
                           where (prop.CanRead || prop.CanWrite)
                                 && prop.DeclaringType != null
                                 && _supportedTypes.Contains(prop.PropertyType)
                           select prop)
                .ToDictionary(pKey=>pKey.Name.ToLower(), pValue=>pValue);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _properties.Clear();

            _ref = null;
            _properties = null;
        }

        /// <summary>
        /// Assigns a value to a name. Creates the a new
        /// variable if required.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <param name="pDataType">The data to assign</param>
        public void Assign(string pName, DataType pDataType)
        {
            GetInfoWritable(pName).SetValue(_ref, pDataType.getBool(), null);
        }

        /// <summary>
        /// Creates a new variable in the current scope.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <param name="pDataType">The data to assign</param>
        public void Create(string pName, DataType pDataType)
        {
            throw new ObjectSpaceException(string.Format("Cannot create <{0}> as a new property on", pName), _ref);
        }

        /// <summary>
        /// Derived classes will handle the lookup of an identifier.
        /// </summary>
        /// <param name="pName">The name to get</param>
        /// <returns>The data</returns>
        public DataType Get(string pName)
        {
            object value = GetInfoReadable(pName).GetValue(_ref, null);
            if (value is string)
            {
                return new StringType((string)value);
            }
            if (value is long)
            {
                return new NumericType((long)value);
            }
            if (value is int)
            {
                return new NumericType((int)value);
            }
            if (value is float)
            {
                return new NumericType((float)value);
            }
            if (value is double)
            {
                return new NumericType((double)value);
            }
            return UndefinedType.Undefined;
        }

        /// <summary>
        /// Checks if the storage contains a variable.
        /// </summary>
        /// <param name="pName">The name to create</param>
        /// <returns>True if exists</returns>
        public bool Has(string pName)
        {
            return _properties.ContainsKey(pName);
        }

        /// <summary>
        /// Derived classes will handle the printing.
        /// </summary>
        /// <param name="pIndent">Line indent</param>
        public IEnumerable<MemoryItem> Dump(int pIndent = 0)
        {
            return from prop in _properties select new MemoryItem{Name=prop.Key, Data = Get(prop.Key), Level = pIndent};
        }

        /// <summary>
        /// Derived classes will handle the setting.
        /// </summary>
        /// <param name="pName">The name to set</param>
        /// <param name="pDataType">The data</param>
        /// <returns>True if name exists</returns>
        public bool Set(string pName, DataType pDataType)
        {
            if (!Has(pName))
            {
                return false;
            }
            GetInfoWritable(pName).SetValue(_ref, pDataType.getBool(), null);
            return true;
        }

        /// <summary>
        /// Removes a variable from the current scope.
        /// </summary>
        /// <param name="pName">The name to remove</param>
        public bool Unset(string pName)
        {
            throw new ObjectSpaceException(string.Format("Cannot unset <{0}> property for", pName), _ref);
        }
    }
}