using Exercicios.LinkedList.Utility;
using System;
using System.Reflection;

namespace Exercicios.LinkedList;

public class LinkedListExercise876
{
    public ListNode MiddleNode(ListNode head)
    {
        Dictionary<int, ListNode> keyValuePairs = new Dictionary<int, ListNode>();
        int count = 0;

        while (head != null) 
        {
            count++;

            keyValuePairs.Add(count, head);

            head = head.next;
            
        }

        var index = 0;
        if (count % 2 == 0)
        {
            index = (count / 2) + 1;
        }
        else 
        { 
            index = (count + 1) / 2;
        }

        return keyValuePairs[index];
    }
}
