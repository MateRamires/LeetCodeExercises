namespace Exercicios.Array___Hash;

public class ArrayHashExercise14
{
    public string LongestCommonPrefix(string[] strs)
    {
        for (int i = 0; i < strs[0].Length; i++) 
        { 
            foreach (string str in strs) 
            { 
                if(i == str.Length || str[i] != strs[0][i])
                    return str.Substring(0, i);
            }
        }

        return strs[0];
    }

    //Time complexity: (n * m) onde "n" eh o tamanho da primeira palavra e "m" a quantidade total de palavras no array.
}
