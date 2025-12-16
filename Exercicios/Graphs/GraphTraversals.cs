using Exercicios.Graphs.Helpers;

namespace Exercicios.Graphs;

public class GraphTraversals
{
    public List<int> traversal(int n, int[][] edges, int startingPoint) 
    {
        var graph = GraphHelpers.BuildUndirected(n, edges);
        var visited = new bool[n];
        var answer = new List<int>();


        DFSTraversal(graph, startingPoint, visited, answer);
        BFSTraversal(graph, startingPoint, visited, answer);

        return answer;
    }

    public void DFSTraversal(List<int>[] graph, int node, bool[] visited, List<int> answer) 
    {
        visited[node] = true;
        answer.Add(node);

        foreach (var neighbor in graph[node]) 
        {
            if (!visited[neighbor]) 
            {
                DFSTraversal(graph, neighbor, visited, answer);
            }
        }
    }

    public void BFSTraversal(List<int>[] graph, int startingPoint, bool[] visited, List<int> answer)
    {
        var queue = new Queue<int>();
        queue.Enqueue(startingPoint);
        visited[startingPoint] = true;

        while (queue.Count > 0) 
        { 
            var currentNode = queue.Dequeue();
            answer.Add(currentNode);
            foreach (var neighbor in graph[currentNode])
            {
                if (!visited[neighbor]) 
                { 
                    queue.Enqueue(neighbor);
                    visited[neighbor] = true;
                }
            }
        }
    }
}
