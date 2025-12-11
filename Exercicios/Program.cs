using Exercicios.Array___Hash;
using Exercicios.Binary_Search;
using Exercicios.Graphs.Helpers;
using Exercicios.LinkedList;
using Exercicios.LinkedList.Utility;
using Exercicios.Sliding_Window;
using Exercicios.Stack;
using Exercicios.Trees;
using Exercicios.Trees.Helpers;
using Exercicios.Two_Pointers;

/*var ex = new LinkedListExercise1721();

var list1 = LinkedListHelpers.Build(new[] { 100, 90 });

var mergedHead = ex.SwapNodes(list1, 2);

LinkedListHelpers.Print(mergedHead);*/


/*var ex = new SameTreeEx100();

var tree = TreeNodeHelpers.Build(new int?[] { 1, 2 });
var tree2 = TreeNodeHelpers.Build(new int?[] { 1, null, 2 });

var res = ex.IsSameTree(tree, tree2);  

Console.WriteLine(res);*/


/*Grafos*/
int numberOfNodes = 5;

//Ligacao entre os nodes (vizinhos)
int[][] edges = new int[][]
{
    new[] { 0,1 }, //Node 0 tem como vizinho node 1.
    new[] { 0,2 },
    new[] { 1,3 },
    new[] { 1,4 },
};

List<int>[] graph = GraphHelpers.BuildUndirected(numberOfNodes, edges);

Console.WriteLine("Lista de vizinhos: ");
GraphHelpers.Print(graph);
Console.WriteLine();

