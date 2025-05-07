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

    //Ex 973
    public int[][] KClosest(int[][] points, int k)
    {
        PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>(); 
        foreach (int[] point in points) //Iremos iterar sob todos os pontos do plano cartesiano
        {
            int dist = point[0] * point[0] + point[1] * point[1]; //A distancia do ponto ate o meio eh calculada fazendo ao quadrado dos pares de valores do ponto
            minHeap.Enqueue(new int[] { dist, point[0], point[1] }, dist); //Vamos colocar na nossa queue primeiro um array, que terao os pares de valor que formam o ponto e tambem a distancia entre ele e o meio, e o valor que ira indicar qual elemento ira sair da heap primeiro sera a propria distancia, pois queremos que a heap retire primeiro os elementos que estao mais proximos do meio, pois esses sao os pontos que queremos pra resposta do ex.
        }

        int[][] result = new int[k][]; //Criamos o array resultado com k elementos, pois vamos devolver k pontos, entao ja colocamos essa "regra" aqui.
        for (int i = 0; i < k; ++i) //Iremos rodar esse for K vezes, pois precisamos colocar k elementos no array resposta.
        {
            int[] point = minHeap.Dequeue(); //Tiramos o primeiro ponto que tem o valor dist mais baixo, ou seja, tiramos o ponto mais proximo do meio da heap.
            result[i] = new int[] { point[1], point[2] }; //Colocamos esse ponto no resultado, pegando apenas os elementos 1 e 2, pois o elemento 0 eh a dist, e ele nao precisa ser retornado.
        }
        return result; 
    }
}
