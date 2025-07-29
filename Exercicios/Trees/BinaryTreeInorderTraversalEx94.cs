using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class BinaryTreeInorderTraversalEx94
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> result = new List<int>();
        Traversal(root, result);
        return result;
    }

    private void Traversal(TreeNode node, List<int> result) 
    {
        if (node == null) return; //Na recursao, chegamos no base-case.

        Traversal(node.left, result);
        result.Add(node.val);
        Traversal(node.right, result);
    }
}
