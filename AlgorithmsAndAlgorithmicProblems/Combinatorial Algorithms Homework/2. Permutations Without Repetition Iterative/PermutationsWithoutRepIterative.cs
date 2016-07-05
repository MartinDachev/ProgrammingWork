using System;
using System.Linq;

namespace _2.Permutations_Without_Repetition_Iterative
{
    class PermutationsWithoutRepIterative
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            QuickPerm(n);
        }

        static void QuickPerm(int n)
        {
            int[] a = Enumerable.Range(1, n).ToArray();
            int[] p = new int[n];
            int i, j, temp;

            Print(a);

            i = 1;
            while(i < n)
            {
                if (p[i] < i)
                {
                    j = i % 2 * p[i];
                    temp = a[j];
                    a[j] = a[i];
                    a[i] = temp;
                    Print(a);
                    p[i]++;
                    i = 1;
                }
                else
                {
                    p[i] = 0;
                    i++;
                }
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(",", array));
        }
    }
}
