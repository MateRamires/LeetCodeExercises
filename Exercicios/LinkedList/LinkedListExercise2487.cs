using Exercicios.LinkedList.Utility;

namespace Exercicios.LinkedList;

public class LinkedListExercise2487
{
    public ListNode RemoveNodes(ListNode head)
    {
        ListNode current = head;
        Stack<ListNode> stack = new Stack<ListNode>();
        while (current != null) 
        {
            while (stack.Count > 0 && stack.Peek().val < current.val) 
            {
                stack.Pop();
            }
            stack.Push(current);

            current = current.next; 
        }

        List<ListNode> nodes = stack.ToList();

        ListNode dummy = new ListNode(0);
        current = dummy;
        while (head != null) 
        {
            if (nodes[nodes.Count - 1] == head) 
            {
                current.next = head;
                current = current.next;
                nodes.RemoveAt(nodes.Count - 1);
            }
                
            head = head.next;
        }

        return dummy.next;
    }
}
