using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise1721
{
    public ListNode SwapNodes(ListNode head, int k)
    {
        ListNode leftPointer = head, rightPointer = head;
        for (int i = 0; i < k; i++)
            rightPointer = rightPointer.next;

        ListNode firstNodeToBeSwapped = head;
        for (int i = 1; i < k; i++)
            firstNodeToBeSwapped = firstNodeToBeSwapped.next;

        while (rightPointer != null) 
        {
            rightPointer = rightPointer.next;
            leftPointer = leftPointer.next;
        }

        int aux = firstNodeToBeSwapped.val;
        firstNodeToBeSwapped.val = leftPointer.val;
        leftPointer.val = aux;

        return head;

    }
}
