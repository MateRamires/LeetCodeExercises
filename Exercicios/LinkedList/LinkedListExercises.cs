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
}
