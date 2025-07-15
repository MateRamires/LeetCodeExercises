using Exercicios.Array___Hash;
using Exercicios.Binary_Search;
using Exercicios.LinkedList;
using Exercicios.LinkedList.Utility;
using Exercicios.Sliding_Window;
using Exercicios.Stack;
using Exercicios.Two_Pointers;

var ex = new LinkedListExercise21();

var list1 = LinkedListHelpers.Build(new[] { 1, 2, 4 });
var list2 = LinkedListHelpers.Build(new[] { 1, 3, 4 });

var mergedHead = ex.MergeTwoLists(list1, list2);

LinkedListHelpers.Print(mergedHead);