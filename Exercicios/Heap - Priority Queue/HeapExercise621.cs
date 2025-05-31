namespace Exercicios.Heap___Priority_Queue;

public class HeapExercise621
{
    public int LeastInterval(char[] tasks, int n)
    {
        int[] count = new int[26]; //Criamos um array que ira conter a quantidade de cada letra (ja que cada letra representa uma task). Inicialmente so teremos um array vazio com 26 posicoes, onde cada posicao ira representar um numero

        //Agora vamos prencher esse array com as letras. Iremos iterar sob todo o array de Tasks para pegar cada letra
        foreach (var task in tasks)
        {
            count[task - 'A']++; //Para cada letra (task) usaremos a logica classica de ascii, onde pegaremos o valor ascii letra atual menos o valor ascii da letra 'A' resultando num valor de 0 a 26, e somaremos +1 pra cada letra, assim, no final teremos cada posicao em ordem alfabeta com a quantidade de letras exata de cada letra.
        }

        //Abaixo iremos preencher a nossa priorityQueue com todas as letra, seguindo a ordem de prioridade onde a letra que tem mais frequencia, sera a que tera maior prioridade na queue.
        var maxHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < 26; i++) 
        {
            if (count[i] > 0) 
            {
                maxHeap.Enqueue(count[i], -count[i]); //Como no C# so temos minQueue (da prioridade ao menor valor), entao temos que colocar a prioridade como negativo, pois ai teremos a logica contraria, o maior numero NEGATIVO eh o que tem mais prioridade, sendo assim, podemos simular um maxHeap.
            }
        }

        int time = 0;
        Queue<int[]> queue = new Queue<int[]>();
        while (maxHeap.Count > 0 || queue.Count > 0) 
        {
            if (queue.Count > 0 && time >= queue.Peek()[1]) //Se nossa queue tem algum valor, e a unidade tempo atual for maior/igual ao proximo tempo que uma task pode ser processada, ai entraremos nesse if.
            {
                int[] temp = queue.Dequeue(); //Primeiro poderemos tirar esse valor da nossa queue, pois ele sera processado agora, e colocaremos esse valor numa variavel temporaria (lembrando qeu esse valor eh um array de 2 posicoes, onde a primeira posicao eh a quantidade de tasks ainda restantes dessa task especifica, e a segunda posicao eh a proxima unidade de tempo que ela pode ser processada (mas essa segunda posicao ja nao eh mais relevante aqui, ela eh relevante na hora da verificacao do IF)
                maxHeap.Enqueue(temp[0], -temp[0]); //Iremos colocar na nossa heap esse novo valor (que no caso sera a quantidade de tasks restante, e sua prioridade, sendo que a prioridade eh a propria quantidade de tasks restantes.
            }

            if (maxHeap.Count > 0) 
            {
                int cnt = maxHeap.Dequeue() - 1; //Nos iremos tirar o maior valor (ou seja a letra mais frequente) e tiraremos -1 dessa letra (pois agora vamos processar uma task dessa letra, portanto teremos -1 task referente a essa letra)
                if (cnt > 0) //Se a quantidade ainda for maior que 0, isso quer dizer que ainda temos tasks dessa letra, mesmo processando essa task atual, portanto teremos que processar essa letra especifica mais a frente, pois ainda temos tasks referentes a ela.
                {
                    queue.Enqueue(new int[] { cnt, time + n + 1 }); //Se for o caso de houver ainda tasks dessa letra, teremos que adicionar a nossa Queue, a quantidade que ainda resta (que sabemos que sera maior que 0), e o proximo tempo em que ela vai estar disponivel para ser processada, para isso teremos que adicionar o tempo que estamos atualmente (time) + o cooldown (n) + 1 (mais um pois pegaremos o tempo atual mais o tempo de cooldown, e isso resultara no tempo anterior ao que iremos processar essa letra novamente, adicionando + 1, ai cairemos exatamente no proximo tempo para processar essa letra/task)
                }
            }

            time++; //Para cada iteracao do while, iremos adicionar + 1 tick - mais uma unidade de tempo
        }
        return time;
    }
}
