namespace Exercicios.Trees;

public class TreesExercises
{
    //Ex 226
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null; //Se a cabeca da arvore for nula, entao nao ha o que inverter.

        TreeNode temp = root.left; //Coloca o node filho da esquerda numa variavel temp, pois vamos alterar o node esquerdo.
        root.left = root.right; //Colocamos o node direito no lugar do esquerdo
        root.right = temp; //Usamos nossa variavel temp e colocamos o node esquerdo (temp) no lugar do direito

        InvertTree(root.left); //Agora chamamos essa mesma funcao, mas passamos como parametro o node esquerdo, pois vamos alterar os filhos dele agora, e assim por diante
        InvertTree(root.right); //Exatamente a mesma coisa para o node direito, vamos passar o node direito para alterar os filhos dele, que por si so, podem ter filhos tambem e vamos invertendo tudo atraves dessa recursao.

        return root; //Retornamos a cabeca da arvore por fim.
    }

    //Ex 543
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int res = 0; //Vamos usar como parametro do nosso dfs a palavra-chave ref, que significa que essa variavel sera alterada mesmo estando no escopo da funcao.
        Ex543DFS(root, ref res); // Esse DFS nao vai retornar o diametro, ele vai retornar a altura de um dos lados apenas.
        return res;
    }

    private int Ex543DFS(TreeNode curr, ref int res) 
    {
        if (curr == null) 
            return 0;

        int left = Ex543DFS(curr.left, ref res); //Aqui estamos pegando a altura da sub-tree esquerda.
        int right = Ex543DFS(curr.right, ref res); //E aqui a altura da sub-tree direita.
        res = Math.Max(res, left + right); //left + right serao as ALTURAS, e res eh o diametro, entao aqui, nos vamos verificar se o res atual eh maior que a soma das alturas esquerda e direita, se for, ai esse diametro calculado eh maior que o diametro que ja estava na variavel res.
        return 1 + Math.Max(left, right); //Essa funcao deve retornar a maior altura entre esquerda e direita, pois isso sera usado pelos nodes acima dele + 1. Mais 1, pois temos que considerar que vamos subir a casa do node, e essa subida adiciona + 1 a altura.
    }
}
