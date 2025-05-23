namespace Exercicios.Graphs;

public class GraphExercise417
{
    private int[][] directions = new int[][] {
        new int[] { 1, 0 }, new int[] { -1, 0 },
        new int[] { 0, 1 }, new int[] { 0, -1 }
    }; //Assim como em outros exercicios, essa variavel vai guardar as 4 possiveis direcoes que uma celula pode se mover ao buscar outras celulas no DFS. (cima, baixo, esquerda e direita.)

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        int ROWS = heights.Length, COLS = heights[0].Length;
        bool[,] pacific = new bool[ROWS, COLS]; //Nos iremos criar dois grids novos, esses grids terao exatamente as mesmas dimensoes do grid original heights, isso porque esses grids irao representar quais celulas terao conexao com os oceanos, ou seja, esses grids terao as mesmas dimensoes do grid original, mas dentro de cada celula tera true ou false, se for true, entao aquela celula tem conexao com o oceano respectivo. Se for false, entao aquela celula nao tem conexao com o oceano respectivo.
        bool[,] atlantic = new bool[ROWS, COLS]; //Teremos um grid para pacific e um grid para atlantic, para sabermos quais celulas tem conexao com pacific e qual tem acesso ao atlantic, de forma separada, para mais a frente compararmos esses 2 grids e ver quais celulas tem conexao com os 2 oceanos, que eh o que estamos buscando.

        //Na logica abaixo sera a seguinte, nos iremos iterar sob todas as colunas do grid.
        for (int col = 0; col < COLS; col++) 
        {
            DFS(0, col, pacific, heights); //E para cada coluna, nos iremos chamar o DFS, passando row = 0 (primeiro parametro do DFS) e a coluna, e nosso grid de oceano pacifico. Isso pq, todas as celulas da primeira coluna com certeza tem acesso ao oceano pacifico.
            DFS(ROWS - 1, col, atlantic, heights); //A mesma coisa sera feita mas para a ultima linha do grid (ROWS totais - 1) so que nesse caso, todas as celulas da ultima linha do grid pertencem ao oceano atlantico, por isso passamos para o DFS o grid de oceano atlantico.
        }

        //A mesma logica de cima deve ser feita mas para ROWS. Pois a primeira coluna e a ultima coluna tambem pertencem garantidamente a um oceano.
        for (int row = 0; row < ROWS; row++)
        {
            DFS(row, 0, pacific, heights); //Todas as celulas da coluna 0 (segundo parametro do DFS) pertecem ao oceano pacifico
            DFS(row, COLS - 1, atlantic, heights); //Todas as celulas da ultima coluna (COLS totais - 1) pertecem ao oceano atlantico
        }

        //Depois que o processamento dos DFS acima acabar, nos teremos os 2 grids preenchidos com TODAS as celulas que pertencem aos respectivos oceanos em seus respectivos grids. Por fim, nos iremos iterar sob todo o grid, dessa vez por todas as rows e cols, cobrindo de fato, todo o grid.
        List<IList<int>> res = new List<IList<int>>();
        for (int row = 0; row < ROWS; row++) 
        {
            for (int col = 0; col < COLS; col++)
            {
                if (pacific[row, col] && atlantic[row, col]) //E para cada celula do grid nos iremos checar se essa celula esta como true em AMBOS os grids pacific e atlantic, pois se tiver true em AMBOS os grids, isso quer dizer que essa celula especifica que estamos analisando agora tem acesso tanto ao oceano pacifico quanto o atlantico, portanto, ela faz parte da resposta final.
                    res.Add(new List<int> { row, col }); //Adicionamos essa tal celula com acesso aos 2 oceanos a nossa lista de resposta.
            }
        }
        return res; //No fim, teremos todas as celulas que pertencem a ambos oceanos nessa lista.
    }

    private void DFS(int row, int col, bool[,] ocean, int[][] heights)
    {
        ocean[row, col] = true; //Sempre que o DFS for chamado, quer dizer que a celula que foi passada tem acesso ao oceano que foi passado como parametro, entao se foi passado uma row e uma col tal e o oceano atlantico para o DFS, entao essa celula especifica TEM acesso ao oceano atlantico, por isso a primeira coisa que fazemos eh colocar essa celula como true no grid do oceano.
        foreach (var direction in directions) 
        {
            int newRow = row + direction[0]; //Nos pegaremos a nova row e col com base nas 4 direcoes da nossa variavel directions, ou seja, iremos analisar os 4 vizinhos da celula atual para checar se esse vizinho eh valido para ser adicionado como uma celula que tem conexao ao oceano especifico.
            int newCol = col + direction[1];
            if (newRow >= 0 && newRow < heights.Length && newCol >= 0 && newCol < heights[0].Length  //As primeiras quatro condicoes sao para checar se essa possivel celula vizinha nao ultrapassa os limites do grid, pois se ultrapassar ela nao eh valida, portanto nao chamaremos o DFS.
                && !ocean[newRow, newCol] //Ah outra condicao eh checar se a celula eh valida, porem, ja foi adicionada no oceano atual anteriormente, nesse caso, nao poderemos adicionar novamente essa celula no oceano, pois ja a analisamos.
                && heights[newRow][newCol] >= heights[row][col]) //Por fim, e o mais importante para o exercicio, caso todas as outras condicoes passarem, iremos checar se a celula vizinha eh MAIOR ou IGUAL a celula atual, pois para a agua "escorrer" e chegar no oceano, o caminho dessa celula deve ser menor que ela, mas como estamos fazendo o contrario (da celula mais proxima do oceano para dentro do grid) entao faremos a checagem ao contrario tbm, checaremos se a celula vizinha eh maior ou igual ao valor da celula atual, e se sim, ai passou e essa celula tem conexao ao oceano, portanto chamamos o DFS
            {
                DFS(newRow, newCol, ocean, heights); //Se passou por todas as condicoes, entao essa celula eh valida, ela tem conexao com o oceano, portanto chamamos o DFS, que ira transformar essa celula em true, para o oceano atual e ira checar os vizinhos dessa nova celula, buscando novas celulas validas.
            }
        }
    }
}
