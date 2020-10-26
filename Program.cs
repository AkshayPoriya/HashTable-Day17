// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya "/>
// --------------------------------------------------------------------------------------------------------------------

namespace HashTableDS
{
    using System;

    /// <summary>
    /// Contains Main Function
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            HashTable<int, int> hashTable = new HashTable<int, int>();
            hashTable.Add(1, 1);
            Console.WriteLine("Value at key 1: " + hashTable.Get(1));
            hashTable.Add(2, 100);
            Console.WriteLine("Value at key 2: " + hashTable.Get(2));
            hashTable.Add(1, 50);
            Console.WriteLine("Value at key 1: " + hashTable.Get(1));
        }
    }
}
