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
}
