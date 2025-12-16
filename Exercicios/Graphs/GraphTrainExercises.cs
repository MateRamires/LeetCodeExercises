using Exercicios.Graphs.Helpers;
using System.ComponentModel;

namespace Exercicios.Graphs;

public class GraphTrainExercises
{
    public int CountComponents(int n, int[][] edges) 
    {
        var graph = GraphHelpers.BuildUndirected(n, edges);
        bool[] visited = new bool[n];
        var count = 0;

        for (int i = 0; i < n; i++) 
        {
            if (!visited[i]) 
            {
                DFS(graph, i, visited);
                count++;
            }
        }

        return count;
    }

    private void DFS(List<int>[] graph, int currentNode, bool[] visitedNodes) 
    {
        visitedNodes[currentNode] = true;

        foreach (var neighbor in graph[currentNode]) 
        {
            if (!visitedNodes[neighbor])
            {
                DFS(graph, neighbor, visitedNodes);
            }
        }
    }

    private void BFS(List<int>[] graph, int node, bool[] visitedNodes) 
    {
        var queue = new Queue<int>();
        queue.Enqueue(node);


        while (queue.Count > 0) 
        {
            var currentNode = queue.Dequeue();
            visitedNodes[currentNode] = true;

            foreach (var neighbor in graph[currentNode]) 
            {
                if (!visitedNodes[neighbor]) 
                {
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}
