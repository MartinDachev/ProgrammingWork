using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> words = new List<string>(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            words.Sort();
            foreach (string word in words)
            {
                Console.Write(word + ' ');
            }
        }
    }
}
