// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya "/>
// --------------------------------------------------------------------------------------------------------------------
namespace HashTableDS
{
    using System;
    using System.Collections.Generic;

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
            FreqOfWordsInSentence();
        }

        /// <summary>
        /// UC1
        /// Freqs the of words in sentence.
        /// </summary>
        static void FreqOfWordsInSentence()
        {
            string sentence = "To be or not to be";
            sentence = sentence.ToLower();
            string[] words = sentence.Split(" ");
            LinkedList<string> uniqueWords = new LinkedList<string>();
            HashTable<string, int> wordFreq = new HashTable<string, int>();
            foreach(string word in words)
            {
                if (!wordFreq.Contains(word))
                {
                    wordFreq.Add(word, 1);
                    uniqueWords.AddLast(word);
                }
                else
                {
                    wordFreq.Add(word, wordFreq.Get(word) + 1);
                }
            }

            foreach(string word in uniqueWords)
            {
                Console.WriteLine("Word: " + word + "\tFrequency: " + wordFreq.Get(word));
            }
        }
    }
}
