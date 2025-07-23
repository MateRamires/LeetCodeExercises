using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise19
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode dummy = new ListNode(0, head);
        ListNode leftPointer = dummy, rightPointer = head;

        while (n != 0) 
        {
            rightPointer = rightPointer.next;
            n--;
        }

        while (rightPointer != null) 
        { 
            leftPointer = leftPointer.next;
            rightPointer = rightPointer.next;
        }

        leftPointer.next = leftPointer.next.next;
        return dummy.next;
    }
}
