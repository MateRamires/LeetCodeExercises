using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class BinaryTreePreorderEx144
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        PreOrderTraversalRecursion(root, result);
        return result;
    }

    private void PreOrderTraversalRecursion(TreeNode node, List<int> result) 
    {
        //Recursion base-case
        if (node == null) return;

        result.Add(node.val);
        PreOrderTraversalRecursion(node.left, result);
        PreOrderTraversalRecursion(node.right, result);
    }

    public IList<int> PreorderTraversalIteractive(TreeNode root) 
    {
        var result = new List<int>();
        if (root == null) return result;

        var stack = new Stack<TreeNode>();

        stack.Push(root);

        while (stack.Count > 0) 
        {
            var currentNode = stack.Pop();
            result.Add(currentNode.val);

            if(currentNode.right != null)
                stack.Push(currentNode.right);

            if (currentNode.left != null)
                stack.Push(currentNode.left);
        }

        return result;
    }
}
