using Exercicios.Array___Hash;
using Exercicios.Binary_Search;
using Exercicios.LinkedList;
using Exercicios.LinkedList.Utility;
using Exercicios.Sliding_Window;
using Exercicios.Stack;
using Exercicios.Two_Pointers;

var ex = new LinkedListExercise1669();

var list1 = LinkedListHelpers.Build(new[] { 10, 1, 13, 6, 9, 5 });
var list2 = LinkedListHelpers.Build(new[] { 100000, 100001, 100002 });

var mergedHead = ex.MergeInBetween(list1, 3, 4, list2);

LinkedListHelpers.Print(mergedHead);