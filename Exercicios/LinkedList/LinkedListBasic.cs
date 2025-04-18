namespace Exercicios.LinkedList;

public class LinkedListBasic
{
    public void MontarLista()
    {
        ListNode node3 = new ListNode(30);
        ListNode node2 = new ListNode(20, node3);
        ListNode node1 = new ListNode(10, node2);

        ListNode atual = node1;
        while (atual != null)
        {
            Console.WriteLine(atual.val);
            atual = atual.next;
        }
    }
}
