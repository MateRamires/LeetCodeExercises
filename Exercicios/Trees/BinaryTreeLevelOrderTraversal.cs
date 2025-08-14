using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class BinaryTreeLevelOrderTraversal
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null) return new List<IList<int>>();

        var queue = new Queue<TreeNode>();
        var list = new List<IList<int>>();

        queue.Enqueue(root);
        while (queue.Count > 0) 
        {
            int currentLevelSize = queue.Count;
            var currentLevelList = new List<int>(); 
            for (int i = 0; i < currentLevelSize; i++)
            {
                var currentNode = queue.Dequeue();
                currentLevelList.Add(currentNode.val);

                if (currentNode.left != null)  queue.Enqueue(currentNode.left);
                if (currentNode.right != null)  queue.Enqueue(currentNode.right);
            }
            list.Add(currentLevelList);
        }

        return list;
    }
}
