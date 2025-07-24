using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise3217
{
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        HashSet<int> numsToHash = new HashSet<int>();
        numsToHash = nums.ToHashSet();

        ListNode dummy = new ListNode(0, head);
        ListNode previous = dummy, current = head;
        while (current != null) 
        {
            if (numsToHash.Contains(current.val)) 
            {
                previous.next = current.next;
            }
            else
            {
                previous = previous.next;
            }
            current = current.next;
        }

        return dummy.next;
    }
}
