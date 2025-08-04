using Exercicios.Graphs;

namespace Exercicios.Trees;

public class BinaryTreeNaryPostorderEx590
{
    public class NodeEx590
    {
        public int val;
        public IList<NodeEx590> children;

        public NodeEx590() { }

        public NodeEx590(int _val)
        {
            val = _val;
        }

        public NodeEx590(int _val, IList<NodeEx590> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public IList<int> Postorder(NodeEx590 root)
    {
        var result = new List<int>();
        RecursiveTraversal(root, result);
        return result;
    }

    private void RecursiveTraversal(NodeEx590 node, List<int> result) 
    {
        if (node == null) return;

        foreach (var childrenNode in node.children) 
        {
            RecursiveTraversal(childrenNode, result);
        }
        result.Add(node.val);
    }
}
