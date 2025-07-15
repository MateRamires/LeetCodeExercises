namespace Exercicios.LinkedList.Utility;

public class LinkedListHelpers
{
    // Constrói uma lista encadeada a partir de um array.
    public static ListNode Build(int[] values)
    {
        var dummy = new ListNode();      // nó sentinela para simplificar
        var tail = dummy;

        foreach (int v in values)
        {
            tail.next = new ListNode(v);
            tail = tail.next;
        }
        return dummy.next;               // cabeça real da lista
    }

    // Imprime "1 -> 2 -> 3" em uma única linha.
    public static void Print(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val);
            head = head.next;
            if (head != null) Console.Write(" -> ");
        }
        Console.WriteLine();
    }
}
