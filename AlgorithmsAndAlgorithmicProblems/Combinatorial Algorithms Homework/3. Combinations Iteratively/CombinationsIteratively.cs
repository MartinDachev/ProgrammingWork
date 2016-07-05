using System;
using System.Linq;

namespace _3.Combinations_Iteratively
{
    class CombinationsIteratively
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            GenerateCombinations(n, k);
        } 

        static void GenerateCombinations(int n, int k)
        {
            int[] array = Enumerable.Range(1, k).ToArray();
            int index = n - 1;
            int start;
            while(true)
            {
                Print(array);
                if (array[0] > n)
                {
                    break;
                }

                index = k - 1;
                while (index >= 0 && array[index] >= index + n - k + 1)
                {
                    index--;
                }

                if (index < 0)
                {
                    break;
                }

                start = array[index];
                for (int i = index; i < k; i++)
                {
                    array[i] = ++start;
                }
            }
        }

        static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(",", array));
        }
    }
}
