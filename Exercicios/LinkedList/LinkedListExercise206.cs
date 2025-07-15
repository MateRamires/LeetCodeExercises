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
            ListNode temp = currentNode.next;
            currentNode.next = previousNode;
            previousNode = currentNode;
            currentNode = temp;
        }

        return previousNode;
    }
}
