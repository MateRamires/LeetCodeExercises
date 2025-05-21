namespace Exercicios.Graphs;

public class GraphExercise994
{
    public int OrangesRotting(int[][] grid)
    {
        Queue<int[]> q = new Queue<int[]>();
        int freshOranges = 0;
        int time = 0;

        for (int row = 0; row < grid.Length; row++) //Vamos iterar sob todo o grid.
        {
            for (int col = 0; col < grid[0].Length; col++) 
            {
                if (grid[row][col] == 1) //Se a celula atual for 1 ou seja, uma laranja fresca, nos vamos adicionar +1 a variavel que guarda a qnt de laranjas frescas, pois utilizaremos ela mais a frente para saber se todas as laranjas apodreceram no final ou nao.
                    freshOranges++;

                if (grid[row][col] == 2) //Se a celula atual for 2 ou seja, uma laranja podre, nos vamos adiciona-la a nossa queue, pois vamos partir nosso BFS das laranjas podres, independente se for 1 laranja podre ou varias, iremos ter cada uma delas como ponto de partida do BFS.
                    q.Enqueue(new int[] { row, col });
            }
        }

        int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } }; //Essa variavel indica todas as direcoes que uma celula pode se mover, cima, baixo, esquerda e direita, pois sao essas direcoes que serao consideradas quando uma laranja for apodrecer outra vizinha.
        
        while (freshOranges > 0 && q.Count > 0) //Vamos rodar esse while enquanto houver laranjas frescas OU houver laranjas podres no nosso queue.
        { 
            int rottenOrangeslength = q.Count; //quantidades de laranjas podres nessa iteracao atual.
            for (int i = 0; i < rottenOrangeslength; i++)
            {
                int[] currentRottenOrange = q.Dequeue();
                int row = currentRottenOrange[0];
                int col = currentRottenOrange[1];

                foreach (int[] dir in directions) //Para cada laranja podre na nossa queue, iremos olhar para todos os 4 possiveis vizinhos dela, buscando laranjas frescas para apodrecer.
                { 
                    int nextRow = row + dir[0]; //Iremos pegar a row e a coluna da celula vizinha da laranja podre que estamos analisando
                    int nextCol = col + dir[1];
                    if (nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[0].Length && grid[nextRow][nextCol] == 1) //Com base nessa nova celula de um vizinho da nossa laranja podre atual, checamos se ela possui row e cols validos (dentro dos limites do array) e checamos se ela eh uma laranja fresca (= 1) pois se for, ai entramos no if, pra transforma-la em uma laranja podre.
                    {
                        grid[nextRow][nextCol] = 2; //Transformamos essa laranja fresca em podre.
                        q.Enqueue(new int[] { nextRow, nextCol }); //Como ela se tornou uma laranja podre, agora ela entra na nossa queue, para fazermos bfs com ela na proxima iteacao, e buscar os vizinho dela.
                        freshOranges--; //Tiramos -1 da nossa variavel que guarda todas as laranjas frescas
                    }
                }
            }
            time++; //No fim de cada iteracao do WHILE (lembrando que o while vai rodar a cada iteracao sob todas as laranjas podres que esta na queue, que pode ser 1 ou mais de uma) ou seja, a cada iteracao, onde se apodreceram uma ou varias laranjas, um minuto se passa apenas, e por isso adicionamos +1 minuto apenas no final de cada loop while.
        }

        return freshOranges == 0 ? time : -1; //Aqui a logica eh a seguinte, contamos la em cima a quantidade total de laranjas frescas, e diminuimos cada uma que foi apodrecida no nosso while, se ao final do while, quando esvaziar nossa queue, ainda houver laranjas frescas, isso quer dizer que, alguma laranja fresca nao foi possivel apodrecer, entao, devolveremos -1, pois nao houve como apodrecer todas as laranjas independente do tempo.
    }
}
