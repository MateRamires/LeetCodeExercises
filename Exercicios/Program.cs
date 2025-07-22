using Exercicios.Array___Hash;
using Exercicios.Binary_Search;
using Exercicios.LinkedList;
using Exercicios.LinkedList.Utility;
using Exercicios.Sliding_Window;
using Exercicios.Stack;
using Exercicios.Two_Pointers;

var ex = new LinkedListExercise2487();

var list1 = LinkedListHelpers.Build(new[] { 5, 2, 13, 3, 8 });

var mergedHead = ex.RemoveNodes(list1);

LinkedListHelpers.Print(mergedHead);