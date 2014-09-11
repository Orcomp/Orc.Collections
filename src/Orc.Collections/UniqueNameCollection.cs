namespace Orc.Collections
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// UniqueNameCollection collection is a collection where each item has a unique name identifier.
    /// This collection is used to simplify common interaction, such as checking whether the collection
    /// contains an item with a given name in O(1) time.
    /// Nearly all methods have time complexity of O(1), except Add() and Clear()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UniqueNameCollection<T> : ICollection<T>
        where T : class, IUniqueName
    {
        private readonly Dictionary<string, T> _nameToObject;

        public UniqueNameCollection()
        {
            _nameToObject = new Dictionary<string, T>();
        }

        public UniqueNameCollection(IEnumerable<T> items)
        {
            _nameToObject = items.ToDictionary(x => x.Name, x => x);
        }

        /// <summary>
        /// Return the number of items in the collection
        /// </summary>
        public int Count
        {
            get
            {
                return this._nameToObject.Count;
            }
        }

        /// <summary>
        /// The collection is read/write.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Get object associated with name. If no item is found return null.
        /// Time Complexity: O(1)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Get(string name)
        {
            return this.Contains(name) ? this._nameToObject[name] : null;
        }

        /// <summary>
        /// Returns true or false depending on whether the name exists in the collection,
        /// and return the associated object if it exits; null otherwise.
        /// Time Complexity: O(1)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryGet(string name, out T item)
        {
            item = this.Get(name);

            return item != null;
        }

        /// <summary>
        /// Add an item to the collection.
        /// Will throw if the collection already contains an item with the same name.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            // Let the dictionary throw if the item.Name already exists.
            _nameToObject.Add(item.Name, item);
        }

        /// <summary>
        /// Clear the collection
        /// </summary>
        public void Clear()
        {
            _nameToObject.Clear();
        }

        /// <summary>
        /// Check whether the item is found in the collection.
        /// Since all the items have unique names we can do this in O(1) time.
        /// Time Complexity: O(1)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            // since
            return _nameToObject.ContainsKey(item.Name);
        }

        /// <summary>
        /// Check if collection contains an item with a given name.
        /// Time Complexity: O(1)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Contains(string name)
        {
            return this._nameToObject.ContainsKey(name);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Remove the item from the collection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            return _nameToObject.Remove(item.Name);
        }

        /// <summary>
        /// Remove an item by its name
        /// </summary>
        /// <param name="name"></param>
        public bool Remove(string name)
        {
            return this._nameToObject.Remove(name);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _nameToObject.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}