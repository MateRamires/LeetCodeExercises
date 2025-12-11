namespace Exercicios.Graphs;

public class GraphTraversals
{
    public void DfsTraversal(List<int>[] graph, int startingPoint) 
    { 
        int numberOfNodes = graph.Length;
        var visited = new bool[numberOfNodes];

        Console.WriteLine("DFS a partir do ponto " + startingPoint + ":");
        DFS(graph, startingPoint, visited);
        Console.WriteLine();
    }

    public void DFS(List<int>[] graph, int node, bool[] visited) 
    {
        if (visited[node]) return;

        visited[node] = true;
        Console.WriteLine(node + " ");

        foreach (int neighbor in graph[node]) 
        {
            if (!visited[neighbor]) 
            { 
                DFS(graph, neighbor, visited);
            }
        }
    }

    public void BFSTraversal(List<int>[] graph, int startingPoint) 
    { 
        int numberOfNodes = graph.Length;
        var visited = new bool[numberOfNodes];
        var queue = new Queue<int>();

        visited[startingPoint] = true;
        queue.Enqueue(startingPoint);

        Console.WriteLine("BFS a partir do ponto " + startingPoint + ":");

        while (queue.Count > 0) 
        { 
            int currentNode = queue.Dequeue();
            Console.WriteLine(currentNode + " ");

            foreach (int neighbor in graph[currentNode]) 
            {
                if (!visited[neighbor]) 
                { 
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        Console.WriteLine();
    }
}
