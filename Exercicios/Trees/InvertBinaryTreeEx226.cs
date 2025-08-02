using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class InvertBinaryTreeEx226
{
    public TreeNode InvertTreeRecursive(TreeNode root)
    {
        if (root == null) return null;

        var aux = root.left;
        root.left = root.right;
        root.right = aux;

        InvertTreeRecursive(root.left);
        InvertTreeRecursive(root.right);

        return root;
    }

    public TreeNode InvertTreeIteractive(TreeNode root) 
    {
        if (root == null) return null;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0) 
        { 
            var currentNode = stack.Pop();

            var aux = currentNode.left;
            currentNode.left = currentNode.right;
            currentNode.right = aux;

            if (currentNode.right != null) stack.Push(currentNode.right);
            if (currentNode.left != null) stack.Push(currentNode.left);
        }
        return root;
    }
}
