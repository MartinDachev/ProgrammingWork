using System;
using System.Linq;


namespace Problem1_Find_The_Root
{
    class FindTheRoot
    {
        static bool[] hasParent;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            bool alreadyFoundRootNode = false;
            int rootNode = 0;
            char[] separators = new char[] { ' ' };
            int[] edge;
            hasParent = new bool[n];

            for (int i = 0; i < m; i++)
            {
                edge = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                hasParent[edge[1]] = true;
            }

            for (int i = 0; i < n; i++)
            {
                if (!hasParent[i])
                {
                    // If we already have found 1 root node and this is the second we are finding...
                    if (alreadyFoundRootNode)
                    {
                        Console.WriteLine("Multiple root nodes!");
                        return;
                    }
                    rootNode = i;
                    alreadyFoundRootNode = true;
                }
            }

            // If we have found only 1 root node...
            if (alreadyFoundRootNode)
            {
                Console.WriteLine(rootNode);
            }
            else
            {
                Console.WriteLine("No root!");
            }
        }
    }
}
