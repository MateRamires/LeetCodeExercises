using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise141
{
    public bool HasCycle(ListNode head) 
    {
        ListNode fastPointer = head, slowPointer = head;

        while (fastPointer != null && fastPointer.next != null) 
        {
            fastPointer = fastPointer.next.next;
            slowPointer = slowPointer.next;

            if (fastPointer == slowPointer)
                return true;          
        }

        return false;
    }

    public bool HasCycle2(ListNode head)
    {
        if (head == null || head.next == null) return false;

        ListNode slowPointer = head, fastPointer = head.next;

        while (fastPointer != null && fastPointer.next != null) 
        { 
            if(slowPointer == fastPointer)
                return true;

            slowPointer = slowPointer.next; 
            fastPointer = fastPointer.next.next;
        }

        return false;
    }
}
