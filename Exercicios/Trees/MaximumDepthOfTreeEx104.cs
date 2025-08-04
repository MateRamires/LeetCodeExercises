using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class MaximumDepthOfTreeEx104
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }

    public int MaxDepthBFS(TreeNode root)
    {
        if (root == null) return 0;
        var queue = new Queue<TreeNode>();

        queue.Enqueue(root);
        int level = 0;
        while (queue.Count > 0) 
        {
            int currentQueueSize = queue.Count;
            for (int i = 0; i < currentQueueSize; i++)
            {
                var currentNode = queue.Dequeue();  

                if (currentNode.left != null) queue.Enqueue(currentNode.left);
                if (currentNode.right != null) queue.Enqueue(currentNode.right);
            }
            level++;
        }
        return level;
    }
}
