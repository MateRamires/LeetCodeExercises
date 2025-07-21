using Exercicios.Array___Hash;
using Exercicios.Binary_Search;
using Exercicios.LinkedList;
using Exercicios.LinkedList.Utility;
using Exercicios.Sliding_Window;
using Exercicios.Stack;
using Exercicios.Two_Pointers;

var ex = new LinkedListExercise2058();

var list1 = LinkedListHelpers.Build(new[] { 5, 3, 1, 2, 5, 1, 2 });

var mergedHead = ex.NodesBetweenCriticalPoints(list1);

//LinkedListHelpers.Print(mergedHead);