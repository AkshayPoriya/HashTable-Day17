// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HashTable.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya "/>
// --------------------------------------------------------------------------------------------------------------------
namespace HashTableDS
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Implementation of unordered_map, dictionary<key,value> also known as HashTable
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    class HashTable <K,V> 
    {
        /// <summary>
        /// items is array of linkedlists which will store our all key value pairs at different index
        /// index will be distributed using GetHashCode function
        /// </summary>
        private readonly LinkedList<KeyValue<K, V>>[] items;

        /// <summary>
        /// The size of items array, size should be large to make operations in constant time
        /// </summary>
        private const int SIZE = (int)1e2;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashTable{K, V}"/> class.
        /// </summary>
        public HashTable()
        {
            items = new LinkedList<KeyValue<K, V>>[SIZE];
        }

        /// <summary>
        /// Gets the index of key using hashcode function.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public int GetIndex(K key)
        {
            int hashCode = key.GetHashCode();
            int index = Math.Abs(hashCode % SIZE); /// Abs function used in case hashCode is negative
            return index;
        }

        /// <summary>
        /// Gets the linked list at given index from items array.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public LinkedList<KeyValue<K, V>> GetLinkedList(int index)
        {
            if (items[index] == null)
            {
                items[index] = new LinkedList<KeyValue<K, V>>();
            }
            return items[index];
        }

        /// <summary>
        /// Adds the specified key and value pair in items array at proper index.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public void Add(K key, V value)
        {
            int index = GetIndex(key);
            LinkedList<KeyValue<K, V>> list = GetLinkedList(index);
            KeyValue<K, V> keyValue = new KeyValue<K, V>() { Key = key, Value = value };
            foreach(KeyValue<K,V> pair in list)
            {
                if (pair.Key.Equals(key))
                {
                    list.Remove(pair);
                    break;
                }
            }
            list.AddLast(keyValue);
        }

        /// <summary>
        /// Gets the value corresponding to key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public V Get(K key)
        {
            int index = GetIndex(key);
            LinkedList<KeyValue<K, V>> list = GetLinkedList(index);
            foreach(KeyValue<K,V> pair in list)
            {
                if(pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
            return default(V);
        }

        /// <summary>
        /// Removes the key value pair for specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public void Remove(K key)
        {
            int index = GetIndex(key);
            LinkedList<KeyValue<K, V>> list = GetLinkedList(index);
            KeyValue<K, V> keyValue = default(KeyValue<K,V>);
            bool flag = false;
            foreach(KeyValue<K,V> pair in list)
            {
                if (pair.Key.Equals(key))
                {
                    keyValue = pair;
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                list.Remove(keyValue);
            }
        }
    }

    /// <summary>
    /// Struct to define KeyValue pair, struct is more appropriate than class to define pairs
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public struct KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }
}
