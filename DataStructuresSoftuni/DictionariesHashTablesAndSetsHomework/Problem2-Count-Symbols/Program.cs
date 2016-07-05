using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HashTable;

namespace Problem2_Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashTable<char, int> sybmolCountDictionary = new HashTable<char, int>();

            foreach (var symbol in input)
            {
                if (!sybmolCountDictionary.ContainsKey(symbol))
                {
                    sybmolCountDictionary.Add(symbol, 1);
                }
                else
                {
                    sybmolCountDictionary[symbol]++;
                }
            }

            var symbolsCountSorted = sybmolCountDictionary.ToList();
            symbolsCountSorted.Sort((x, y) => x.Key.CompareTo(y.Key));

            foreach (var symbolCountPair in symbolsCountSorted)
            {
                Console.WriteLine("{0}: {1} time/s", symbolCountPair.Key, symbolCountPair.Value);
            }
        }
    }
}
