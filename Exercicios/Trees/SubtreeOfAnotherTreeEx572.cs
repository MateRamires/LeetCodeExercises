using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class SubtreeOfAnotherTreeEx572
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (subRoot == null) return true;

        if (root == null) return false;

        if (SameTree(root, subRoot))
        {
            return true;
        }
        else 
        { 
            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }
    }

    private bool SameTree(TreeNode root, TreeNode subRoot) //Recursao que verifica se a arvore eh igual a partir de qualquer node.
    {
        if (root == null && subRoot == null)
            return true;

        if (root != null && subRoot != null && root.val == subRoot.val)
            return SameTree(root.left, subRoot.left) && SameTree(root.right, subRoot.right);
        else 
            return false;
        
    }
}
