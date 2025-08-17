using Exercicios.Graphs;
using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class RangeSumOfBst
{
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        if (root == null) return 0;

        var currentNode = root.val >= low && root.val <= high ? root.val : 0;
        return currentNode + RangeSumBST(root.left, low, high) + RangeSumBST(root.right, low, high);
    }
}
