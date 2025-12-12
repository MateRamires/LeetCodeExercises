using Exercicios.Graphs.Helpers;

namespace Exercicios.Graphs;

public class GraphTrainExercises
{
    public int CountComponents(int n, int[][] edges) 
    {
        var graph = GraphHelpers.BuildUndirected(n, edges);

        bool[] visited = new bool[n];
        int count = 0;

        for (int i = 0; i < n; i++) 
        {
            if (!visited[i]) 
            {
                BFS(graph, i, visited);
                count++;
            }
        } 

        return count;
    }

    private void DFS(List<int>[] graph, int currentNode, bool[] visitedNodes) 
    {
        visitedNodes[currentNode] = true;

        foreach (int neighbor in graph[currentNode]) 
        {
            if (!visitedNodes[neighbor]) 
            {
                DFS(graph, neighbor, visitedNodes);
            }
        }
    }

    private void BFS(List<int>[] graph, int node, bool[] visitedNodes) 
    {
        visitedNodes[node] = true;
        Queue<int> q = new Queue<int>();
        q.Enqueue(node);

        while (q.Count > 0) 
        { 
            var currentNode = q.Dequeue();

            foreach (var neighbor in graph[currentNode]) 
            {
                if (!visitedNodes[neighbor]) 
                {
                    visitedNodes[neighbor] = true;
                    q.Enqueue(neighbor);
                }
            }
        }
    }
}
