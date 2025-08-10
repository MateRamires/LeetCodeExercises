using Exercicios.Trees.Helpers;

namespace Exercicios.Trees;

public class LowestCommonAncestorEx235
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null) return null;

        if (root.val > p.val && root.val > q.val) //Se o node atual for maior que AMBOS os nodes que estamos buscando, entao logicamente ele nao sera o lowest common ancestor, e sim algum node da sub arvore esquerda (sim, da esquerda, pois os 2 valores sao menores que o node atual, ou seja o lca esta a esquerda, onde todos os nodes sao menores que o atual)
            return LowestCommonAncestor(root.left, p, q);
        else if (root.val < p.val && root.val < q.val) //Se o node atual for menor que ambos, ai o node que estamos buscando esta na direita, e o node atual nao eh o LCA.
            return LowestCommonAncestor(root.right, p, q);
        else //Se o root for exatamente maior que (P ou Q) e menor que (P ou Q) entao ele eh o LCA. Existe o cenario de ele ser maior que (P ou Q) e ser igual a (P ou Q) ai tambem ele sera o LCA.
            return root;
    }
}
