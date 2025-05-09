namespace Exercicios;

public class SlidingWindowExercises
{
    //Ex 121
    public int MaxProfit(int[] prices)
    {
        var leftPointer = 0;
        var rightPointer = 1;
        var maxProfit = 0;
        while (rightPointer < prices.Length) 
        {
            if (prices[leftPointer] < prices[rightPointer])
            {
                int profit = prices[rightPointer] - prices[leftPointer];
                maxProfit = Math.Max(maxProfit, profit);
            }
            else 
            {
                leftPointer = rightPointer;
            }
            rightPointer++;
        }
        return maxProfit;
    }

    //Ex 3
    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> charSet = new HashSet<char>();
        int leftPointer = 0;
        int res = 0;

        for (int rightPointer = 0; rightPointer < s.Length; rightPointer++) 
        {
            while (charSet.Contains(s[rightPointer])) 
            {
                charSet.Remove(s[leftPointer]);
                leftPointer++;
            }
            charSet.Add(s[rightPointer]);
            res = Math.Max(res, rightPointer - leftPointer + 1);
        }
        return res;
    }

    //Ex 424
    public int CharacterReplacement(string s, int k)
    {
        int res = 0;
        HashSet<char> charSet = new HashSet<char>(s);

        foreach (char c in charSet) 
        {
            int count = 0, leftPointer = 0;
            for (int rightPointer = 0; rightPointer < s.Length; rightPointer++)
            {
                if (s[rightPointer] == c)
                    count++;

                while ((rightPointer - leftPointer + 1) - count > k)
                {
                    if (s[leftPointer] == c)
                        count--;

                    leftPointer++;
                }
                res = Math.Max(res, rightPointer - leftPointer + 1);
            }
        }
        return res;
    }

    //Ex 567
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length) //Nos temos que checar se ha uma permutacao de s1 em s2, se s1 for maior que s2, isso nunca sera verdadeiro.
            return false;

        int[] s1Count = new int[26]; //Criaremos um array que tera a contagem de caracteres em cada string, cada letra representada pela sua posicao, entao se a posicao 0 tiver valor = 2, isso significa que temos 2 a's.
        int[] s2Count = new int[26]; //Mesma coisa para a segunda string.
        for (int i = 0; i < s1.Length; i++) //Vamos iterar pelos 26 elementos, que no caso sao os 26 caracteres possiveis que as strings podem ter. 
        {
            s1Count[s1[i] - 'a']++; //Aqui a logica eh a seguinte, cada posicao do array sera uma letra, s1[i] - a, basicamente faz uma conta de menos com assci, entao 'c' tem o valor assci 99 e 'a' tem valor 97, nessa conta faremos 99 - 97, que da 2, ou seja, na segunda posicao teremos 1, que significa que temos 1 'c' na string. Esse codigo no fim retornara esse array com as posicoes referentes as letras com o tanto de letras que tem, entao se tem 3 c's teremos a posicao 2 com valor 3, e assim por diante.
            s2Count[s2[i] - 'a']++;
        }

        int matches = 0; //Essa sera a variavel que iremos acompanhar para saber se ha alguma permutacao de s1 em s2.
        for (int i = 0; i < 26; i++) 
        {
            if (s1Count[i] == s2Count[i])
                matches++; //Aqui nos acharemos a quantidade de matches inicial entre as 2 strings, se s1[0] = 1 e s2[0] = 1, temos um match, pois ambos tem exatamente 1 'a' e assim por diante em todas as letras, obviamente que na maioria dos casos nao teremos 26 matches, que eh o que estamos procurando, pois algumas letras terao mais em uma string que na outra.
        }

        int leftP = 0; //Ponteiro esquerdo
        for (int rightP = s1.Length; rightP < s2.Length; rightP++) //Nossa janela (esse ex eh de sliding window) deve ir inicialmente de 0 (leftP) ate o total de caracteres que tem no s1 (rightP) pois precisamos achar uma permutacao de s1 em s2, e essa permutacao, o que importa eh se os caracteres sao os mesmos e na mesma quantidade, a ordem nao importa, mas eles precisam estar juntos, por isso a janela deve ter o tamanho exato de s1, pois o tamanho eh importante.
        {
            if (matches == 26)
                return true;

            int index = s2[rightP] - 'a';
            s2Count[index]++;
            if (s1Count[index] == s2Count[index])
            {
                matches++;
            }
            else if (s1Count[index] + 1 == s2Count[index])
            {
                matches--;
            }

            index = s2[leftP] - 'a';
            s2Count[index]--;
            if (s1Count[index] == s2Count[index])
            {
                matches++;
            }
            else if (s1Count[index] - 1 == s2Count[index])
            {
                matches--;
            }
            leftP++;
        }
        return matches == 26; 
    }
}
