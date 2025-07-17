using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise203
{
    public ListNode RemoveElements(ListNode head, int val) //Without Extra Space
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

    public ListNode RemoveElements2(ListNode head, int val) //With Extra Space
    {
        ListNode dummy = new ListNode(0);
        ListNode currentNode = dummy;

        while (head != null) 
        {
            if (head.val != val) 
            { 
                currentNode.next = new ListNode(head.val);
                currentNode = currentNode.next;
            }

            head = head.next;
        }

        return dummy.next;
    }
}
