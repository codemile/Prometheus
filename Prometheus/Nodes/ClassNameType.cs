using System.Collections;
using System.Collections.Generic;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes
{
    /// <summary>
    /// Represents the name of a package, class or object member.
    /// </summary>
    public class ClassNameType : DataType, IList<string>, IEqualityComparer
    {
        /// <summary>
        /// Each part is a member on the path.
        /// </summary>
        public readonly List<string> Members;

        /// <summary>
        /// Gets the name component of the class name.
        /// </summary>
        public string Name
        {
            get { return Members[Members.Count - 1]; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Members.GetEnumerator();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ClassNameType()
        {
            Members = new List<string>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ClassNameType(string pClassName)
        {
            Members = new List<string>(pClassName.Split(new[] {'.'}));
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        /// <param name="pObj1">The first object to compare.</param>
        /// <param name="pObj2">The second object to compare.</param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="pObj1"/> and <paramref name="pObj2"/> are of different
        /// types and neither one can handle comparisons with the other.
        /// </exception>
        public new bool Equals(object pObj1, object pObj2)
        {
            ClassNameType name1 = pObj1 as ClassNameType;
            ClassNameType name2 = pObj2 as ClassNameType;
            if (name1 == null
                || name2 == null
                || name1.Members.Count != name2.Members.Count)
            {
                return false;
            }
            for (int i = 0, c = name1.Members.Count; i < c; i++)
            {
                if (name1[i] != name2[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        /// <param name="pObj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The type of <paramref name="pObj"/> is a reference type and
        /// <paramref name="pObj"/> is null.
        /// </exception>
        public int GetHashCode(object pObj)
        {
            ClassNameType name = (ClassNameType)pObj;
            int code = 0;
            for (int i = 0, c = name.Members.Count; i < c; i++)
            {
                code ^= name.Members[i].GetHashCode();
            }
            return code;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<string> GetEnumerator()
        {
            return Members.GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="pItem">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is
        /// read-only.
        /// </exception>
        public void Add(string pItem)
        {
            Members.Add(pItem);
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
            Members.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
        /// </summary>
        /// <returns>
        /// true if <paramref name="pItem"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise,
        /// false.
        /// </returns>
        /// <param name="pItem">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(string pItem)
        {
            return Members.Contains(pItem);
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
        public void CopyTo(string[] pArray, int pArrayIndex)
        {
            Members.CopyTo(pArray, pArrayIndex);
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
        public bool Remove(string pItem)
        {
            return Members.Remove(pItem);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count
        {
            get { return Members.Count; }
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
        public int IndexOf(string pItem)
        {
            return Members.IndexOf(pItem);
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
        public void Insert(int pIndex, string pItem)
        {
            Members.Insert(pIndex, pItem);
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
            Members.RemoveAt(pIndex);
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
        public string this[int pIndex]
        {
            get { return Members[pIndex]; }
            set { Members[pIndex] = value; }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Join(".", Members);
        }
    }
}