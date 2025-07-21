using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise2058
{
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        ListNode previous = head, current = head.next;
        int currentNode = 1;
        List<int> criticalIndexes = new List<int>();
        while (current.next != null) 
        {
            if ((current.val > previous.val && current.val > current.next.val) 
                || (current.val < previous.val && current.val < current.next.val))
            {
                criticalIndexes.Add(currentNode);
            }

            currentNode++;
            previous = previous.next;
            current = current.next;
        }

        if (criticalIndexes.Count < 2)
            return new int[] { -1, -1 };

        int minimumDistance = int.MaxValue;
        for (int i = 0; i < criticalIndexes.Count - 1; i++)
        {
            minimumDistance = Math.Min(minimumDistance, criticalIndexes[i + 1] - criticalIndexes[i]);
        }

        return new int[] { minimumDistance, criticalIndexes[criticalIndexes.Count - 1] - criticalIndexes[0] };
    }
}
