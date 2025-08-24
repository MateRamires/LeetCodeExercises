﻿using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise21
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        while (list1 != null && list2 != null) 
        {
            if (list1.val > list2.val) 
            { 
                current.next = list2;
                list2 = list2.next;
            }
            else 
            { 
                current.next = list1;
                list1 = list1.next;
            }

            current = current.next;
        }

        if (list2 != null)
            current.next = list2;
        else if (list1 != null)
            current.next = list1;
        
        return dummy.next;
    }
}
