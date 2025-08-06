using Exercicios.Array___Hash;
using Exercicios.Binary_Search;
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


var ex = new TreeBasicExercises();

var tree = TreeNodeHelpers.Build(new int?[] { -2147483648, -2147483648, -2147483648 });

var res = ex.maximumValueInTree(tree);  

Console.WriteLine(res);


/*var ex = new ArrayHashExercise1189();

var res = ex.MaxNumberOfBalloons("loonbalxballpoon");*/


