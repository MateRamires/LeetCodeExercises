using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

namespace Exercicios.LinkedList;

public class LinkedListExercises
{
    //Ex 206
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null; //Ponteiro previous, de inicio ira apontar para null, ja que inicialmente nao ha nenhum valor anterior ao node "Head".
        ListNode curr = head; //Ponteiro current, inicialmente apontara para o node Head, ou seja, o primeiro node da linked list.

        while (curr != null) //Esse while indica que faremos o processamento ate que current seja null, ou seja, ate que ele passe por todos os valores da linked list e acabe no fim, onde esta nulo.
        {
            ListNode temp = curr.next; //Temos que salvar o next do node atual, pois vamos alterar o next do node atual na proxima linha, e temos que usar uma variavel temporaria para salvar o next, antes dessa alteracao.
            curr.next = prev; //Aqui trocamos a ordem da linked list, o node atual passa a apontar para o node anterior a ele, no caso do primeiro node, o "Head" ele passa a apontar para Null, ja que ele sera o ultimo node da linked list invertida.
            prev = curr; //O ponteiro previous deve se alterar para apontar para o node atual, pois temos que proseguir com a linked list.
            curr = temp; //O ponteiro current agora vai apontar para o next do ponteiro atual, mas como alteramos o next do ponteiro atual na 2 linha desse while, nos temos que utilizar nossa variavel temp, que estava guardando o next original do nosso node atual.
        }
        return prev; //Retornamos o prev, pois o exercicio quer que retornemos o novo "Head" da linked list, e o novo head sera o ponteiro previous, pois o current, no final do processo, sera Null, que eh a nossa condicao do while.
    }

    //Ex 21
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode(0); //Inicializamos a nossa linked list com um valor dummy, que nao serve para nada alem de apenas iniciar a linked list.
        ListNode node = dummy;

        while (list1 != null && list2 != null) //O while so rodara enquanto as 2 listas forem diferentes que null, pois se uma delas for nula, nao poderemos comparar os valores entre as 2, ja que uma delas nao tem nada.
        {
            if (list1.val < list2.val) //Nos iremos checar se o valor atual da lista1 eh menor que o valor atual da lista2, se for, nos inserimos o valor da lista1 na nossa nova linked list e movemos para o next da lista1, e continuaremos fazendo essas comparacoes ate uma das duas lista nao ter mais nada e ai saira do while.
            {
                node.next = list1;
                list1 = list1.next; //Depois de colocar o node atual da lista1 na nossa linked list que sera o resultado, nos movemos para o proximo node da lista1.
            }
            else 
            {
                node.next = list2;
                list2 = list2.next; //Exatamente o mesmo processo, mas para a lista2, quando acontecer de o valor da lista2 for menor que o da lista1.
            }
            node = node.next; //Movemos a o ponteiro para a ultima posicao da nossa lista, a que acabamos de adicionar.
        }

        if (list1 != null) //Por fim, checamos quais das 2 listas ainda tem valores restantes (nodes restantes) e inserimos esse node + todo o resto para dentro da nossa linked list.
            node.next = list1; //Caso a lista2 tenha acabado os valores, adicionamos na nossa linked list merge todos os valores que restam da lista1, no caso, precisamos adicionar apenas o proximo valor da lista1, pois o resto dos valores ja estarao nos nexts.
        else
            node.next = list2;

        return dummy.next; //Retornamos o valor apos o dummy, pois o dummy eh usado so para inicializar nossa linked list.
    }

    //Ex 141
    public bool HasCycle(ListNode head)
    {
        ListNode slow = head, fast = head;

        while (fast != null && fast.next != null) //Temos que garantir que o fast nao eh atualmente nulo, que eles nao esta exatamente no fim da lista, e temos que garantir que o proximo elemento tambem nao seja nulo, pois o fast se move 2 casas por vez, se o next for null, entao o fast vai se mover mais casas do que ha, e dara uma exception.
        {
            fast = fast.next.next; //Fast vai se mover 2 casas para frente, ou seja o proximo do proximo.
            slow = slow.next; //Slow se movera apenas 1 casa.
            if (slow.Equals(fast)) return true; //Caso o node slow seja exatamente igual ao node fast em um determinado momento do loop, isso quer dizer que ha um ciclo e retornaremos true.
        }

        return false; //Caso nossas condicoes sejam ativas no while, e saia desse loop, isso quer dizer que o fast chegou ao fim do loop, ou seja, nao ha ciclo, e podemos retornar falso.
    }

    //Ex 143 
    public void ReorderList(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head.next;

        while (fast != null && fast.next != null) //Esse while sera usado para dividir a lista em 2 metades, basicamente ele rodara ate o fast chegar no final (ou no ultimo elemento antes do final), e nesse exato momento, o ponteiro slow apontara exatamente para o final da primeira sublista, assim descobrimos como dividir a lista em 2 partes.
        {
            slow = slow.next; //Slow se move 1 casa por vez.
            fast = fast.next.next; //Fast se move 2 casas por vez.
        }

        ListNode secondHalfFirstNode = slow.next; //O proximo node apos o slow sera exatamente o inicio da segunda lista.
        ListNode prev = slow.next = null;
        while (secondHalfFirstNode != null) //Esse while ira dar um reverse na segunda metade da lista
        {
            ListNode temp = secondHalfFirstNode.next;
            secondHalfFirstNode.next = prev;
            prev = secondHalfFirstNode;
            secondHalfFirstNode = temp;
        }

        ListNode firstHalfFirstNode = head;
        secondHalfFirstNode = prev; //Apos o while de cima que ira fazer um reverse na segunda lista, o prev sera a nova "head" da segunda lista, ou o primeiro node da segunda lista.
        while (secondHalfFirstNode != null) 
        {
            ListNode temp1 = firstHalfFirstNode.next; //Temos que guardar ambos os links nexts tanto do primeiro node da primeira lista quanto do primeiro node da segunda lista.
            ListNode temp2 = secondHalfFirstNode.next;
            firstHalfFirstNode.next = secondHalfFirstNode; //Na primeira iteracao, o primeiro elemento da segunda lista sera o novo 2 elemento da primeira lista.
            secondHalfFirstNode.next = temp1;
            firstHalfFirstNode = temp1; //O ponteiro da primeira lista se movera para o "segundo elemento original" da lista para continuar o processamento
            secondHalfFirstNode = temp2; //Exatamente o mesmo acontecera com a segunda lista.
        }
    }

    //Ex 19
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode dummy = new ListNode(0, head); //Temos que criar um dummy, pois queremos que o LeftP caia uma casa antes do elemento que queremos eliminar, para ele cair uma casa antes, criamos um novo node que vem antes de tudo.
        ListNode leftP = dummy;
        ListNode rightP = head;

        while (n > 0) //O ponteiro direito deve se posicionar N vezes para frente do node Head, entao fazemos ele while que vai rodar N vezes e vai elevando a posicao do ponteiro direito.
        { 
            rightP = rightP.next;
            n--;
        }

        while (rightP != null) //Por fim, para dar certo, precisamos que o ponteiro direito chegue a nulo, ou seja, chegue ao fim da linked list, ai nesse caso, o ponteiro esquerdo estara em cima do node anterior ao elemento que vamos eliminar.
        {
            leftP = leftP.next;
            rightP = rightP.next;
        }

        leftP.next = leftP.next.next; //Basta agora falar que o proximo elemento do elemento anterior ao que tem que ser eliminado eh igual a next.next, ou seja, vamos pular o elemento a ser eliminado, eliminando-o.
        return dummy.next; //Temos que retornar o elemento pos dummy, pois o dummy eh so para fins do exercicio funcionar, ele nao deve aparecer na lista final.
    }

    //Ex 138
    public NodeWithRandom CopyRandomList(NodeWithRandom head)
    {
        Dictionary<NodeWithRandom, NodeWithRandom> oldToCopy = new Dictionary<NodeWithRandom, NodeWithRandom>(); //Criaremos um HashMap para mapear todos os nodes sendo a chave o ponteiro ao node original e o valor o ponteiro ao node copiado, que tera o valor original, assim, quando fizermos mudancas no node original, ao checarmos nosso hashMap, podemos usar esses ponteiros para recuperarmos os valores originais dos nodes.

        NodeWithRandom current = head;
        while (current != null) //Vamos iterar sob toda a linked list.
        {
            NodeWithRandom copy = new NodeWithRandom(current.val); //Criamos um node que eh uma copia do node original, ou seja, agora temos 2 nodes iguais, o original e a copia.
            oldToCopy[current] = copy; //Aqui estamos dizendo, no hashmap, a key sera a referencia ao node original e o value sera referencia ao node copiado, sendo assim, se houver alteracoes nos val dos nodes originais, se buscarmos no hashmap, a referencia sera a mesma, e poderemos ver os valores originais que aquele node tinha.
            current = current.next;
        }

        current = head;
        while (current != null) 
        { 
            NodeWithRandom copy = oldToCopy[current]; //Aqui o copy tera os valores originais da lista original.
            copy.next = current.next != null ? oldToCopy[current.next] : null; 
            copy.random = current.random != null ? oldToCopy[current.random] : null;
            current = current.next;
        }

        return head != null ? oldToCopy[head] : null;
    }

    //Ex 2
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode(); //Como ja aconteceu em diversos outros exercicios, usamos um dummy node para que nao tenha que criar a lista no meio do processamento, ela ja eh criada aqui, com um valor que nao sera considerado mais a frente.
        ListNode current = dummy; //A variavel current que sera a importante, pois iremos sempre considerar o current.next, entao atualmente, current = dummy, mas logo no inicio do processamento abaixo, ja iremos colocar um next ao current, e ai que de fato comecara nossa lista.

        int carry = 0; //Esse eh o valor que eh carregado quando uma soma da maior que 10, entao se (7 + 8 = 15) entao 5 ficara no node atual e 1 sera "carregado" para a proxima soma, e esse 1 carregado, eh exatamente essa variavel, que vai guardar esse numero para a proxima iteracao.
        while (l1 != null || l2 != null || carry != 0) //Esse while rodara enquanto AMBAS as listas tiverem elementos (so para se nao tiver mais elementos) E se o carry nao tiver mais valor algum, pois se ambas as listas tiverem acabado, mas o carry tiver algum valor, esse valor tem que ser inserido ao fim da lista, pois ele sera o primeiro elemento da soma, quando ela nao esta invertida. Algo como (8 + 7 = 15), ambas as listas ja acabaram, mas o valor final deve ter 2 nodes, 5 e 1, se nao colocassemos essa verificacao do carry, o resultado final seria apenas 5, e pularia o 1 que ficou no carry, dando errado.
        {
            int v1 = (l1 != null) ? l1.val : 0; //Esse sera o valor da primeira lista que vamos somar, mas verificarmos primeiro se HA algum valor nessa lista, pois se nao houver, isso quer dizer que a lista acabou, porem a lista de baixo ainda pode ter valor, ou nosso carry ainda pode ter algum numero, nesse caso, temos que "fingir" que a lista1 (que esta vazia, ou nula) na verdade tem o valor 0.
            int v2 = (l2 != null) ? l2.val : 0; //Exatamente a mesma coisa do de cima, mas para a lista2.

            int val = v1 + v2 + carry; //Aqui estamos pegando o valor da soma dos 2 elementos das duas listas, mais o valor que foi carregado entre uma iteracao e outra (carry)
            carry = val / 10; //Para sabermos o valor de carry, precisamos fazer essa operacao, se a soma dos 2 valores for 15, fazemos 15 / 10 = 1.
            val = val % 10; //Na mesma pegada da linha de cima, fazemos 15 / 10 = 1, e sobra 5 (usamos % que eh modulo para saber quanto sobrara de uma operacao de divisao de inteiros).
            current.next = new ListNode(val); //Por fim, adicionamos o valor (apos a divisao/modulo) ao proximo elemento do elemento atual.

            current = current.next; //Para a proxima iteracao, mudamos o atual para o proximo elemento (que acabamos de adicionar)
            l1 = (l1 != null) ? l1.next : null; //Por fim, precisamos verificar se o proximo elemento de ambas a listas EXISTE, se nao existir, ai a lista sera null agora, por isso em cima verificamos se a lista eh null, pois aqui ela se tornara null caso nao haja mais elementos.
            l2 = (l2 != null) ? l2.next : null;
        }

        return dummy.next; //Como o dummy eh apenas para criacao da lista, retornamos apenas o elementos pos o dummy pra frente.
    }

    //Ex 23
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0) //if para tratar edge cases onde nao ha linked lists dentro da lista.
            return null;

        while (lists.Length > 1) //Nos vamos fazer merges em pares de listas, e vamos continuar fazendo isso ate que sobre apenas uma lista, que sera o nosso resultado, por isso a nossa condicao aqui eh while lists > 1, pois quando tiver 1 lista, nos chegamos a resposta, logo podemos sair do while.
        { 
            List<ListNode> mergedLists = new List<ListNode>();

            for (int i = 0; i < lists.Length; i += 2) //Como vamos fazer um merge sob 2 listas por iteracao, entao vamos ter que colocar que o for vai incrementar 2 de cada vez, ao inves de 1.
            {
                ListNode l1 = lists[i]; //A primeira lista obviamente sera apenas a lista na posicao i.
                ListNode l2 = (i + 1) < lists.Length ? lists[i + 1] : null; //A lista 2 pode ser null, pois se a quantidade total de linked lists for impar, em um determinado momento i + 1 nao existira no array de listas, por isso temos que checar se a length da lista eh maior que i + 1 antes de fazer algo.
                mergedLists.Add(MergeList(l1,l2)); 
            }
            lists = mergedLists.ToArray(); //Temos que transformar mergedList em array pois originalmente ela eh uma lista generica e nao um array.
        }
        return lists[0]; //Retornaremos justamente o unico elemento restante de lists, que eh o nosso array ordenado.
    }

    private ListNode MergeList(ListNode l1, ListNode l2) 
    { 
        ListNode dummy = new ListNode();
        ListNode tail = dummy;

        while (l1 != null && l2 != null) 
        {
            if (l1.val < l2.val)
            {
                tail.next = l1;
                l1 = l1.next;
            }
            else 
            { 
                tail.next = l2;
                l2 = l2.next;
            }
            tail = tail.next;
        }

        if (l1 != null) 
        {
            tail.next = l1;
        }
        if (l2 != null)
        {
            tail.next = l2;
        }

        return dummy.next;
    }

    //Ex 287
    public int FindDuplicate(int[] nums)
    {
        int slow = 0, fast = 0;
        while (true) //Esse while eh para acharmos o ponto onde o fast e o slow se encontram, sinalizando que ha um ciclo nessa linked list, se fosse um exercicio de saber se tem ciclo ou nao, esse codigo ja bastaria.
        {
            slow = nums[slow];
            fast = nums[nums[fast]]; //Usamos esse passo para pular 2 passos, pois nums[fast] te daria o proximo indice, nums[nums[fast]] mostra onde o valor dessa casa aponta, ou seja, ele pulara 2 casas, pois ele vera qual valor a primeira casa aponta, e a primeira casa ou primeiro "node" aponta para o segundo "node" da nossa linked list.
            if (slow == fast)
                break;
        }

        int slow2 = 0;
        while (true) //Esse while nao eh nem um pouco intuitivo, mas esse eh o floyd's algoritm, basicamente pegamos o ponto onde o slow pointer e o fast pointer se encontram, e iniciamos um novo while a partir disso, nesse novo while, esquecemos o fast pointer e so usamos o slow pointer antigo, e um slow pointer novo, que vai apontar para o inicio da lista. Quando o slow se encontrar com o fast, esse ponto sera exatamente o inicio do ciclo.
        {
            slow = nums[slow];
            slow2 = nums[slow2];
            if (slow == slow2) 
                return slow;
        }
    }
}
