using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class LeafSimilarTreesEx872
{
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        List<int> leaf1 = new List<int>();
        List<int> leaf2 = new List<int>();

        DFS(root1, leaf1);
        DFS(root2, leaf2);

        return leaf1.SequenceEqual(leaf2);
    }

    public void DFS(TreeNode root, List<int> list) 
    { 
        if (root == null) return;

        if (root.left == null && root.right == null) 
        { 
            list.Add(root.val);
            return;
        }

        DFS(root.left, list);
        DFS(root.right, list);
    }
}
