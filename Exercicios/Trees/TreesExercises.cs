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
}
