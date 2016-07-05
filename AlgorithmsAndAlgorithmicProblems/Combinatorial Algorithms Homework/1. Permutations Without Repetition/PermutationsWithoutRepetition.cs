using System;
using System.Linq;

namespace _1.Permutations_Without_Repetition
{
    class PermutationsWithoutRepetition
    {
        static int count = 0;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var array = Enumerable.Range(1, n).ToArray();

            GeneratePermutations(array);
            Console.WriteLine("Total permutations: {0}", count);
        }

        static void GeneratePermutations(int[] array, int index = 0)
        {
            if (index >= array.Length - 1)
            {
                Print(array);
                ++count;
            }
            else
            {
                for (int i = index; i < array.Length; i++)
                {
                    Swap(ref array[i], ref array[index]);
                    GeneratePermutations(array, index + 1);
                    Swap(ref array[i], ref array[index]);
                }
            }
        }

        static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(",", array));
        }

        static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }
}
