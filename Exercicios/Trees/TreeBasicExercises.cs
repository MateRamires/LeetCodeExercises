using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class TreeBasicExercises
{
    //Exercise 1 - Count Total Number of Nodes in a Tree
    public int countNumberOfNodes(TreeNode head) 
    {
        int count = treeTraversal(head, 0);
        return count;
    }

    private int treeTraversal(TreeNode node, int count) 
    {
        if (node == null) return 0;

        count += treeTraversal(node.left, count);
        count += treeTraversal(node.right, count);

        return count + 1;
    }

    public int countNumberOfNodesShorter(TreeNode head)
    {
        if (head == null) return 0;
        return 1 + countNumberOfNodesShorter(head.left) + countNumberOfNodesShorter(head.right);
    }
}
