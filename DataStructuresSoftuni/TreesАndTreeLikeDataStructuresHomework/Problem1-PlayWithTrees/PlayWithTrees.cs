using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1_PlayWithTrees
{
    class PlayWithTrees
    {
        static Dictionary<int, Tree<int>> nodeByValue;

        static Tree<int> GetNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue.Add(value, new Tree<int>(value));
            }

            return nodeByValue[value];
        }

        static Tree<int> FindRootNode()
        {
            foreach (var node in nodeByValue.Values)
            {
                if (node.Parent == null)
                {
                    return node;
                }
            }

            return null;
        }

        static List<Tree<int>> FindMiddleNodes()
        {
            List<Tree<int>> middleNodes = new List<Tree<int>>();

            foreach (var node in nodeByValue.Values)
            {
                if (node.Children.Count > 0 && node.Parent != null)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        static List<Tree<int>> FindLeafNodes()
        {
            List<Tree<int>> middleNodes = new List<Tree<int>>();

            foreach (var node in nodeByValue.Values)
            {
                if (node.Children.Count == 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        static Tree<int> FindLongestPath(Tree<int> tree)
        {
            Queue<Tree<int>> queue = new Queue<Tree<int>>(nodeByValue.Count);
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                tree = queue.Dequeue();
                for (int i = tree.Children.Count - 1; i >= 0 ; --i)
                {
                    queue.Enqueue(tree.Children[i]);
                }
            }

            return tree;
        }

        static int PrintPath(Tree<int> node, Tree<int> startNode, int depth = 0)
        {
            depth++;
            if(node == startNode)
            {
                Console.Write(node.Value);
                return depth;
            }

            depth = PrintPath(node.Parent, startNode, depth);
            Console.Write(" -> ");
            Console.Write(node.Value);

            return depth;
        }

        static int[][] FindAllPathsWithSum(Tree<int> rootNode, int sum)
        {
            Stack<Tree<int>> dfsStack = new Stack<Tree<int>>();
            Stack<int> pathStack = new Stack<int>();
            Stack<int[]> allPaths = new Stack<int[]>();
            Tree<int> currentNode, rNode;
            int currentSum = 0;
            dfsStack.Push(rootNode);

            while (dfsStack.Count > 0)
            {
                currentNode = dfsStack.Pop();
                rNode = currentNode;
                currentSum = 0;
                pathStack.Clear();

                while (rNode != null)
                {
                    currentSum += rNode.Value;
                    pathStack.Push(rNode.Value);

                    if (currentSum == sum)
                    {
                        allPaths.Push(pathStack.ToArray());
                    }

                    rNode = rNode.Parent;
                }

                for (int i = 0; i < currentNode.Children.Count; ++i)
                {
                    dfsStack.Push(currentNode.Children[i]);
                }
            }

            return allPaths.ToArray();
        }

        static int FindAllSubtreesWithSum(Tree<int> node, int targetSum, ref List<Tree<int>> subtreeRootNodes)
        {
            int currentSum = node.Value;

            for (int i = 0; i < node.Children.Count; ++i)
            {
                currentSum += FindAllSubtreesWithSum(node.Children[i], targetSum, ref subtreeRootNodes);
            }

            if (currentSum == targetSum)
            {
                subtreeRootNodes.Add(node);
            }

            return currentSum;
        }

        static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            nodeByValue = new Dictionary<int, Tree<int>>(numberOfNodes);
            int[] edge = new int[2];
            char[] separators = { ' ' };

            for (int i = 1; i < numberOfNodes; ++i)
            {
                edge = Array.ConvertAll(Console.ReadLine().Split(separators, StringSplitOptions.None), int.Parse);
                Tree<int> parentNode = GetNodeByValue(edge[0]);
                Tree<int> childNode = GetNodeByValue(edge[1]);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());
            Tree<int> rootNode = FindRootNode();

            Console.WriteLine("Root Node: {0}", rootNode.Value);

            List<Tree<int>> leafNodes = FindLeafNodes();
            leafNodes.Sort((a, b) => a.Value.CompareTo(b.Value));
            Console.Write("Leaf Nodes: ");

            foreach (var node in leafNodes)
            {
                Console.Write(node.Value + " ");
            }

            Console.WriteLine();

            List<Tree<int>> middleNodes = FindMiddleNodes();
            middleNodes.Sort((a, b) => a.Value.CompareTo(b.Value));
            Console.Write("Middle Nodes: ");

            foreach (var node in middleNodes)
            {
                Console.Write(node.Value + " ");
            }

            Console.WriteLine();

            Tree<int> pathNode = FindLongestPath(rootNode);
            Console.Write("Longest path: ");
            int pathLength = PrintPath(pathNode, rootNode);
            Console.WriteLine(" (length {0})", pathLength);

            Console.WriteLine("Paths of sum {0}: ", pathSum);
            int[][] allPaths = FindAllPathsWithSum(rootNode, pathSum);
            for (int i = 0; i < allPaths.Length; ++i)
            {
                Console.WriteLine(string.Join(" -> ", allPaths[i]));
            }

            Console.WriteLine("Subtrees of sum {0}:", subtreeSum);
            List<Tree<int>> subtreeRootNodes = new List<Tree<int>>();
            FindAllSubtreesWithSum(rootNode, subtreeSum, ref subtreeRootNodes);

            for (int i = 0; i < subtreeRootNodes.Count; ++i)
            {
                subtreeRootNodes[i].PrintSubtreeSum();
                Console.WriteLine();
            }
        }
    }
}
