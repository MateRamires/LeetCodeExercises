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

    //Exercise 6 - Maximum Value in a Tree
    public int maximumValueInTree(TreeNode root) 
    {
        if (root == null) return int.MinValue;

        return Math.Max(root.val, Math.Max(maximumValueInTree(root.left), maximumValueInTree(root.right))); 
    }

    public int maximumValueInTree2(TreeNode root)
    {
        if (root == null) return int.MinValue;

        int leftSideHighest = maximumValueInTree2(root.left);
        int rightSideHighest = maximumValueInTree2(root.right);

        return Math.Max(root.val, Math.Max(leftSideHighest, rightSideHighest));
    }

    //Exercise 7 - Minimum Value in a Tree
    public int MinimumValueInTree(TreeNode root) 
    {
        if (root == null) return int.MaxValue;

        int lowestLeftSide = MinimumValueInTree(root.left);
        int lowestRightSide = MinimumValueInTree(root.right);

        return Math.Min(root.val, Math.Min(lowestLeftSide, lowestRightSide));   
    }

    //Exercise 8 - Count number of pair nodes
}
