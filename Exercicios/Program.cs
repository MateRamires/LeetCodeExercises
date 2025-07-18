using Exercicios.Array___Hash;
using Exercicios.Binary_Search;
using Exercicios.LinkedList;
using Exercicios.LinkedList.Utility;
using Exercicios.Sliding_Window;
using Exercicios.Stack;
using Exercicios.Two_Pointers;

var ex = new LinkedListExercise876();

var list1 = LinkedListHelpers.Build(new[] { 1, 2, 3, 4, 5 });

var mergedHead = ex.MiddleNode(list1);

LinkedListHelpers.Print(mergedHead);