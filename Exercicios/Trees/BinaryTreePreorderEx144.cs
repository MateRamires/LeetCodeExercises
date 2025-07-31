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
}
