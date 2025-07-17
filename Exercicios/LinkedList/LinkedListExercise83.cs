using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise83
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        HashSet<int> uniqueValues = new HashSet<int>();

        ListNode dummy = new ListNode(0, head);
        ListNode previous = dummy, currentNode = head;
        while (currentNode != null) 
        {
            if (!uniqueValues.Contains(currentNode.val))
            {
                uniqueValues.Add(currentNode.val);
                previous = currentNode;
            }
            else 
            { 
                ListNode next = currentNode.next;
                previous.next = next;
            }
            currentNode = currentNode.next;
        }

        return dummy.next;
    }
}
