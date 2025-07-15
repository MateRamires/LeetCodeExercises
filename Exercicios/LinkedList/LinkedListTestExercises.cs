using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListTestExercises
{
    public ListNode CreateList(int[] nums) 
    { 
        ListNode dummy = new ListNode(0);
        ListNode currentNode = dummy;

        for (int i = 0; i < nums.Length; i++)
        {
            currentNode.next = new ListNode(nums[i]);

            currentNode = currentNode.next;
        }

        return dummy.next;
    }
}
