using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise203
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        ListNode dummy = new ListNode(0, head);
        ListNode prev = dummy, currentNode = head;
        while (currentNode != null) 
        {
            ListNode next = currentNode.next;
            if (currentNode.val == val)
            {
                prev.next = next;
            }
            else 
            { 
                prev = currentNode;
            }
            currentNode = next;
        }

        return dummy.next;
    }
}
