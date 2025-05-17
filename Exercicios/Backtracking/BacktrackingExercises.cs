namespace Exercicios.Backtracking;

public class BacktrackingExercises
{
    //Ex 78
    public IList<IList<int>> Subsets(int[] nums)
    {
        var res = new List<IList<int>>(); //Essa sera nossa lista contendo todos os subsets
        var subset = new List<int>(); //Esse sera um unico subset, por vez.
        DfsEx78(nums, 0, subset, res);
        return res;
    }

    private void DfsEx78(int[] nums, int i, List<int> subset, List<IList<int>> res) 
    {
        if (i >= nums.Length) //Esse eh o base case do DFS.
        {
            res.Add(new List<int>(subset)); //Quando atingirmos o base-case, nos adicionamos o subset em questao a nossa lista de resultado
            return; //E retornamos, pois chegamos ao fim desse fio.
        }

        //O codigo abaixo representa o cenario onde adicionamos o numero em questao, pois pra cada numero teremos 2 possibilidades, adiciona-lo ao subset, ou nao adiciona-lo.
        subset.Add(nums[i]); //Aqui nos vamos adicionar o numero ao subset.
        DfsEx78(nums, i + 1, subset, res); //E aqui nos vamos enviar esse subset com o numero adicionado e o "i" incrementado, para que possamos analisar o proximo numero de nums.

        //Ja esse codigo representa o cenario onde nao vamos adicionar o numero atual ao subset, como ja adicionamos ele na linha anterior, agora nos vamos remove-lo
        subset.RemoveAt(subset.Count - 1); //Removendo o numero mais recente, no caso, o que acabou de ser adicionado.
        DfsEx78(nums, i + 1, subset, res); //E agora vamos para o proximo numero do array de inteiros, so que dessa vez sem o numero anterior no subset, e assim vao se formando todos os subsets diferentes.
    }

    //Ex 39
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> res = new List<IList<int>>();
        backtrackEx39(0, new List<int>(), 0, candidates, target, res);
        return res;
    }

    public void backtrackEx39(int i, List<int> cur, int total, int[] nums, int target, List<IList<int>> res)
    {
        if (total == target) //A variavel total vai guardar o valor da soma do nosso array current, caso total seja exatamente igual ao target, podemos adicionar o array como uma das possiblidades de soma de numeros para chegar no valor target.
        {
            res.Add(cur.ToList()); //Adicionamos o current com os valores para nossa lista resposta.
            return; //E podemos dar return pois esse if eh um "base-case".
        }

        if (total > target || i >= nums.Length)  //Agora, caso o total ultrapasse o target, ai entramos nesse outro "base-case", so que nesse caso, nao vamos adicionar a nossa lista de respostas. Alem disso, esse base-case vai verificar se nosso i ultrapassou o array, pois se o i for maior que o array de candidatos, ai nao tem mais numero para se analisar e acabou o processamento.
            return;

        //Nessas 2 linhas temos o caso onde vamos adicionar o numero atual no nosso current.
        cur.Add(nums[i]); //Aqui adicionamos o numero atual a nossa resposta.
        backtrackEx39(i, cur, total + nums[i], nums, target, res); //E comecamos a recursao, vamos continuar analisando o numero atual (pois podemos repetir o mesmo numero infinitas vezes), passando a lista curr, que contera o numero que acabamos de adicionar, o total sera ele mesmo + o proprio numero que estamos analisando (pois vamos somando esse numero ate chegar ou ultrapassar o target), e por fim passamos o mesmo array de numeros, o mesmo target e a lista response final.

        //Ja nessas 2 linhas, nos nao vamos mais adicionar o valor atual ao current, e vamos andar uma casa no array de candidatos, para ir ao proximo numero.
        cur.Remove(cur.Last()); //Removemos o numero que adicionamos acima, pois nesse caso, nao vamos mais adicionar o mesmo numero mais, vamos ir para o proximo.
        backtrackEx39(i + 1, cur, total, nums, target, res); //A diferenca dessa chamada de recursao da de cima eh que aqui nao incrementamos a variavel total, pois nao adicionamos o numero atual, e alem disso, colocamos i + 1, pois vamos apartir daqui comecar a analisar o proximo numero do array nums/candidates.
    }

    //Ex 40
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        List<IList<int>> res = new List<IList<int>>();
        Array.Sort(candidates); //Nos precisamos dar um sort nos candidates pois no cenario onde escolhemos PULAR um numero, nos devemos pular qualquer outra duplicata desse numero tambem, pois fazendo isso, nos evitamos acontecer de uma duplicata repetir a mesma tentativa do numero original, algo como [1,7] e como tem uma duplicata de 1, teremos [7,1]. Embora os 2 usem numeros 1's diferentes, isso nao eh valido para esse exercicio, por isso, temos que pular todos os 1's quando decidimos pular um "1", e a forma mais facil de fazer isso, eh dando um sort no array, ja que todas as duplicatas ficaram juntas.
        backtrackEx40(0, new List<int>(), 0, candidates, target, res);
        return res;
    }

    private void backtrackEx40(int i, List<int> cur, int total, int[] nums, int target, List<IList<int>> res)
    {
        if (total == target) //A variavel total vai guardar o valor da soma do nosso array current, caso total seja exatamente igual ao target, podemos adicionar o array como uma das possiblidades de soma de numeros para chegar no valor target.
        {
            res.Add(cur.ToList()); //Adicionamos o current com os valores para nossa lista resposta.
            return; //E podemos dar return pois esse if eh um "base-case".
        }

        if (total > target || i >= nums.Length)  //Agora, caso o total ultrapasse o target, ai entramos nesse outro "base-case", so que nesse caso, nao vamos adicionar a nossa lista de respostas. Alem disso, esse base-case vai verificar se nosso i ultrapassou o array, pois se o i for maior que o array de candidatos, ai nao tem mais numero para se analisar e acabou o processamento.
            return;

        //Nessas 2 linhas temos o caso onde vamos adicionar o numero atual no nosso current.
        cur.Add(nums[i]); //Aqui adicionamos o numero atual a nossa resposta.
        backtrackEx40(i + 1, cur, total + nums[i], nums, target, res); //E comecamos a recursao, difernete do ex de cima, aqui ja vamos passar i + 1 pois nao podemos repetir o numero. Depois passamos a lista curr, que contera o numero que acabamos de adicionar, o total sera ele mesmo + o proprio numero que estamos analisando (pois vamos somando esse numero ate chegar ou ultrapassar o target), e por fim passamos o mesmo array de numeros, o mesmo target e a lista response final.

        //Ja nessas linhas, nos nao vamos mais adicionar o valor atual ao current, e vamos andar casas no array candidantes o suficiente para pularmos todos os numeros repetidos, pois se ja pulamos um valor, temos de pular ele novamente, por isso demos um sort.
        cur.Remove(cur.Last()); //Removemos o numero que adicionamos acima, pois nesse caso, nao vamos mais adicionar o mesmo numero mais, vamos ir para o proximo.
        while (i + 1 < nums.Length && nums[i] == nums[i + 1]) //Aqui nos estamos pulando todas as duplicatas, entao se o array sorteado for [1,1,1,2] essa linha ira pular todos os 1's e parara no ultimo valor duplicado, e por fim iremos chamar a recursao passando i + 1, pulando de vez todos os 1's. E tambem temos que checar se i + 1 for maior que o tamanho do array para nao sairmos para fora do array e recebemos uma exception.
            i++;
        backtrackEx40(i + 1, cur, total, nums, target, res); //Aqui passamos i + 1 para irmos para o proximo numero nao-duplicata, e o total nao eh incrementado, pois nao adicionamos nada nesse cenario, diferente do cenario de cima.
    }

    //Ex 46
    public IList<IList<int>> Permute(int[] nums)
    {
        List<IList<int>> res = new List<IList<int>>();
        BacktrackEx46(new List<int>(), nums, new bool[nums.Length], res);
        return res;

    }
    private void BacktrackEx46(List<int> perm, int[] nums, bool[] pick, List<IList<int>> res)
    {
        if (perm.Count == nums.Length) //Esse eh o base case, se nossa permutacao atual chegar ao mesmo tamanho do array nums, entao acabou a permutacao.
        {
            res.Add(new List<int>(perm)); //acabando a permutacao, adicionamos ela a nossa lista de respostas
            return; //Por fim, acabamos o processo.
        }

        for (int i = 0; i < nums.Length; i++) //Vamos passar por todos os numeros do array.
        {
            if (!pick[i]) //Aqui estamos checando se o numero que estamos analisando ja esta na nossa permutacao
            {
                perm.Add(nums[i]); //Adicionamos o numero atual a nossa permutacao
                pick[i] = true; //E dizemos que esse numero ja foi adicionado na permutacao, para nao adicionarmos novamente nas proximas iteracoes
                BacktrackEx46(perm, nums, pick, res); //Aqui chamamos o backtracking novamente, dessa vez, com a unica diferenca que passamos a permutacao atual, com o numero que foi adicionado.
                
                perm.RemoveAt(perm.Count - 1); //Por fim, removemos o numero para continuarmos o backtrack
                pick[i] = false; //E agora indicamos que essa posicao eh falso, pois removemos o numero
            }
        }
    }

    //Ex 90
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        List<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums); //Para pularmos os numeros duplicados, teremos que dar um sort para garantir que todas as duplicatas fiquem juntas.
        BacktrackEx90(0, new List<int>(), nums, res);
        return res;
    }
    private void BacktrackEx90(int i, List<int> subset, int[] nums, List<IList<int>> res)
    {
        if (i == nums.Length) //Nosso base-case. A recursao ira rodar ate que i tenha o mesmo tamanho que o array de numeros, quando isso acontecer, sabemos que chegamos ao ultimo numero do array e nao ha nada mais a adicionar no subset.
        {
            res.Add(new List<int>(subset));
            return;
        }

        //Cenario de adicionar o numero atual
        subset.Add(nums[i]); //Adicionamos o numero atual ao subset
        BacktrackEx90(i + 1, subset, nums, res); //Passamos para a recursao esse subset e partimos para o proximo numero do array.

        //Cenario de nao adicionar o numero atual
        subset.RemoveAt(subset.Count - 1);

        //Quando estamos no cenario de nao adicionar o numero atual, nos temos que garantir que nenhuma duplicata do numero atual seja adiciona tambem, se nao quebra o proposito, entao temos que rodar esse while que ira pular todos os numeros repetidos ao numero atual e o proprio numero atual.
        while (i + 1 < nums.Length && nums[i] == nums[i + 1]) //Aqui checamos se o valor de i == i + 1, se for, adicionamos mais 1 ao i para pularmos mais uma casa, ate acabar as duplicatas. Alem disso, temos que checar primeiro se i + 1 >= nums.length, pois se for, ai quer dizer que saimos fora do limite do array.
            i++;

        BacktrackEx90(i + 1, subset, nums, res); //Por fim, chamamos a recursao, com i + 1, pois no while acima, o i ficara parado exatamente no ultimo valor duplicado, ai fazemos um ultimo i + 1 para pular de vez todos os numeros duplicados.
    }

    //Ex 79
    public bool Exist(char[][] board, string word)
    {
        int ROWS = board.Length; //Quantidade de linhas que o tabulero tem
        int COLS = board[0].Length; //Quantidade de colunas que o tabulero tem

        for (int row = 0; row < ROWS; row++) //Nos teremos que percorrer TODO o tabuleiro, pois o inicio da palavra pode estar em qualquer posicao, ate mesmo na ultima coluna da ultima linha.
        {
            for (int column = 0; column < COLS; column++) 
            {
                var path = new HashSet<(int, int)>(); //Criamos nosso path, que durante a recursao ira guardar todos os "nodes/casas" que ja visitamos
                if (DFS79(board, word, row, column, 0, path)) //Nos iremos chamar nosso DFS, nossa recursao para TODAS as casas, pois a palavra pode se iniciar de qualquer lugar, aqui nesse if, caso algum dos DFS que chamamos retorne true, entao a palavra foi encontrada no tabuleiro, logo, retornamos true aqui tambem.
                    return true;
            }
        }
        return false; //Caso atravessemos todo o tabuleiro e nenhum entrar em nossa condicao de o DFS retornar true, entao a palavra nao exite no tabuleiro, logo retornamos false.
    }

    private bool DFS79(char[][] board, string word, int row, int column, int currentCharInWord, HashSet<(int, int)> path) 
    {
        int ROWS = board.Length;
        int COLS = board[0].Length;

        if (currentCharInWord == word.Length) //A variavel currentCharInWord como o nome ja diz acompanha cada caractere em word, para checar se a palavra existe em board, sendo assim, se currentCharInWord tiver o mesmo valor que o tamanho da nossa word, isso significa que TODOS os caracteres foram encontrados em board, ou seja, a palavra de fato existe se chegarmos ate aqui, portanto, retornamos true.
            return true;

        if (row < 0 || column < 0 || row >= ROWS || column >= COLS || //aqui checaremos todos os possiveis cenarios que indicam que a palavra nao foi encontrada nessa iteracao. Primeiramente nessa linha checamos se a nossa row ou col atual saiu dos limites do array, se row < 0 entao a row esta como -1, que nao existe no array, se row for maior que ROWS (total de rows no tabuleiro) ele tambem saiu dos limites, mesma coisa para colunas.
            board[row][column] != word[currentCharInWord] || //Outro cenario eh se a casa que estamos analisando, ou seja, o caracter que estamos analisando do tabuleiro nao corresponder com o caracter que eh esperado da palavra word, ai obviamente, a palavra nao sera formada se tiver um caractere diferente, logo retorn falso.
            path.Contains((row, column))) //Por fim, o ultimo cenario que retorna falso, eh se a casa que estamos analisando agora ja tiver sido visitada anteriormente, pois a mesma casa nao pode ser visitada mais de uma vez para compor a palavra final, logo, falso.
        {
            return false;
        }

        path.Add((row, column)); //Depois das verificacoes, se nao retornar nem true, nem false, ai adicionamos essa letra (ou casa) ao path, e se o codigo chegou ate aqui, isso quer dizer que por enquanto estamos no caminho correto para achar a palavra, pois a letra atual, de fato esta na posicao esperada para formar a word que buscamos.
        bool res = DFS79(board, word, row + 1, column, currentCharInWord + 1, path) || //Aqui comecamos a recursao, nos vamos mover o ponteiro nas quatro direcoes, pois a continuacao (proximo caractere) pode estar atras, embaixo na frente ou em cima do caractere atual, entao checamos os 4 lados.
                   DFS79(board, word, row - 1, column, currentCharInWord + 1, path) ||
                   DFS79(board, word, row, column + 1, currentCharInWord + 1, path) ||
                   DFS79(board, word, row, column - 1, currentCharInWord + 1, path);

        path.Remove((row, column)); //Aqui nos removemos o node/caractere atual do nosso path, para podermos fazer o backtrack, se nao removermos, o caractere atual ficara sempre em path, mas nao pode, pois agora que visitamos esse node, temos que tirar ele para futuras iteracoes.

        return res; //Retornamos res, que sera true ou false, se ALGUM dos dfs retornar true, entao a palavra foi encontrada, independente se apenas um dos 4 caminhos achou true, a palavra existe, portanto true. Mas se os 4 caminhos cairem em false, ai ficara false || false || false || false, portanto, res sera false, e voltaremos para nossa funcao incial (Exist()) para testar proximos nodes como ponto de partida.
    }

    //Ex 131
    public IList<IList<string>> Partition(string s)
    {
        List<IList<string>> res = new List<IList<string>>();
        List<string> currentPartition = new List<string>();
        DFS131(0, s, currentPartition, res);
        return res;
    }

    private void DFS131(int currentIndex, string s, List<string> currentPartition, List<IList<string>> res) 
    {
        if (currentIndex >= s.Length) //Base case, se o caractere que estamos analisando no momento for maior que o tamanho da string original, entao saimos fora dos limites da string, portanto paramos aqui.
        {
            res.Add(new List<string>(currentPartition)); //Se a string chegou a bater nesse base-case, eh pq ela eh de fato um palindromo, pois chegamos na ultima letra. portanto podemos adiciona-la na nossa resposta.
            return;
        }

        for (int j = currentIndex; j < s.Length; j++) 
        {
            if (isPalindrome(s, currentIndex, j)) //Temos que chegar se essa substring que estamos analisando eh um palindrome e so entra no if, continuando a recursao, se de fato for um palindromo.
            {
                currentPartition.Add(s.Substring(currentIndex, j - currentIndex + 1)); //Adicionamos a substring atual a nossa particao atual, pois sabemos que ela eh um palindromom, por ter passado pela condicao acima.
                DFS131(j + 1, s, currentPartition, res); //Aqui nos chamamos a recursao, onde ele vai mover o currentIndex em uma casa pra frente a partir de J/
                currentPartition.RemoveAt(currentPartition.Count - 1); //Tiramos a particao que acabamos de adicionar para poder ir analisar outros cenarios.
            }
        }
    }

    private bool isPalindrome(string s, int leftP, int rightP) 
    {
        while (leftP < rightP) 
        {
            if (s[leftP] != s[rightP])
                return false;

            leftP++;
            rightP--;
        }
        return true;
    }

    //Ex 17
    public IList<string> LetterCombinations(string digits)
    {
        List<string> res = new List<string>();
        Dictionary<char, string> digitToChar = new Dictionary<char, string> { //Mapeia cada digito para suas respectivas letras, isso tem que ser hard-codado.
            {'2', "abc"}, {'3', "def"}, {'4', "ghi"}, {'5', "jkl"},
            {'6', "mno"}, {'7', "qprs"}, {'8', "tuv"}, {'9', "wxyz"}
        };

        if (digits.Length == 0) //Edge-case, caso digitos nao tenha nada, devolvemos res vazia, pois nao tem combinacoes nesse caso.
            return res;

        BacktrackEx17(0, "", digits, digitToChar, res); 
        return res;
    }

    private void BacktrackEx17(int i, string currentString, string digits, Dictionary<char, string> digitToChar, List<string> res) 
    {
        if (currentString.Length == digits.Length) //Nosso base-case, caso a string atual tenha exatamente o mesmo tamanho que a quantidade de digitos, entao chegamos ao fim, pois se tem 2 digitos "25" e duas letras, entao acabou essa string atual e podemos adiciona-la a res como uma das possiveis variacoes.
        {
            res.Add(currentString);
            return; //Acaba a recursao.
        }

        foreach (char c in digitToChar[digits[i]]) //Aqui a logica sera a seguinte, faremos um for passando por todos os caracteres de digitsToChar na posicao "numero atual da string digits" ou seja, se o numero atual da string digits for 2, entao o for ficara assim "char c in abc" ou seja, esse for ira passar pelos 3 caracteres possiveis da letra 2.
        {
            BacktrackEx17(i + 1, currentString + c, digits, digitToChar, res); //A partir disso, chamaremos o backtrack e moveremos o indice para + 1, para podermos analisar o proximo digito, por exemplo o digito 3, e ao chamar o backtracking novamente, nos passamos como parametro a currentString + a letra que esta sendo analisada, sendo assim, ele chegara na proxima chamada da recursoa com o valor "a" por exemplo, e ira analisar as letras do proximo digito, e fara o mesmo processo de foreach para cada uma das 3 letras do proximo digito.
        }
    }
}
