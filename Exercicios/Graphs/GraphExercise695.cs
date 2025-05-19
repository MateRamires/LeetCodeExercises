namespace Exercicios.Graphs;

public class GraphExercise695
{
    private static readonly int[][] directions = new int[][] { //Estamos criando um array de arrays contendo todas as possiveis direcoes que uma celula pode "olhar" para encontrar vizinhos com terra (1), ou seja, cima, baixo, esquerda e direita, todas representadas aqui com + 1 row (baixo) - 1 na row (cima), + 1 na col (direita) e -1 na col (esquerda)
        new int[] { 1,0 }, new int[] { -1,0 },
        new int[] { 0,1 }, new int[] { 0,-1 },
    };

    public int MaxAreaOfIsland(int[][] grid)
    {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int area = 0;

        for (int row = 0; row < ROWS; row++) //Esse bloco sera usado para visitar TODAS as celulas do nosso grid, para achar a maior area teremos que potencialmente analisar todas as celulas, pois a maior area pode estar em qualquer canto do grid.
        {
            for (int col = 0; col < COLS; col++) 
            {
                if (grid[row][col] == 1) //So iremos mandar para o DFS areas que tem terra (1), nao faria sentido calcular a area se a celula atual fosse agua (0)
                {
                    area = Math.Max(area, Dfs(grid, row, col)); //DFS ira devolver a area total da terra que estamos analisando no momento + seus vizinhos adjacentes validos, essa area total que sera retornada no final, pode ou nao ser maior que a area de outra ilha previamente calculada, por isso fazemos o Math.max para calcular se essa area dessa ilha especifica eh maior que a area de outra ilha ja calculada anteriormente.
                }
            }
        }

        return area;
    }

    private int Dfs(int[][] grid, int row, int col) 
    {
        if (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length || grid[row][col] == 0) //Esse eh o base-case que ira checar se a celula atual nao eh valida, pois se ela nao for valida, ai retornamos 0, para nao somar a area total que estamos calculando da ilha. Para uma celula nao ser valida, checamos se row ou col estao out-of-bounds, ou seja, sairam para fora do array, seja para tras (negativo) ou para frente (maior que a length total do grid), e claro, checamos se a celula eh 0, pois se a celula esta dentro dos limites mas for = 0, ou seja, agua, entao nao somamos a area da ilha tambem.
            return 0; //0 pois eh uma celula invalida, nao podera somar a nossa area total da ilha atual.

        grid[row][col] = 0; //Essa linha tera a funcao de demarcar a celula atual como visitada, transformando ela em valor 0, que equivale a agua, isso porque, se ela foi visitada uma vez, e somou ao valor total da ilha, ela nao nos interessa mais, nao queremos visita-la mais, nem nesse DFS e nem no for da funcao original, pois a area dessa ilha ja tera sido calculada, portanto, apenas transformamos ela em 0 (agua) e ela sera ignorada daqui para frente, nao sera mais considerada uma ilha e sera pulada de diversas condicoes IFs.
        int res = 1; //Essa sera a variavel que ira guardar a area da ilha atual, cada celula tem no maximo 1 de area, e vai somando com as celulas adjacentes.
        foreach (var dir in directions) //Aqui estamos usando a variavel directions criada la em cima, para analisarmos todas as 4 direcoes da celula atual, em cima, em baixo,a esquerda e a direita da celula atual, buscando celulas validas (1)
        {
            res += Dfs(grid, row + dir[0], col + dir[1]); //Somaremos a variavel res, as res das futuras recursoes, entao para cada ilha adjacente valida, sera somado + 1 + 1 + 1, e na ultima recursao chegara aqui a soma de todas as ilhas adjacentes, se por exemplo tiverem 4 ilhas adjacentes a celula original, sera feito 1 + 1 + 1 + 1 das ilhas adjacentes + 1 da ilha original, resultando em area de 5.
        }
        return res; //Para cada recursao, sera retornada a area calculada ate o momento, e na ultima recursao, sera retornada a area total da ilha de volta para funcao original MaxAreaOfIsland().
    }
}
