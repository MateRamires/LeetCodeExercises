using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class BinaryTreeInorderEx94
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

    public IList<int> InorderTraversalIteractive(TreeNode root) 
    {
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        var current = root; 

        while (current != null || stack.Count > 0) 
        {
            while (current != null) 
            {
                stack.Push(current);
                current = current.left;
            }

            current = stack.Pop();
            result.Add(current.val);

            current = current.right;
        }

        return result;
    }
}
