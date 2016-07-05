using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    // --------- SOURCE REMOVAL TOPOLOGICAL SORTING ALGORITHM ----------
    //
    //public ICollection<string> TopSort()
    //{
    //    var predecessorCount = new Dictionary<string, int>();
    //    foreach (var node in this.graph)
    //    {
    //        if (!predecessorCount.ContainsKey(node.Key))
    //        {
    //            predecessorCount[node.Key] = 0;
    //        }
    //        foreach (var child in node.Value)
    //        {
    //            if (!predecessorCount.ContainsKey(child))
    //            {
    //                predecessorCount[child] = 0;
    //            }
    //            ++predecessorCount[child];
    //        }
    //    }
    //    var removedNodes = new List<string>();
    //    while (true)
    //    {
    //        var source = graph.Keys.FirstOrDefault(n => predecessorCount[n] == 0);
    //        if (source == null)
    //        {
    //            break;
    //        }
    //        removedNodes.Add(source);
    //        foreach (var child in graph[source])
    //        {
    //            --predecessorCount[child];
    //        }
    //        graph.Remove(source);
    //    }
    //    if (graph.Count > 0)
    //    {
    //        throw new InvalidOperationException("A cycle detected in the graph");
    //    }
    //    return removedNodes;
    //}
    //
    // --------------------------------------------------------------------------------

    public ICollection<string> TopSort()
    {
        var sortedNodes = new LinkedList<string>();
        var visitedNodes = new HashSet<string>();
        foreach (var node in graph.Keys)
        {
            DFS(node, ref sortedNodes, ref visitedNodes);
        }
        return sortedNodes.Reverse().ToList();
    }
    private void DFS(string node, ref LinkedList<string> sortedNodes, ref HashSet<string> visitedNodes)
    {
        if (visitedNodes.Contains(node))
        {
            visitedNodes.Add(node);
            foreach (var child in graph[node])
            {
                DFS(child, ref sortedNodes, ref visitedNodes);
            }
            sortedNodes.AddFirst(node);
        }
    }
}