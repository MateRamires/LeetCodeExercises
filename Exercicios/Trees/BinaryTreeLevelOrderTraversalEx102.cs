using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class BinaryTreeLevelOrderTraversalEx102
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var answer = new List<IList<int>>();

        if (root == null) return answer;

        var queue = new Queue<TreeNode>();

        queue.Enqueue(root);
        while (queue.Count > 0) 
        {
            int currentLevel = queue.Count;
            var currentLevelList = new List<int>(); 
            for (int i = 0; i < currentLevel; i++) 
            { 
                var currentNode = queue.Dequeue();

                currentLevelList.Add(currentNode.val);

                if (currentNode.left != null) queue.Enqueue(currentNode.left);
                if (currentNode.right != null) queue.Enqueue(currentNode.right);
            }
            answer.Add(currentLevelList);
        }

        return answer;   
    }
}
