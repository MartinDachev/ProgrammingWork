using System;
using System.Linq;

namespace _4.Subsets_of_String_Array
{
    class SubsetsOfStringArray
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            string[] array = inputLine.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[k];

            GenerateSubsets(array, arr, k);
        }

        static void GenerateSubsets(string[] array, int[] arr, int k, int index = 0, int start = 0)
        {
            if (index >= k)
            {
                Print(array, arr);
            }
            else
            {
                for (int i = start; i < array.Length; i++)
                {
                    arr[index] = i;
                    GenerateSubsets(array, arr, k, index + 1, i + 1);
                }
            }
        }

        static void Print(string[] array, int[] arr)
        {
            Console.WriteLine("({0})", string.Join(",", arr.Select(e => array[e])));
        }
    }
}
