using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class KthSmallestElementBSTEx230
{
    public int KthSmallest(TreeNode root, int k)
    {
        var list = new List<int>();
        DFS(root, list);
        return list[k - 1];
    }

    private void DFS(TreeNode node, List<int> list) 
    {
        if (node == null) return;
        DFS(node.left, list);
        list.Add(node.val);
        DFS(node.right, list);
    }
}
