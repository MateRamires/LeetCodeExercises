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

    //Ex 110
    public bool IsBalanced(TreeNode root) //Nos somos obrigados a criar uma nova funcao, pois a funcao original pedida pelo leetcode so devolve um bool, e nos queremos que a funcao recursiva devolva um par de valores, por isso criamos uma nova funcao auxiliar para esse exercicio.
    {
        return DfsEx110(root)[0] == 1; 
    }
    private int[] DfsEx110(TreeNode root) //Essa funcao vai retornar um array, mas que na verdade serao apenas 2 elementos, que sera um "booleano" e a altura da arvore. O booleano (que sera inteiro, pois podemos falar que eh 1 ou 0) sera usado para indicar se durante o processamento JA HOUVE um situacao onde a altura de um lado era maior que do outro, sendo assim, esse false ira "matar" toda a funcao e o resultado final sera false por causa disso. 
    {
        if (root == null) //Esse eh o base case, o cenario onde a recursao vai parar para ela nao rodar infinitamente
            return new int[] { 1, 0 }; //Uma arvore vazia sempre sera balanceada, portanto o primeiro parametro eh 1 (true) e o segundo parametro, a altura, sera 0, pois um node vazio nao tem altura.

        int[] left = DfsEx110(root.left); //Nos queremos primeiramente se subtrees direita e esquerda do node atual sao balanceadas, por isso recursivamente chamamos elas primeiro antes de checar o node atual, pois sempre temos que verificar os filhos primeiro, depois o pai, e vamos entrando na recursao ATE chegar no base case (nao tem mais filhos, sao null), ai vai voltando de pai em pai.
        int[] right = DfsEx110(root.right);

        bool balanced = (left[0] == 1 && right[0] == 1) && //Agora queremos saber se o node ATUAL eh balanceado. Para isso verificaremos primeiramente se em algum momento dos filhos do node atual, alguma subtree nao era balanceada, pois se for o caso, ai a resposta final tera que se false, se todos os nodes forem balanceados MENOS UM, ja eh tudo false.
                        (Math.Abs(left[1] - right[1]) <= 1); //Nos tambem queremos saber o tamanho absoluto entre os nodes esquerdo e direito do node atual (Math.Abs eh usado para nao retornar negativo). Nos pegamos entao o segundo valor de left e right, o segundo valor pois eh ele que guarda a ALTURA dos nodes, ai fazemos um menos o outro, deixamos ele positivo e checamos se a diferenca entre os 2 eh maior que 1, se for menor ou igual, ai tudo certo.
        //Ou seja para essa variavel balanced (que indica se o node atual eh balanceado) ser true, ambas as condicoes devem ser verdadeiras, nao pode ter tido um node desbalanceado mais abaixo da arvore, e a subtracao da arvore esquerda com a direita deve ser menor ou igual a 1, se ambos forem verdade, ai o node atual eh balanceado, e essa variavel sera true.

        int height = 1 + Math.Max(left[1], right[1]); //Antes de retornarmos o nosso array de pares do node atual, precisamos calcular a altura desse node + os nodes passados. A altura sera 1 (altura do node atual) + o MAIOR valor entre os seus dois filhos esquerdo e direito, pois so levaremos em consideracao o maior aqui, ja que queremos calcular a altura, e o maior eh o que importa para saber a altura total. 

        return new int[] { balanced ? 1 : 0, height }; //Por fim retornamos o array com os pares de valores referentes ao node atual. 1 ou 0 como primeira casa, sendo 1 caso balanced seja true e 0 caso balanced seja false, e a altura como segundo parametro, que calculamos na linha de cima.
    }

    //Ex 572
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (subRoot == null)
            return true; //Se a subtree for nula, entao ela SEMPRE sera uma subtree da tree principal, isso porque, a tree principal sempre tera pelo menos um node null, mesmo que seja a tree inteira sendo null ou um node filho de outro node ser null.

        if (root == null)
            return false; //Agora caso contrario, ai retorna false. Isso porque, se a tree principal for null e a subtree for qualquer outra coisa, entao a subtree NAO tem como estar presente na tree principal, ja que ela eh nula. (Obs: se subtree e tree forem ambas nulas, ai as duas sao iguais, POREM, a ordem como inserimos os ifs, faz com que esse cenario nunca aconteca nessa funcao, pois se a subtree for nula, ja automaticamente retornamos true por causa do if acima, evitando que colocassemos nesse if algo como (... && subRoot != null) pois seria redundante. )

        if (SameTree(root, subRoot)) //Agora aqui que chamamos a nossa funcao auxiliar, ela vai verificar se a tree principal contem a nossa subtree, de inicio, ele vai verificar se a subtree esta presente na tree a partir do node inicial. Isso vai mudar quando comecarmos com a recursao nas linhas abaixo.
            return true;

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot); //Aqui comecamos a recursao, agora nos vamos checar se a nossa subtree esta presente nos filhos do node atual da tree principal, e essa recursao ira continuar ATE que encontremos a subtree OU ate que caia no base case (root == null), se cair no base case em ambos os lados esquerdo e direito, significa que nao foi encontrado a subtree na tree principal, portanto, eh falso, a subtree nao esta presente na tree principal
    }
    public bool SameTree(TreeNode root, TreeNode subRoot) //Essa funcao auxiliar eh exatamente igual a outro exercicio que fizemos acima, isSameTree.
    {
        if (root == null && subRoot == null)
            return true; //Esse eh o base-case, vamos verificar se as arvores sao iguais ate que ambas vao acabar, chegando no filho do ultimo node, que eh null, nesse caso, retornara true e finalizara a recursao.

        if (root != null && subRoot != null && root.val == subRoot.val) //Nesse if que vamos comecar a recursao, verificaremos se os 2 nodes sao diferentes de null, pois se um for null e o outro nao, ai as arvores nao sao iguais, e trataremos disso abaixo, alem disso, verificamos se os valores dos 2 nodes sao iguais, pois eles tem que ser iguais para continuar, se nao forem iguais, ai as arvores nao sao iguais e trataremos disso abaixo
            return SameTree(root.left, subRoot.left) && //Aqui chamamos a mesma funcao, dessa vez passando os 2 filhos do node atual, e assim por diante.
                   SameTree(root.right, subRoot.right);

        return false; //Por fim, se nenhum dos ifs acima for verdadeiro, isso quer dizer que os nodes nao sao iguais. Ou um node eh nulo e o outro nao, ou o valor de um node eh diferente do outro, nesse caso, retornamos false, pois as arvores nao sao iguais.
    }

    //Ex 235
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeNode cur = root;

        while (cur != null) //Nunca vai ser nulo, mas vamos executar essa funcao "para sempre" pois na verdade sabemos que iremos achar o valor em um determinado momento, entao nao rodara para sempre de fato.
        {
            if (p.val > cur.val && q.val > cur.val) //Se o valor de p for maior que o node atual e o valor de q TAMBEM for maior que o node atual, entao temos que buscar o LCA na direita, pois na direita eh onde apenas existem numeros maiores que o node atual
                cur = cur.right; //Agora o node atual foi para direita, onde continuaremos a busca pelo LCA.
            else if (p.val < cur.val && q.val < cur.val) //Aqui eh o caso contrario, caso AMBOS p e q tenham valores menores que o node atual, isso quer dizer que o LCA que estamos buscando esta inevitavelmente a esquerda, pois na esquerda que tem numeros menores que o node atual.
                cur = cur.left; //Movemos o node atual para esquerda.
            else
                return cur; //O else aqui sera o caso onde P e Q, um ou o outro sera maior e outro sera menor que o atual, ou seja, o node atual eh exatamente no "meio" onde um dos valores eh maior que ele e o outro valor eh menor, se isso acontecer, sabemos com certeza que esse valor EH o LCA que estamos buscando, ele eh o "node chefe" em comum mais proximo de p e q
        }
        return null; //Isso nem era necessario, pos eh garantido que dentro do while sera acionado o return cur.
    }

    //Ex 102
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        List<IList<int>> res = new List<IList<int>>();
        if (root == null) return res; //If verificando o edge-case de a arvore ser nula, nesse caso retornamos a lista vazia.

        Queue <TreeNode> q = new Queue<TreeNode>(); //Criamos nossa queue que recebe apenas TreeNode's.
        q.Enqueue(root); //Primeiramente, ja adicionamos o primeiro node root.

        while (q.Count > 0) //Esse while vai rodar enquanto houver elementos (nodes) dentro da queue.
        { 
            List<int> currentLevel = new List<int> (); //Criamos uma lista que armazenara o nivel atual, pois iremos adicionar os nodes do nivel atual posteriormente no codigo.

            for (int i = q.Count; i > 0; i--) //Esse for ira iterar sob toda nossa queue.
            {
                TreeNode currentNode = q.Dequeue(); //Primeiramente retiramos o node que entrou primeiro (first in - first out) e a ordem dos nodes dentro da queue sempre sera a ordem esquerda para direita, por causa da forma que vamos adiciona os filhos desses nodes mais abaixo.
                if (currentNode != null) //Verificamos se o node de fato existe, pois eh possivel que esse node seja null, pois o node-pai pode nao ter filhos, ou pode nao ter filhos em um de seus 2 lados.
                { 
                    currentLevel.Add(currentNode.val); //Adicionamos o node atual na nossa lista do nivel atual, pois teremos que adicionar essa lista a nossa lista principal (res) ao fim desse for, montando assim, a lista com todos os nodes do nivel atual.
                    q.Enqueue(currentNode.left); //Adicionamos a queue os nodes filhos do node atual, comecando com o node da esquerda, pois temos que seguir essa ordem.
                    q.Enqueue(currentNode.right); //Faremos o mesmo com o node filho direito.
                }
            }
            if (currentLevel.Count > 0) //Como estamos fazendo i = q.count, mesmo que adicionemos valor a q, o i nao ira mudar de valor, sendo assim, ele ira sair do for quando passar por todos os elementos de q original (antes de adicionar os novos elementos filhos). Sendo assim, no fim iremos adicionar a lista currentLevel, que contem todos os nodes do determinado nivel que estamos a lista principal res, que eh uma lista e que no fim ira conter todos os niveis em listas menores.
                res.Add(currentLevel);
        }
        return res; //Quando o while acabar, significa que ja passamos por TODOS os nodes, ai podemos retornar a variavel res.
    }

    //Ex 199
    public IList<int> RightSideView(TreeNode root)
    {
        List<int> res = new List<int>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root); //Ate aqui fazemos o padrao, criamos a lista que contera a resposta final, criamos a queue e colocamos nessa queue o primeiro elemento da arvore.

        while (q.Count > 0) //Como padrao do BFS vamos rodar esse while ate todos os nodes serem visitados, ou seja, ate nao haverem mais nodes dentro da queue.
        {
            TreeNode rightMostNode = null; //Aqui iremos criar a variavel importante para esse exercicio, mais a frente ela sera explicada, mas ela guardara o valor mais a direita de cada nivel da arvore, e esse valor mais a direita a cada nivel, formara a resposta final do exercicio.
            int qLen = q.Count; //Variavel para guardar a quantidade de elementos da queue antes de adicionarmos novos elementos.

            for (int i = 0; i < qLen; i++) //Vamos iterar sob toda a queue original, mesmo que elementos novos sejam adicionados.
            {
                TreeNode currentNode = q.Dequeue(); //Pegaremos o node atual e o tiraremos da queue.
                if (currentNode != null) 
                { 
                    rightMostNode = currentNode; //A logica sera a seguinte, precisamos pegar o elemento mais a direita possivel a cada nivel, como esse elemento a direita SEMPRE sera o ultimo elemento da queue original (que estamos iterando) entao sempre salvamos o elemento atual a essa variavel. Na proxima iteracao, se houver, esse novo elemento da proxima iteracao sera salvo a variavel, no fim das contas, sempre o ultimo node sera o que sera salvo a variavel rightMost, pois a ultima iteracao SERA o elemento mais a direita.
                    q.Enqueue(currentNode.left); //Colocamos os filhos do elemento atual na queue para a analise do proximo nivel.
                    q.Enqueue(currentNode.right);
                }
            }
            if (rightMostNode != null) //Por fim, apos toda a iteracao do for, nos temos certeza que o ULTIMO elemento que passou pelo for, sera sempre o elemento mais a direita, entao basta adicionarmos esse elemento a resposa final.
                res.Add(rightMostNode.val);
        }
        return res; //Apos todo o while, com a logica acima, a resposta tera o ultimo elemento a direita de cada nivel.
    }

    //Ex 1448 (Esse exercicio tem duas solucoes possiveis, vou fazer as duas, BFS e DFS.)
    public int GoodNodesDfs(TreeNode root)
    {
        return DfsEx1448(root, root.val); //Criaremos uma funcao DFS, pois precisamos passar 2 parametros para essa funcao, o node e o valor do node atual.
    }
    private int DfsEx1448(TreeNode node, int maxVal) 
    {
        if (node == null) //Esse eh o base-case, para a recursao nao rodar infinitamente, se o node for null, entao logicamente ele nao sera um good-node, e retornara 0, pra nao somar na nossa variavel que soma os good-nodes.
            return 0;

        int res = (node.val >= maxVal) ? 1 : 0; //Essa sera a linha que ira checar se o node atual eh um good-node ou nao, caso o valor desse node seja maior ou igual ao MAIOR node ja visto ate agora, entao eh um good-node.
        maxVal = (Math.Max(maxVal, node.val)); //Nos sempre precisaremos estar atualizando a variavel maxVal, pois ela que vai guardar qual foi o maior node ja encontrado ate o momento, e precisamos saber qual o maior node ja encontrado ate o momento, para compara-lo com os proximos nodes e descobrir se eles sao good-nodes ou nao.
        res += DfsEx1448(node.left, maxVal); //Aqui comeca a recursao, iremos passar os nodes filhos da esquerda E tambem o maxVal, pois sempre precisamos passar o maior node ja encontrado ate agora, para saber se os filhos serao ou nao good-nodes com base no maior node ja encontrado.
        res += DfsEx1448(node.right, maxVal); //Mesma coisa aqui mas para os nodes da direita.
        return res; //Por fim retornamos o res, que sera ou 1 ou 0, e na nossa recursao usamos += ou seja, vai somando de baixo para cima quantos good nodes temos, para que quando chegue na ultima recursao, ele retorne o valor total de good nodes aqui.
    }
    public int GoodNodesBfs(TreeNode root)
    {
        int res = 0;
        Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)> (); //Criaremos uma queue, que recebera o node e o valor maximo encontrado ate determinado momento.
        q.Enqueue((root, int.MinValue)); //Colocaremos o node, e colocaremos o menor valor de int possivel, pois isso sera necessario para a logica que criamos a mais a frente.

        while (q.Count > 0) //Codigo ira rodar enquanto queue tiver nodes.
        {
            var (node, maxval) = q.Dequeue(); //Tiraremos da queue o node e o valor maximo
            if (node.val >= maxval) //Iremos comparar o valor atual com o maxval, que eh o valor maximo encontrado ate o momento.
                res++; //Se o valor atual for maior ou igual ao maxval, ai eh um good node, incrementamos nossa variavel res.
            if (node.left != null) //Primeiro checamos se o node a esquerda eh null, se nao, nao podemos o adicionar.
                q.Enqueue((node.left, Math.Max(maxval, node.val))); //Colocamos na queue o node atual, e verificamos se o valor do node atual eh maior que o maior valor encontrado ate agora, e qual dos dois for maior, nos enviaremos para a proxima iteracao do while, pois iremos colocar na queue o node e o valor maximo encontrado ate agora
            if (node.right != null) //Mesma coisa do if acima.
                q.Enqueue((node.right, Math.Max(maxval, node.val)));
        }
        return res;
    }

    //Ex 98
    public bool IsValidBST(TreeNode root)
    {
        return valid(root, long.MinValue, long.MaxValue); //Nos comecamos a funcao de recursao passando o node root, e o root pode ser literalmente qualquer numero entre negativo infinito e positivo infinito, pois ele nao tem parentes, ou seja, ele nao precisa seguir uma "regra" de ser maior ou menor que outro node.
    }
    public bool valid(TreeNode node, long left, long right) 
    {
        if (node == null) //Base case, se chegarmos aqui, eh pq todos os nodes foram analisados e foram validados ate chegar no null, que nao muda se a arvore eh valida ou nao, portanto, se chegou ate aqui eh pq a arvore (ou pelo menos esse galho especifico foi valido)
            return true;

        if (!(left < node.val && node.val < right)) //Nos temos que verificar se o valor do node atual eh maior que a condicao esquerda e menor que a condicao direita, se isso NAO FOR O CASO (!) entao a arvore nao eh uma binary search tree valida.
            return false;

        return valid(node.left, left, node.val) && valid(node.right, node.val, right); //Agora nossa recursao, nos precisamos garantir que ambas as subtres esquerda e direita tambem sao validas as condicoes. Para a subtree esquerda, a condicao esquerda pode continuar a mesma que estava antes, a unica condicao que altera quando vamos para a subtree esquerda, eh ver o node eh MENOR que o node parente dele. Para a subtree direita a logica sera, o node atual deve ser maior que o parente.
    }

    //Ex 230
    public int KthSmallest(TreeNode root, int k)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = root;

        while (stack.Count > 0 || current != null)  //O while rodara enquanto o stack tiver elementos e enquanto current tiver algo, pois eh possivel que o stack nao tenha nada, mas o elemento atual seja um node, ai o while tem  que continuar rodando tbm.
        {
            while (current != null) //Esse while aqui serve para ir sempre para os nodes da esquerda, pois temos que adicionar os nodes a esquerda ate nao houver mais, ja que os da esquerda sempre sao os menores.
            { 
                stack.Push(current); 
                current = current.left; //Sempre vamos ir a esquerda dentro desse while, ate que nao haja mais nenhum node a esquerda no galho que estamos analisando.
            }
            current = stack.Pop(); //Quando chegar o momento onde nao ha mais nodes a esquerda do node que estamos analisando, ai tiramos o ultimo node adicionado
            
            k--; //Essa linha tem o seguinte proposito, nos temos que achar o elemento k mais baixo, entao a cada elemento que tiramos da stack, nos vamos diminuindo essa variavel k ate que ela seja 0, quando ela for 0, entao esse elemento atual eh exatamente o qual nos precisamos retornar.
            if (k == 0)
                return current.val;

            current = current.right; //Caso k ainda nao seja 0, como nos ja exautamos os nodes a esquerda do node atual, e sabemos que nao ha nada, entao agora vamos a direita do node atual.
        }
        return -1; //Caso nao exista o k na arvore vai sair do while sem dar o return current.val, ai retornamos -1 pois o k'th nao existe na arvore.
    }

    //Ex 105
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length == 0 || inorder.Length == 0) //Esse sera o base-case da recursao.
            return null;

        TreeNode root = new TreeNode(preorder[0]); //O primeiro elemento de preorder SEMPRE sera o root, pois essa eh a regra da travessia preorder, onde o primeiro elemento sempre sera o root.
        int mid = Array.IndexOf(inorder, preorder[0]); //Aqui estamos encontrando qual a posicao do root node do array inorder, isso vai servir tanto para o primeiro caso (root principal), quanto para subtrees, pois toda subtree, tambem tem o "root-node" dela. Quando descobrirmos qual a posicao do root-node no array inorder, sabemos que todos os elementos a esquerda desse root node serao da subtree esquerda e todos os elementos a direita serao da subtree direita.
        root.left = BuildTree(preorder.Skip(1).Take(mid).ToArray(), inorder.Take(mid).ToArray()); //Vamos pular o primeiro elemento (skip(1)) pois o primeiro elemento eh o root e vamos pegar TODOS os elementos antes do meio, pois todos os elementos antes do meio sao exatamente os elementos que vao ficar a esquerda. O take(mid) faz isso, pois ele pega a mesma quantidade de elementos que foi identificado no array inorder como antes do node-root.
        root.right = BuildTree(preorder.Skip(mid + 1).ToArray(), inorder.Skip(mid + 1).ToArray()); //do array preorder nos iremos pular o root (+ 1) + os elementos esquerdos (mid), apos isso iremos comecar exatamente no primeiro elemento da subtree direita e a mesma coisa pro inorder, nos pulamos ate o root com o (mid) depois o proprio root com o (+ 1) e caimos exatamente no primeiro elemento da subtree direita.
        return root; //No fim nos retornamos o proprio node, pois vamos montar a arvore, entao temos que retornar o node para ir montando a arvore aos poucos (left e right), no caso essa variavel root sempre vai ser preorder[0] so que a cada recursao, nosso preorder vai diminuindo de tamanho, pois vamos alterando (diminuindo) ele a cada recursao, skipando elementos ate que nao sobre nada, e caia exatamente no nosso base case preorder.length == 0 ou inorder.length == 0, e ai acaba a recursao e nao ha node nessa ultima etapa.
    }
}
