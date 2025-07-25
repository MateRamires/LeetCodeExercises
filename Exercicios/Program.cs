using Exercicios.Array___Hash;
using Exercicios.Binary_Search;
using Exercicios.LinkedList;
using Exercicios.LinkedList.Utility;
using Exercicios.Sliding_Window;
using Exercicios.Stack;
using Exercicios.Two_Pointers;

/*var ex = new LinkedListExercise3217();

var list1 = LinkedListHelpers.Build(new[] { 1, 2, 1, 2, 1, 2 });

var mergedHead = ex.ModifiedList([1], list1);

LinkedListHelpers.Print(mergedHead);*/


var ex = new SlidingWindowExercise3208();

var res = ex.NumberOfAlternatingGroups([0, 1, 0, 0, 1, 0, 1], 6);

Console.WriteLine(res);