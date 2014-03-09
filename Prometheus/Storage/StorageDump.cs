using System;
using System.Collections.Generic;
using System.Linq;
using Logging;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Storage
{
    /// <summary>
    /// Prints variables and stops recursion for already printed variables.
    /// </summary>
    public class StorageDump
    {
        /// <summary>
        /// Logging
        /// </summary>
        private static readonly Logger _logger = Logger.Create(typeof (StorageDump));

        /// <summary>
        /// Prints a value with indentation.
        /// </summary>
        private static void PrintValue(int pIndent, string pName, string pValue)
        {
            string indent = "".PadLeft((pIndent + 1) * 4);
            if (pName == null)
            {
                _logger.Fine("{0}{1}", indent, pValue);
                return;
            }
            _logger.Fine("{0}{1} = {2}", indent, pName, pValue);
        }

        /// <summary>
        /// Prints a memory space recursively for object instances.
        /// </summary>
        private void Dump(ICollection<DataType> pAlreadySeen, IEnumerable<MemoryItem> pMemory, int pIndent)
        {
            HashSet<DataType> thisLevel = new HashSet<DataType>(pAlreadySeen);
            foreach (MemoryItem item in pMemory)
            {
                if (!thisLevel.Contains(item.Data))
                {
                    thisLevel.Add(item.Data);
                }
                Print(thisLevel, pIndent, item.Name, item.Data, pAlreadySeen.Contains(item.Data));
            }
        }

        /// <summary>
        /// Prints a variable item.
        /// </summary>
        private void Print(ICollection<DataType> pAlreadySeen, int pIndent, string pName, DataType pData,
                           bool pRecursion)
        {
            iMemoryDump dump = pData is InstanceType
                ? ((InstanceType)pData).GetMembers()
                : pData as iMemoryDump;

            if (dump != null)
            {
                string message = pData is InstanceType
                    ? ((InstanceType)pData).ClassName.ToString()
                    : pData is ArrayType
                        ? String.Format("array({0})", pName)
                        : pData.GetType().Name;

                if (pRecursion)
                {
                    PrintValue(pIndent, pName, String.Format("{0}[ <<recursion>> ]", message));
                    return;
                }

                PrintCollection(pAlreadySeen, pIndent, pName, message, dump);
                return;
            }

            PrintValue(pIndent, pName, pData.ToString());
        }

        /// <summary>
        /// Prints the contents of a memory storage object.
        /// </summary>
        private void PrintCollection(ICollection<DataType> pAlreadySeen, int pIndent, string pName, string pMessage,
                                     iMemoryDump pMemory)
        {
            IList<MemoryItem> items = pMemory.Dump().ToList();
            if (items.Count == 0)
            {
                PrintValue(pIndent, pName, String.Format("{0}[]", pMessage));
                return;
            }

            PrintValue(pIndent, pName, String.Format("{0}[", pMessage));
            Dump(pAlreadySeen, items, pIndent + 1);
            PrintValue(pIndent, null, "]");
        }

        /// <summary>
        /// Prints a memory space recursively for object instances.
        /// </summary>
        public void Dump(IEnumerable<MemoryItem> pMemory)
        {
            Dump(new HashSet<DataType>(), pMemory, 0);
        }
    }
}