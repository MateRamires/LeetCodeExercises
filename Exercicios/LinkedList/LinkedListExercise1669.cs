using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise1669
{
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
        ListNode dummy = new ListNode(0, list1);

        //Apos esse for, o node de list1 sera exatamente um node antes do inicio da insercao dos novos nodes.
        for (int i = 0; i < a - 1; i++) 
        {
            list1 = list1.next;
        }

        ListNode auxNode = list1;
        for (int i = 0; i <= b - a; i++) 
        { 
            auxNode = auxNode.next;
        }

        ListNode dummy2 = new ListNode(0, list2);
        while (list2.next != null) 
        { 
            list2 = list2.next;
        }

        if(auxNode.next != null)
            list2.next = auxNode.next;

        list1.next = dummy2.next; //Inserimos os nodes novos (list2) no lugar dos nodes a serem substituidos

        return dummy.next;
    }
}
