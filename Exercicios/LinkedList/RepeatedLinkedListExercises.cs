using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class RepeatedLinkedListExercises
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode(0);
        ListNode currentNode = dummy;

        while (list1 != null && list2 != null) 
        {
            if (list1.val > list2.val) 
            {
                currentNode.next = list2;
                list2 = list2.next;
            }
            else
            {
                currentNode.next = list1;
                list1 = list1.next;
            }
            currentNode = currentNode.next;
        }

        if (list1 != null)
            currentNode.next = list1;
        else
            currentNode.next = list2;

        return dummy.next;
    }

    //Ex 141: Linked List Cycle
    public bool HasCycle(ListNode head)
    {
        if (head == null) return false;

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
