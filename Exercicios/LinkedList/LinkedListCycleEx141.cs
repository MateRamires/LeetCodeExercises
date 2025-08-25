using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListCycleEx141
{
    public bool HasCycle(ListNode head)
    {
        if (head == null)  return false;

        ListNode slowPointer = head;
        ListNode fastPointer = head.next;

        while (fastPointer != null && fastPointer.next != null) 
        {
            if (slowPointer == fastPointer)
                return true;

            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next.next;
        }

        return false;
    }
}
