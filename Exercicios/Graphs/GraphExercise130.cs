namespace Exercicios.Graphs;

public class GraphExercise130
{
    private int ROWS, COLS;
    public void Solve(char[][] board)
    {
        ROWS = board.Length;
        COLS = board[0].Length;

        //Nos iremos iterar sob todas as linhas (rows) e todas as celulas que forem da coluna 0 (totalmente a esquerda) e da ultima coluna (totalmente a direita) e tiverem um "O" isso significa que esses "O" nunca poderao ser transformados em "x" por nunca poderem estar cercados de "x".
        for (int row = 0; row < ROWS; row++) 
        {
            if (board[row][0] == 'O')
                Capture(board, row, 0); //Quando Isso acontece, nos iremos chamar essa função capture, usando a logica reversa, nos vamos capturar todas as celulas que NÃO podem ser capturadas, assim, no fim, as que nao foram capturadas, serao justamente as celulas que estamos buscando que vao de fato ser capturadas e serem transformadas em x.

            if (board[row][COLS - 1] == 'O')
                Capture(board, row, COLS - 1);
        }

        //O mesmo processo ira ocorrer com as colunas, todas as celulas onde as rows são 0 (totalmente acima) ou da ultima row (totalmente abaixo) e tiverem "o", essas celulas nunca poderao ser capturadas por "x"
        for (int col = 0; col < COLS; col++)
        {
            if (board[0][col] == 'O')
                Capture(board, 0, col); //Nesse cenario novamente iremos chamar nossa função capture, para capturar todas as celulas que NÃO podem ser capturadas na ideia original do exercicio, lembrando que estamos fazendo a logica reversa, entao iremos capturar quem nao pode ser capturado, e quem restar, é quem de fato pode ser capturado na logica do exercicio.

            if (board[ROWS - 1][col] == 'O')
                Capture(board, ROWS -1, col);
        }

        //Depois dos 2 fors acima, todas as celulas que nao podem ser capturadas na logica do exercicio, terao sido capturadas na nossa logica reversa, essas celulas que foram capturadas, mudaram para "T" de temp, ou seja, todas as celulas com "T" significam celulas que originalmente tinham "O" e chegamos a conclusao que elas NAO poderiam ser capturadas.
        for (int row = 0; row < ROWS; row++) //Agora nos iremos iterar sob TODO o grid, por completo.
        {
            for (int col = 0; col < COLS; col++)
            {
                if (board[row][col] == 'O') //Todas as celulas desse grid alterado que tiverem "O" são as celulas que justamente podem ter ser capturadas, pois as celulas "o" que nao poderiam ser capturadas, nesse momento ja estarao transformadas em "T", sendo assim, todas que restaram com "O" são as que podem ser capturadas, portanto, transformamos elas em "x" como capturadas.
                    board[row][col] = 'X';
                else if (board[row][col] == 'T') //E agora, todas as celulas que tem "T", ou seja, todas as celulas que originalmente não poderiam ser capturadas, sao transformadas de volta em "O", pois esse é o resultado final que o exercicio quer, em suma, quem era "T" é pq nao pode ser capturado, portanto, transformamos de volta em "O"
                    board[row][col] = 'O';
            }
        }
    }

    //A intenção dessa função DFS é capturar todas as celulas que não poderão ser capturadas por "X" pois estão posicionadas na borda, portanto, nao podem ter vizinhos x suficientes, ou sao vizinhos de "o" que estão na borda, portanto nao podem ser capturadas tbm. Sendo assim, iremos transformar todas essas celulas que tem valor "O" nesse cenario em "T" de temp, para podermos diferenciar essas celulas incapturaveis das celulas que realmente serao capturadas por "x"
    private void Capture(char[][] board, int row, int col) 
    {
        if (row < 0 || col < 0 || row == ROWS || col == COLS || board[row][col] != 'O') //Esse é o nosso base-case, se a celula que estamos analisando sair fora dos limites do array (row/col negativo ou row/col maior que o limite), OU, se a celula não for "O", pois logicamente nao vamos capturar uma celula X, so iremos capturar vizinhos e celulas com "O" 
            return;

        board[row][col] = 'T'; //Como foi dito acima, iremos transformar todas as celuas incapturaveis em "T" de temp, para diferenciar os "O" incapturveis, dos "O" que serão capturados, que é o objetivo do exercicio (mais a frente na logica transformaremos os "T" de volta para "O", apos transformar os "O" capturaveis em 'X')
        
        //Vamos ver todos os vizinhos das celulas capturadas transformadas em "T", para transformar os vizinhos de "T" em mais "T", ate acabarmos de transformar todas as celulas incapturaveis por 'x'.
        Capture(board, row + 1, col);
        Capture(board, row - 1, col);
        Capture(board, row, col + 1);
        Capture(board, row, col - 1);
    }
}
