using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] numbers = Array.ConvertAll(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            Dictionary<int, int> occurences = new Dictionary<int, int>(numbers.Length);

            for (int i = 0; i < numbers.Length; i++)
            {
                if (occurences.ContainsKey(numbers[i]))
                {
                    ++occurences[numbers[i]];
                }
                else
                {
                    occurences.Add(numbers[i], 1);
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (occurences[numbers[i]] % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}
