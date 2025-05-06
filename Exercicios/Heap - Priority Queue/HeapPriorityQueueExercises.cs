namespace Exercicios.Heap___Priority_Queue;

public class HeapPriorityQueueExercises
{
    //Ex 1046
    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>(); //Vamos usar essa nova estrutura de dados, priority queues recebem como primeiro parametro o valor e como segundo parametro a prioridade, e diferente das queue normais, aqui, o que sai no dequeue sera o valor com a menor prioridade, aqui como a prioridade eh inteiro, entao o valor que tiver pareado com o menor int de prioridade sera o valor que saira primeiro.
        foreach (int stone in stones)
            minHeap.Enqueue(stone, -stone); //O c# nao tem maxheap, ou seja, nos temos que arranjar uma forma de quando ele dar um dequeue e tirar a maior pedra, mesmo a logica do priority queue sempre tirar o maior valor, a logica entao sera colocar o valor negativo da pedra, assim, se a pedra tiver peso 10, sera colocado como peso - 10, logo, quando dermos dequeue, a primeira pedra a sair sera justamente a "maior" que esta com valor negativo, portanto na logica do priority queue, ela tem o valor menor.

        while (minHeap.Count > 1) //Dizemos while minHeap for maior que 1, pois existe a possibilidade de sobrar apenas uma pedra, e se sobrar uma pedra retornamos o valor dela (tambem existe a possibilidade de nao sobrar nada, mas de qualquer forma caira nessa condicao, se for o caso).
        { 
            int first = minHeap.Dequeue(); //Essa linha vai pegar o MAIOR valor, pois o primeiro dequeue vai tirar o valor negativo maior, ou seja, o maior valor.
            int second = minHeap.Dequeue(); //Essa vai tirar o segundo maior valor, pois o maior valor acabou de ser tirado na linha anterior.
            if (first > second) //Se a pedra maior for MAIOR que a pedra menor (sim, pois existe a possibilidade das duas serem do mesmo tamanho)
            { 
                minHeap.Enqueue(first - second, -(first - second)); //Ai nos colocamos uma nova pedra na queue, sendo ela o tamanho da maior - menor, e colocamos esse mesmo valor como prioridade negativa, igual fizemos la em cima.
            }
        }

        return minHeap.Count == 0 ? 0 : minHeap.Peek(); //No fim checamos, se existe alguma pedra restante, se nao, devolve 0, se sim, devolve a pedra em questao.
    }
}
