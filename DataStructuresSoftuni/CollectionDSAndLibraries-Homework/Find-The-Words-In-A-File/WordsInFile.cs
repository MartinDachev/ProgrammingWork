using System;
using System.Collections.Generic;
using System.IO;

namespace Find_The_Words_In_A_File
{
    class WordsInFile
    {
        static void Main(string[] args)
        {
            char[] separators = { ' ', '.', ',', '!', '?', '/', ':', ';', '\\', '|' };
            var wordsCount = new Dictionary<string, int>();
            StreamReader fileReader = new StreamReader("text.txt");
            string line;

            while ((line = fileReader.ReadLine()) != null)
            {
                var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (wordsCount.ContainsKey(word))
                    {
                        ++wordsCount[word];
                    }
                    else
                    {
                        wordsCount.Add(word, 1);
                    }
                }
            }

            foreach (var word in wordsCount)
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
        }
    }
}
