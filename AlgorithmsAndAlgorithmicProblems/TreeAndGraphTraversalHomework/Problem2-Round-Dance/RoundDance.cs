using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_Round_Dance
{
    class RoundDance
    {
        static Dictionary<int, List<int>> nodesChildren = new Dictionary<int, List<int>>();
        static bool[] visited;

        static void AddChildToNode(int parent, int child)
        {
            if (!nodesChildren.ContainsKey(parent))
            {
                nodesChildren.Add(parent, new List<int>());
            }

            nodesChildren[parent].Add(child);
        }

        static int DFS(int node, int depth, int parent)
        {
            int maxDepth = depth, childDepth;

            foreach (var child in nodesChildren[node])
            {
                // Because of the two-way connection, if the child is the one who called DFS from the node, we will get a DFS cycling back and forth...
                if (child != parent)
                {
                    childDepth = DFS(child, depth + 1, node);
                    if (childDepth > maxDepth)
                    {
                        maxDepth = childDepth;
                    }
                }
            }

            return maxDepth;
        }

        static void Main(string[] args)
        {
            int f = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            visited = new bool[f];
            char[] separators = new char[] { ' ' };
            int[] edge;

            for (int i = 0; i < f; i++)
            {
                edge = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                // Adding two-way connection...
                AddChildToNode(edge[0], edge[1]);
                AddChildToNode(edge[1], edge[0]);
            }

            int maxDepth = DFS(k, 1, -1);
            Console.WriteLine(maxDepth);
        }
    }
}
