using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class BinaryTreeRightSideViewEx199
{
    public IList<int> RightSideView(TreeNode root)
    {
        if(root == null) return new List<int>();

        var result = new List<int>();
        var queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        while (queue.Count > 0) 
        {
            TreeNode rightSide = null;
            int size = queue.Count;
            for (int i = 0; i < size; i++) 
            { 
                var currentNode = queue.Dequeue();

                if (i == 0) 
                    rightSide = currentNode;

                if (currentNode.right != null) queue.Enqueue(currentNode.right);
                if (currentNode.left != null) queue.Enqueue(currentNode.left);
            }

            result.Add(rightSide.val);
        }

        return result;
    }
}
