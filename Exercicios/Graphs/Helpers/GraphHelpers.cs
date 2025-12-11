namespace Exercicios.Graphs.Helpers;

public class GraphHelpers
{
    // edges: cada elemento é [u, v]
    public static List<int>[] BuildUndirected(int n, int[][] edges)
    {
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (var e in edges)
        {
            int u = e[0];
            int v = e[1];

            graph[u].Add(v);
            graph[v].Add(u);
        }

        return graph;
    }

    public static List<int>[] BuildDirected(int n, int[][] edges)
    {
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (var e in edges)
        {
            int u = e[0];
            int v = e[1];

            graph[u].Add(v);
        }

        return graph;
    }

    public static void Print(List<int>[] graph)
    {
        for (int v = 0; v < graph.Length; v++)
        {
            Console.Write(v + ": ");
            Console.WriteLine(string.Join(",", graph[v]));
        }
    }
}
