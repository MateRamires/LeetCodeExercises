using Exercicios.LinkedList.Utility;
using System.Reflection.Metadata.Ecma335;

namespace Exercicios.LinkedList;

public class LinkedListCycleEx141
{
    public bool HasCycle(ListNode head)
    {
        if (head == null) return false;

        var slowPointer = head;
        var fastPointer = head.next;
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
