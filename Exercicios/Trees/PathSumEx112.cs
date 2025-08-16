using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class PathSumEx112
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null) return false;

        targetSum -= root.val;

        if (HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum)) 
            return true;

        if (root.left == null && root.right == null && targetSum == 0) 
            return true;
        else
            return false;
        
    }
}
