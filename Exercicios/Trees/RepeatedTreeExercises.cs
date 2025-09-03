using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class RepeatedTreeExercises
{
    //Ex: Invert Tree
    public TreeNode InvertTree(TreeNode root)
    {
        DFS(root);
        return root;
    }

    private void DFS(TreeNode root) 
    {
        if (root == null) return;

        TreeNode tempNode = root.left;
        root.left = root.right;
        root.right = tempNode;

        DFS(root.left);
        DFS(root.right);
    }

    //Ex 104: Max Depth of Tree
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}
