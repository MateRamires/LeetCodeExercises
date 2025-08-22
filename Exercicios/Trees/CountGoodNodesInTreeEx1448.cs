using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class CountGoodNodesInTreeEx1448
{
    public int GoodNodes(TreeNode root)
    {
        return DFS(root, int.MinValue);
    }

    private int DFS(TreeNode node, int maxValue) 
    {
        if (node == null) return 0;

        int isGood = node.val >= maxValue ? 1 : 0;
        maxValue = Math.Max(maxValue, node.val);

        return isGood + DFS(node.left, maxValue) + DFS(node.right, maxValue);
    }
}
