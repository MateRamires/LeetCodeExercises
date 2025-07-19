using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise2181
{
    public ListNode MergeNodes(ListNode head)
    {
        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;
        int currentSum = 0;

        head = head.next; //Skip first element, which is always zero.
        while (head != null) 
        {
            currentSum += head.val;

            if (head.val == 0) 
            {
                tail.next = new ListNode(currentSum);
                currentSum = 0;
                tail = tail.next;
            }

            head = head.next;
        }

        return dummy.next;
    }
}
