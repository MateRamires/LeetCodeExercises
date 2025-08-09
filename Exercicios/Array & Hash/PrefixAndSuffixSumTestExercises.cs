namespace Exercicios.Array___Hash;

public class PrefixAndSuffixSumTestExercises
{
    public int[] PrefixAndSuffixBasics(int[] nums) 
    { 
        int n = nums.Length;
        var prefix = new int[n];
        var suffix = new int[n];
        var answer = new int[n];

        prefix[0] = 0; //Como estamos calculando apenas os valores anteriores ao valor atual no prefix, entao o valor anterior ao primeiro valor do array eh 0, por isso a primeira posicao do prefix array sempre sera 0.
        suffix[n - 1] = 0; //Mesma coisa do comentario acima, mas como eh suffix entao o ultimo valor eh zero, pois estamos calculando apenas valores apos o valor atual, o proprio valor nao eh considerado para ele mesmo, entao independente de qual numero seja o ultimo, no suffix, o valor dessa posicao sera 0 (equivalente a nada, pois nao ha nada depois do ultimo valor)

        for (int i = 1; i < n; i++)
            prefix[i] = nums[i - 1] + prefix[i - 1];

        for(int i = n - 2; i >= 0; i--)
            suffix[i] = nums[i + 1] + suffix[i + 1];

        for (int i = 0; i < n; i++) 
            answer[i] = prefix[i] + suffix[i];

        return answer;
    }
}
