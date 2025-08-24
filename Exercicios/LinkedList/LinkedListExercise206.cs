using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise206
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode previousNode = null;
        ListNode currentNode = head;
        while (currentNode != null) 
        {
            var aux = currentNode.next;
            currentNode.next = previousNode;
            previousNode = currentNode;
            currentNode = aux;
        }
        return previousNode;
    }
}
