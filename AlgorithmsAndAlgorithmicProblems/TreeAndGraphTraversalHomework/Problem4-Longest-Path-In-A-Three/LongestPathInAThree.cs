using System; 
using System.Collections.Generic; 
using System.Linq; 


namespace Problem4_Longest_Path_In_A_Three
{
    class LongestPathInTree
    {
        static Dictionary<int, List<int>> nodesChildren = new Dictionary<int, List<int>>();
        static Dictionary<int, int?> nodesParents = new Dictionary<int, int?>();

        static void AddChildToNode(int parent, int child)
        {
            if (!nodesChildren.ContainsKey(parent))
            {
                nodesChildren.Add(parent, new List<int>());
            }

            nodesChildren[parent].Add(child);
        }

        static void AddNodeToParent(int child, int parent)
        {
            if (!nodesParents.ContainsKey(parent))
            {
                nodesParents.Add(child, parent);
            }
            else
            {
                nodesParents[parent] = parent;
            }
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            char[] separators = new char[] { ' ' };
            int[] edge;

            for (int i = 0; i < m; i++)
            {
                edge = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                AddChildToNode(edge[0], edge[1]);
                AddNodeToParent(edge[1], edge[0]);
            }



        }
    }
 }
