namespace Exercicios.Trees.Helpers;

public class TreeNodeHelpers
{
    public static TreeNode Build(int?[] data)
    {
        if (data == null || data.Length == 0 || data[0] == null)
            return null;

        var root = new TreeNode(data[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int i = 1;                         
        while (i < data.Length && queue.Count > 0)
        {
            var cur = queue.Dequeue();

            // Filho esquerdo
            if (i < data.Length && data[i] != null)
            {
                cur.left = new TreeNode(data[i].Value);
                queue.Enqueue(cur.left);
            }
            i++;

            // Filho direito
            if (i < data.Length && data[i] != null)
            {
                cur.right = new TreeNode(data[i].Value);
                queue.Enqueue(cur.right);
            }
            i++;
        }
        return root;
    }

    /*--------------------------------------------------------------
     * Serializa a árvore de volta para o mesmo formato do LeetCode
     * (útil para verificar round‑trip).
     *------------------------------------------------------------*/
    public static int?[] ToArray(TreeNode root)
    {
        if (root == null) return Array.Empty<int?>();

        var list = new List<int?>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            var node = q.Dequeue();
            if (node == null)
            {
                list.Add(null);
                continue;
            }

            list.Add(node.val);
            q.Enqueue(node.left);
            q.Enqueue(node.right);
        }

        // Remove nulls finais irrelevantes
        for (int k = list.Count - 1; k >= 0 && list[k] == null; k--)
            list.RemoveAt(k);

        return list.ToArray();
    }

    /*--------------------------------------------------------------
     * Impressão simples em BFS: "1,null,2,3".
     *------------------------------------------------------------*/
    public static void Print(TreeNode root)
    {
        Console.WriteLine(string.Join(",", ToArray(root)
                                            .Select(x => x?.ToString() ?? "null")));
    }
}
