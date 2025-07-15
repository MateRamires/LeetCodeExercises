using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise21
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode(0);
        ListNode currentNode = dummy;

        while (list1 != null && list2 != null) 
        {
            if (list1.val < list2.val)
            {
                currentNode.next = list1;
                list1 = list1.next;
                currentNode = currentNode.next;
            }
            else if (list2.val < list1.val) 
            {
                currentNode.next = list2;
                list2 = list2.next;
                currentNode = currentNode.next;
            }
            else
            {
                currentNode.next = list1;
                list1 = list1.next;
                currentNode = currentNode.next;
            }
        }

        if (list1 != null)
            currentNode.next = list1;
        else 
            currentNode.next = list2;

        return dummy.next;
    }
}
