using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class DiameterOfBinaryTree
{
    public int DiameterOfTree(TreeNode root)
    {
        int res = 0;
        DFS(root, ref res);
        return res;
    }

    private int DFS(TreeNode root, ref int res) 
    {
        if (root == null) return 0;
        int leftSide = DFS(root.left, ref res);
        int rightSide = DFS(root.right, ref res);
        res = Math.Max(res, leftSide + rightSide);
        return 1 + Math.Max(leftSide, rightSide);
    }
}
