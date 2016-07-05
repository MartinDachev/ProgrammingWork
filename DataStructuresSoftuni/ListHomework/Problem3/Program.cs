using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3
{
    class Program
    {
        static List<int> LongestSubsequence(List<int> numbers)
        {
            List<int> result = new List<int>(numbers.Count / 2);

            if (numbers.Count > 0)
            {
                int lastNumber = numbers[0];
                int longestCount = -1, currentCount = 0, repeatedNumber = 0;
                for (int i = 0; i < numbers.Count; ++i)
                {
                    if (numbers[i] == lastNumber)
                    {
                        ++currentCount;
                    }
                    else
                    {
                        if (currentCount > longestCount)
                        {
                            longestCount = currentCount;
                            repeatedNumber = lastNumber;
                        }
                        lastNumber = numbers[i];
                        currentCount = 1;
                    }
                }

                if (currentCount > longestCount)
                {
                    longestCount = currentCount;
                    repeatedNumber = lastNumber;
                }
                for (int i = 0; i < longestCount; i++)
                {
                    result.Add(repeatedNumber);
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> numbers = new List<int>(Array.ConvertAll(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse));
            List<int> longestSubsequence = LongestSubsequence(numbers);
            foreach(int number in longestSubsequence)
            {
                Console.Write(number + " ");
            }
        }
    }
}
