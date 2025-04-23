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
}
