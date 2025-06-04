using System.Diagnostics.Metrics;

namespace Exercicios.Array___Hash;

public class ArrayHashExercise242Redone
{
    public bool IsAnagram(string s, string t)
    {
        if(s.Length != t.Length)
            return false;

        Dictionary<char, int> lettersS = new Dictionary<char, int>();
        Dictionary<char, int> lettersT = new Dictionary<char, int>();

        foreach (char c in s) 
        { 
            if(!lettersS.ContainsKey(c))
                lettersS[c] = 0;

            lettersS[c]++;
        }

        foreach (char c in t) 
        {
            if (!lettersT.ContainsKey(c))
                lettersT[c] = 0;
            lettersT[c]++;
        }

        return lettersS.Count == lettersT.Count && !lettersS.Except(lettersT).Any(); //Puro suco do linq. Depois de termos os 2 hashMaps com as letras exatas e quantidades exatas, comparamos primeiro se os 2 hashMaps tem a mesma quantidade de elementos, pois se um tiver mais elementos que o outro, significa que ha uma letra a mais em um ou no outro. Se a quantidade de letras for igual, agora temos que ver se as letras em si sao iguais e se elas tem os valores iguais (2 c's e 2 a's). Pra isso usamos except, que checa se ha algum chave-valor em um dict que nao tem no outro, e colocamos o any, pra devolver um valor booleano com base nisso, entao se houver um chave-valor em um dict e no outro nao, o any vai dar true, com o ! na frente, ficara false, portanto, falso, nao sao anagramas, agora caso os 2 sejam anagramas, ai nao teria nenhum except, pois os 2 dicts tem exatamente os mesmos chaves-valor iguais.
    }
}
