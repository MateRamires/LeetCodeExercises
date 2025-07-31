using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class BinaryTreePostorderEx145
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        RecursiveTraversal(root, result);
        return result;
    }

    private void RecursiveTraversal(TreeNode node, List<int> result) 
    {
        if (node == null) return;

        RecursiveTraversal(node.left, result);
        RecursiveTraversal(node.right, result);
        result.Add(node.val);
    }
}
