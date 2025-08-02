using Exercicios.Trees.Helpers;
using System.ComponentModel.Design.Serialization;

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

    //Exercise 2 - Max Tree Height
    public int maximumTreeHeight(TreeNode node) 
    {
        if (node == null) return 0;
        int left = maximumTreeHeight(node.left);
        int right = maximumTreeHeight(node.right);
        return 1 + Math.Max(left, right);
    }

    //Exercise 3 - Check if values exists
    public bool checkValueExists(TreeNode root, int value) 
    {
        if (root == null) return false;
        if (root.val == value) return true;

        checkValueExists(root.left, value);
        checkValueExists(root.right, value);

        return checkValueExists(root.left, value) || checkValueExists(root.right, value);
    }

    //Exercise 4 - Sum all values in a tree
    public int sumTreeValues(TreeNode root) 
    {
        if (root == null) return 0;

        int leftSide = sumTreeValues(root.left);
        int rightSide = sumTreeValues(root.right);

        return root.val + leftSide + rightSide;
    }

    //Exercise 5 - Number of leaves (nodes without children)
    public int nodesWithoutChildren(TreeNode root) 
    {
        if (root == null) return 0;

        int leftSide = nodesWithoutChildren(root.left);
        int rightSide = nodesWithoutChildren(root.right);

        if (root.left == null && root.right == null)
             return 1 + leftSide + rightSide;
        else
            return leftSide + rightSide;

    }
}
