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
        if (curr == null) //Toda recursao necessita de um exit, para que a recursao nao tenha a possibilidade de rodar para sempre, aqui a recursao saira caso o node atual seja nulo.
            return 0; //A altura eh 0, pois se o node atual eh nulo, entao nao ha altura para essa direcao, imaginemos que o node 1 tem um filho a esquerda (7) e nenhum filho a direita, nesse caso, a altura da esquerda sera 1, e a altura da direita sera ZERO, pois nao ha nodes. Porem, mesmo nao havendo nodes a direita, havera um momento em que buscaremos curr.right, e nesse momento, ele ira chamar essa funcao DFS, mas caira nesse IF, pois esse node da direita nao existe, ou seja, eh nulo.

        int left = Ex543DFS(curr.left, ref res); //Aqui estamos pegando a altura da sub-tree esquerda.
        int right = Ex543DFS(curr.right, ref res); //E aqui a altura da sub-tree direita.
        res = Math.Max(res, left + right); //left + right serao as ALTURAS, e res eh o diametro, entao aqui, nos vamos verificar se o res atual eh maior que a soma das alturas esquerda e direita, se for, ai esse diametro calculado eh maior que o diametro que ja estava na variavel res.
        return 1 + Math.Max(left, right); //Essa funcao deve retornar a maior altura entre esquerda e direita, pois isso sera usado pelos nodes acima dele + 1. Mais 1, pois temos que considerar que vamos subir a casa do node, e essa subida adiciona + 1 a altura.
    }

    //Ex 100
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) //Se os dois nodes que estamos analisando de ambas as arvores forem null, entao eles sao iguais
            return true;
        if (p != null && q != null && p.val == q.val)
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right); //Aqui que temos o passo da recursao, nos vamos verificar o lado esquerdo e direito de cada node, e ir descendo, se tiver UM par de node que for diferente em algum momento da recursao, ele retornara false, e como usamos o operador (&&), isso significa que se tiver um false apenas, no fim das contas, quando voltamos para a chamada inicial, o resultado sera false, mesmo que seja apenas UM node diferente, como se quebrasse o "elo" e assim, por usar (&&) entendessemos que esse false fara todos os returns de todas as funcoes aninhadas retornarem false tambem, ate chegar na primeira chamada que tambem retornara false.
        else //Esse else cobre todos os outros casos, por exemplo, ele cobre se um dos dois nodes for nulo, e o outro nao e cobre se o valor de um node for diferente do outro.
            return false;
    }

    //Ex 104 (Esse exercicio tem tres solucoes possiveis, vou fazer as tres.)
    public int MaxDepthDfs(TreeNode root)
    {
        if (root == null) //Todos os exercicios que utilizam DFS com recursao, TEM que ter um "Base case", ele eh usado para interromper as chamadas recursivas quando chegam em um determinado ponto, sem ele, ou dara um null exception ou a recursao rodara ate dar um stack overflow. Nesse caso, ele sera acionado quando chegarmos em um node que nao tem filhos, quando isso acontecer, essa funcao sera chamada passando os filhos, que nao existem, logo, sao nulos e cairam nesse if, retornando 0 e terminando a recursao.
            return 0;

        return 1 + Math.Max(MaxDepthDfs(root.left), MaxDepthDfs(root.right)); //Aqui a logica sera a seguinte, todas as vezes que essa funcao for chamada, e o node analisado nao for null ele retornara 1, e chamara os nodes filhos, os nodes filhos vao ser chamados ate acabar, retornando + 1 cada um, quando chegarmos ao fim da recursao ele vai voltando (1 + 1 + 1) e por fim teremos a soma da altura maxima entre esquerda e direita + 1 (que eh o 1 do node head), e nos dara o resultado certo. 
    }
    public int MaxDepthBfs(TreeNode root) //Em BFS nos vamos checando a arvore NIVEL a NIVEL, ou seja, vamos checando ela de forma horizontal, sendo assim, para resolver esse problema, basta checarmos qual o ultimo nivel, o ultimo nivel sera exatamente o tamanho da altura que precisamos
    {
        Queue<TreeNode> q = new Queue<TreeNode>(); //Primeiro criamos nossa queue, que eh o principio do BFS. Ela eh do tipo TreeNode logicamente.
        if (root != null) //Checamos o edge-case, que eh o caso de o primeiro node (head) ser nulo. Se NAO for nulo, ai colocamos esse node como primeiro elemento da nossa queue.
            q.Enqueue(root);

        int level = 0; //Essa sera a variavel que ira "guardar" qual o nivel mais baixo da nossa arvore, e sera o nosso resultado.
        while (q.Count > 0) //No processamento abaixo, nos vamos colocar e tirar nodes ate um determinado momento onde todos os nodes vao acabar, e ai essa condicao deixara de ser verdadeira.
        {
            int size = q.Count; //Tamanho da nossa queue. De inicio ela sempre sera 1, pois so temos apenas um root "head", mas depois ela aumentara de tamanho dependendo da quantidade de nodes em cada nivel.
            for (int i = 0; i < size; i++) //Iremos rodar esse for para TODOS os elementos da nossa queue, pois vamos ter que adicionar a queue todos os filhos de todos os elementos atuais.
            { 
                TreeNode node = q.Dequeue(); //TIRAMOS o elemento da queue, e ao mesmo tempo colocamos esse elemento em uma variavel, pois vamos utilizar esse elemento para pegar os filhos dele.
                if (node.left != null) //Nos dois ifs abaixo checamos se o elemento atual tem filhos a esquerda e a direita, e adiciona-os caso existam.
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
            level++; //Depois de remover todos os elementos do nivel atual, e colocar todos os elementos do proximo nivel da queue, nos aumentamos a variavel nivel, pois a partir de agora vamos analisar um nivel abaixo.
        }
        return level; //No fim, chegara um momento em que todos os nodes de um determinado nivel nao terao nenhum filho, quando isso acontecer, a queue nao tera mais nenhum node, e subsequentemente saira do while, sendo assim, a variavel nivel logicamente guardara o valor do ultimo nivel, que eh a nossa resposta, pois temos que achar a distancia mais profunda possivel, ou no caso, o ultimo nivel possivel.
    }
    public int MaxDepthDfsStack(TreeNode root)
    {
        Stack<Tuple<TreeNode, int>> stack = new Stack<Tuple<TreeNode, int>>(); //Criamos a stack que recebera um tuple (par de dados) de TreeNode e um inteiro, onde treenode, sera o node e o int sera o nivel onde esta esse node.
        stack.Push(new Tuple<TreeNode, int>(root, 1)); //Primeiro colocamos o primeiro node e o seu nivel, que sera 1, pois o node head sempre estara no primeiro nivel
        int res = 0;

        while (stack.Count > 0) //Vamos rodar esse while ate nossa stack nao ter mais nenhum node.
        {
            Tuple<TreeNode, int> currentNode = stack.Pop(); //Primeiro tiramos o node da stack e ao mesmo tempo colocamos esse node a uma variavel, pois vamos utilizar esse node para pegar os filhos dele.
            TreeNode node = currentNode.Item1; //Item1 do tuple eh o proprio node, pois a variavel "currentNode" nao eh um node, e sim um tuple que contem o node e o nivel.
            int depth = currentNode.Item2; //Item2 eh o nivel do node, que vai incrementando a cada iteracao.

            if (node != null) //Se o node nao for null, sendo que ele pode ser, ja que o node atual pode NAO ter filhos.
            {
                res = Math.Max(res, depth); //Aqui verificamos se o nivel que estamos analisando eh maior que o nivel que ja havia sido analisado anteriormente e colocamos o maior na variavel res.
                stack.Push(new Tuple<TreeNode, int>(node.left, depth + 1)); //Por fim, para o while continuar ate acabar todos os nodes, vamos colocando sempre os filhos do node atual que esta sendo analisado, tanto o filho da esquerda quanto da direita, e como eles sao FILHOS, nos tambem colocamos nivel + 1, pois se sao filhos, entao eles estao em um nivel abaixo do node atual, subindo + 1 nivel.
                stack.Push(new Tuple<TreeNode, int>(node.right, depth + 1));
            }
        }
        return res; 
    }

    
}
