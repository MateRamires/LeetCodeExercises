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

    //Ex 543: Diameter of Binary Tree
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int res = 0;
        DFSEx543(root, ref res);
        return res;
    }

    private int DFSEx543(TreeNode root, ref int res) 
    {
        if (root == null) return 0;
        int leftSide = DFSEx543(root.left, ref res);
        int rightSide = DFSEx543(root.right, ref res);
        res = Math.Max(res, leftSide + rightSide);
        return 1 + Math.Max(leftSide, rightSide);
    }

    //Ex 100: Same Tree
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;

        if (p != null && q != null && p.val == q.val) 
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        else
            return false;
    }

    //Ex 104
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}
