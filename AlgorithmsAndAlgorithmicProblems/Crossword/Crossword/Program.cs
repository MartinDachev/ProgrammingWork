using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static string[] crossword;
    static int n;
    static bool completed = false;

    static bool CheckCrossword(string[] words_arr, int index)
    {
       
        bool isExisting;
        for (int i = 0; i < words_arr.Length / 2; i++)
        {
            StringBuilder sb = new StringBuilder();
            isExisting = false;
            for (int j = 0; j < index; j++)
            {
                sb.Append(crossword[j][i]);
            }
            string str = sb.ToString();
            foreach (string word in words_arr)
            {
                if (word.Substring(0, str.Length).Equals(str))
                {
                    isExisting = true;
                    break;
                }
            }
            if (!isExisting)
            {
               return false;
            }
        }
        return true;
    }

    static void BuildCrossword(string[] words_arr, int count, int index)
    {
        if (index == n)
        {
            if (CheckCrossword(words_arr, index))
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(crossword[i]);
                }
                completed = true;
            }
            return;
        }
        else
        {
            for (int i = 0; i < words_arr.Length; i++)
            {
                if (completed)
                {
                    return;
                }
                crossword[index] = words_arr[i];
                if (CheckCrossword(words_arr, index))
                {
                    BuildCrossword(words_arr, count, index + 1);
                }
            }
        }
    }

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        int count = n * 2;
        crossword = new string[n];
        string[] words_arr = new string[count];
        for (int i = 0; i < count; i++)
        {
            words_arr[i] = Console.ReadLine();
        }
        Array.Sort(words_arr);
        BuildCrossword(words_arr, count, 0);
        if (!completed)
        {
            Console.WriteLine("NO SOLUTION!");
        }

    }
}

