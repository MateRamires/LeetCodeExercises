namespace Exercicios.Graphs;

public class GraphExercise200
{
    private static readonly int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0},
        new int[] {0, 1}, new int[] {0, -1}
    }; //Essa variavel representa as 4 possiveis direcoes de movimentos que uma casa pode se mover, {1,0} ganhando + 1 linha (indo para linha de baixo) e {0, 1} ganhando mais uma coluna, indo para a proxima coluna, o mesmo vale para os negativos, so que ai seria a linha de cima e a coluna de tras.

    public int NumIslands(char[][] grid)
    {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int islands = 0;

        for (int row = 0; row < ROWS; row++) //Nos iremos iterar sob todo o grid, pois todas as celulas sao potenciais ilhas.
        {
            for (int col = 0; col < COLS; col++) 
            {
                if (grid[row][col] == '1') //Caso a celula que estamos analisando agora seja uma "terra" entao chamamos o bfs para encontrar o tamanho total da ilha.
                {
                    BFS(grid, row, col);
                    islands++; //Indenpendente do tamanho da ilha, se for 1 terra ou 10 terras, eh uma ilha, entao colocamos mais um valor a nossa variavel resposta.
                }
            }
        }
        return islands;
    }

    private void BFS(char[][] grid, int row, int col) 
    {
        Queue<int[]> queue = new Queue<int[]>(); //No BFS sempre eh necessario a criacao de uma queue, pois nos vamos adicionar todas as "terras" adjacentes a terra atual na queue e ir fazendo esse processo ate nao ter mais terras adjancentes a nenhuma terra desta ilha.
        grid[row][col] = '0'; //Nos vamos transformar a posicao atual (que tem o valor 1 de "terra") em 0, para que nas proximas iteracoes da nossa funcao original, nao consideraremos mais essa celula, ja que ela ja foi considerada para a montagem da ilha atual, assim nao havera como considerar uma terra que ja foi considerada em uma ilha subsequente.
        queue.Enqueue(new int[] { row, col }); //Adicionamos a queue a terra atual, por exemplo { 0,0 }

        while (queue.Count > 0) //Enquanto houver celulas na queue, quer dizer que ainda temos terras para analisar os vizinhos, para ver se encontramos mais vizinhos com terras.
        { 
            var node = queue.Dequeue(); //Tiramos o node/celula atual da queue, pois vamos pegar os vizinhos dele, e ele nao sera mais relevante depois disso.
            int currentRow = node[0], currentCol = node[1]; //Pegamos a row e a coluna da celula que acabamos de tirar da queue.

            foreach (var dir in directions) //Aqui nos vamos analisar todas as 4 possiveis direcoes que uma celual tem, por isso la em cima criamos essa variavel directions, que possui as 4 direcoes (esquerda {0,-1} e direita {0,1}, cima {-1,0} e baixo {1,0}.
            { 
                int newRow = currentRow + dir[0], newCol = currentCol + dir[1]; //Agora criamos nossa NOVA celula apartir das direcoes, entao nossa nova celula sera a celula atual MAIS os valores de direction (que sao 4 diferentes), ai cairemos nos 4 possiveis vizinhos da celula atual.
                if (newRow >= 0 && newCol >= 0 && newRow < grid.Length && newCol < grid[0].Length && grid[newRow][newCol] == '1') //Antes de tudo precisamos checar se essa nova celula que criamos a partir das 4 direcoes da celula atual eh valida, para isso precisamos checar se a celula atual nao esta fora dos limites do array (col e row ser menor ou igual a -1 && col e row ser maior que o tamanho total do array) e por fim, e mais importante, checar se essa nova celula em questao, eh uma terra (1), pois se for, ai eh um vizinho valido.
                {
                    queue.Enqueue(new int[] { newRow, newCol }); //Se tudo acima for validado, ou seja, a celula nova for valida e for uma terra '1', entao adicionamos ela a queue, para analisar os vizinhos dessa celula nas proximas iteracoes do nosso while da queue.
                    grid[newRow][newCol] = '0'; //Assim como fizemos la em cima, transformamos essa celula atual em 0, para que ela nao possa ser mais analisada como "terra" em futuras iteracoes que buscam novas ilhas. Pois uma nova ilha nao pode usar um pedaco de terra que ja foi usado anteriormente em outra ilha.
                }
            }
        }
    }
}
