using Exercicios.LinkedList.Utility;
using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class ValidateBinarySearchTreeEx98
{
    public bool IsValidBST(TreeNode root)
    {
        return DFS(root, long.MinValue, long.MaxValue);
    }

    private bool DFS(TreeNode node, long minAllowed, long maxAllowed) 
    { 
        if (node == null) return true;

        if (!(minAllowed < node.val && node.val < maxAllowed))
            return false; 
        
        return DFS(node.left, minAllowed, node.val) && DFS(node.right, node.val, maxAllowed);
        
    }
}
