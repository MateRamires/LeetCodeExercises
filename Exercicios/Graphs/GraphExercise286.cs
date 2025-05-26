namespace Exercicios.Graphs;

public class GraphExercise286
{
    public void islandsAndTreasure(int[][] grid)
    {
        Queue<int[]> queue = new Queue<int[]>();
        int ROWS = grid.Length, COLS = grid[0].Length;

        //Vamos iterar sob todo o grid
        for (int row = 0; row < ROWS; row++) 
        {
            for (int col = 0; col < COLS; col++)
            {
                if (grid[row][col] == 0) //Todos os portoes nos iremos colocar dentro da nossa queue (portao eh quando a celula tem 0 como valor)
                    queue.Enqueue(new int[] { row, col }); //Inserimos a celula do portao na queue.
            }
        }

        if (queue.Count == 0) return;

        int[][] directions = {
            new int[] { -1, 0 }, new int[] { 0, -1 },
            new int[] { 1, 0 }, new int[] { 0, 1 }
        }; //Como ja vimos em varios outros exercicios, essa matriz representa as 4 direcoes nas quais uma celula pode se mover, cima, baixo, esquerda e direita.

        while (queue.Count > 0) //Nos vamos rodar esse while enquanto nossa queue tiver elementos dentro dela.
        {
            int[] current = queue.Dequeue(); //A celula atual
            int row = current[0]; //Linha da celula atual
            int col = current[1]; //Coluna da celula atual
            foreach (int[] dir in directions) 
            { 
                int newRow = row + dir[0]; //A nova linha sera composta da linha da celula atual + direcao (cima e/ou baixo)
                int newCol = col + dir[1]; //A nova coluna sera composta da coluna da celula atual + direcao (esquerda e/ou direita)
                if (newRow >= ROWS || newCol >= COLS || newRow < 0 || newCol < 0 //Estamos checando se a nossa nova celula com essa row e col + direcao esta dentro dos limites do grid.
                    || grid[newRow][newCol] != int.MaxValue) //E por fim estamos checando se essa nova celula formada a partir das direcoes da em uma celula onde o valor eh infinito, que sao as celulas vazias, pois se nao for infinito, entao a celula que estamos analisando ou eh uma parede ou um portao, ai deve ser desconsiderado.
                {
                    continue; //Se alguma das condicoes acima for true, entao damos continue, pulando essa direcao e indo testar a proxima.
                }
                queue.Enqueue(new int[] { newRow, newCol }); //Se nao cair no continue, entao a celula eh valida, portanto adicionamos ela a queue, para analisar as vizinhas dela posteriormente.
                
                grid[newRow][newCol] = grid[row][col] + 1; //Por fim, temos que colocar nessa celula a distancia entre ela e o portao, para isso, basta fazer a celula vizinha dela + 1. Se a celula vizinha for o portao, como ele eh 0, se tornara 1, ou seja, 1 de distancia. Se a celula vizinha, ja for 1 de distancia, entao essa nova celula sera 2 de distancia... e assim por diante.
            }
        }
    }
}
