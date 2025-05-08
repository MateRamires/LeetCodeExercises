namespace Exercicios.Heap___Priority_Queue;

public class KthLargestEx703
{
    private PriorityQueue<int, int> minHeap;
    private int k;

    public KthLargestEx703(int k, int[] nums)
    {
        this.k = k;
        this.minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums) //iremos iterar sob todo o array com os inteiros
        {
            minHeap.Enqueue(num, num); //A logica sera a seguinte, iremos colocar todos os inteiros que estamos analisando na heap, ou seja, sempre iremos adicionar um valor, independente de quantos valores ja foram analisados, sempre adicionaremos primeiro.

            if (minHeap.Count > k) //Aqui a logica mais importante, nos iremos sempre checar se a quantidade de elementos presentes na heap eh maior que K, se for maior que K nos iremos tirar o elemento menor que esta presente na heap. Porque? porque queremos o K elemento maior, ou seja, como queremos o k elemento maior, se sempre tirarmos os menores elementos quando passarmos de K, entao o MENOR elemento de K sempre sera exatamente o elemento que queremos retornar. Imagine que temos 1,2 e 3 e K = 3 e foi adicionado o valor 4, nos iremos retirar o menor elemento (1) e adicionamos o 4, agora nossa heap tem 2,3 e 4, qual o 3 elemento maior da heap? O 2, que eh justamente o elemento mais proximo a ser retirado da heap.
                minHeap.Dequeue();
        }
    }

    public int Add(int val) 
    {
        minHeap.Enqueue(val, val); //Aqui a logica eh exatamente igual a de cima, mas aqui nao tem for pq adicionamos apenas 1 valor

        if (minHeap.Count > k)
            minHeap.Dequeue();

        return minHeap.Peek(); //Complementando o comentario da logica acima, como o valor que estamos buscando sempre sera o menor valor presente na heap, entao basta retornarmos o primeeiro valor da heap, dando um peek, pois o peek ve justamente o elemento menor, o elemento que esta prestes a sair caso usassemos um dequeue.
    }

}
