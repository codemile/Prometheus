using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Prometheus.Nodes.Types.Attributes;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Storage;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds an array of values.
    /// </summary>
    [DataTypeInfo("Array")]
    public class ArrayType : DataType, IList<DataType>, iMemoryDump
    {
        /// <summary>
        /// An empty array constant
        /// </summary>
        public static readonly ArrayType Empty = new ArrayType();

        /// <summary>
        /// Values
        /// </summary>
        public readonly List<DataType> Values;

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ArrayType()
        {
            Values = new List<DataType>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ArrayType(int pCount)
        {
            Values = new List<DataType>(pCount);
        }

        /// <summary>
        /// Boxing constructor
        /// </summary>
        /// <param name="pBox">The item to put into the array</param>
        public ArrayType(DataType pBox)
        {
            Values = new List<DataType> {pBox};
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<DataType> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="pItem">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is
        /// read-only.
        /// </exception>
        public void Add(DataType pItem)
        {
            Values.Add(pItem);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is
        /// read-only.
        /// </exception>
        public void Clear()
        {
            Values.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
        /// </summary>
        /// <returns>
        /// true if <paramref name="pItem"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise,
        /// false.
        /// </returns>
        /// <param name="pItem">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(DataType pItem)
        {
            return Values.Contains(pItem);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>,
        /// starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="pArray">
        /// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied
        /// from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based
        /// indexing.
        /// </param>
        /// <param name="pArrayIndex">The zero-based index in <paramref name="pArray"/> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="pArray"/> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="pArrayIndex"/> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException">
        /// The number of elements in the source
        /// <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from
        /// <paramref name="pArrayIndex"/> to the end of the destination <paramref name="pArray"/>.
        /// </exception>
        public void CopyTo(DataType[] pArray, int pArrayIndex)
        {
            Values.CopyTo(pArray, pArrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// true if <paramref name="pItem"/> was successfully removed from the
        /// <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if
        /// <paramref name="pItem"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="pItem">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is
        /// read-only.
        /// </exception>
        public bool Remove(DataType pItem)
        {
            return Values.Remove(pItem);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count
        {
            get { return Values.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </summary>
        /// <returns>
        /// The index of <paramref name="pItem"/> if found in the list; otherwise, -1.
        /// </returns>
        /// <param name="pItem">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
        public int IndexOf(DataType pItem)
        {
            return Values.IndexOf(pItem);
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"/> at the specified index.
        /// </summary>
        /// <param name="pIndex">The zero-based index at which <paramref name="pItem"/> should be inserted.</param>
        /// <param name="pItem">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="pIndex"/> is not a valid index in the
        /// <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
        public void Insert(int pIndex, DataType pItem)
        {
            Values.Insert(pIndex, pItem);
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.Generic.IList`1"/> item at the specified index.
        /// </summary>
        /// <param name="pIndex">The zero-based index of the item to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="pIndex"/> is not a valid index in the
        /// <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
        public void RemoveAt(int pIndex)
        {
            Values.RemoveAt(pIndex);
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <returns>
        /// The element at the specified index.
        /// </returns>
        /// <param name="pIndex">The zero-based index of the element to get or set.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="pIndex"/> is not a valid index in the
        /// <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The property is set and the
        /// <see cref="T:System.Collections.Generic.IList`1"/> is read-only.
        /// </exception>
        public DataType this[int pIndex]
        {
            get { return Values[pIndex]; }
            set { Values[pIndex] = value; }
        }

        /// <summary>
        /// Derived classes will handle the printing.
        /// </summary>
        public IEnumerable<MemoryItem> Dump()
        {
            int count = 0;
            return from item in Values
                   select
                       new MemoryItem
                       {
                           Name = (count++).ToString(CultureInfo.InvariantCulture),
                           Data = item
                       };
        }

        /// <summary>
        /// Creates a deep copy of an array.
        /// </summary>
        public override DataType Clone()
        {
            ArrayType copy = new ArrayType(Values.Count);
            for (int i = 0, c = Values.Count; i < c; i++)
            {
                copy.Add(Values[i].Clone());
            }
            return copy;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return "[" + string.Join(",", from value in Values select value.ToString()) + "]";
        }

        /// <summary>
        /// Appends an array
        /// </summary>
        public void AddRange(ArrayType pArr)
        {
            Values.AddRange(((ArrayType)pArr.Clone()).Values);
        }
    }
}