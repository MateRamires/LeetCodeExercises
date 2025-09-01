using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class RepeatedTreeExercises
{
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
}
