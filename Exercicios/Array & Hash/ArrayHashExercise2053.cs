namespace Exercicios.Array___Hash;

public class ArrayHashExercise2053
{
    public string KthDistinct(string[] arr, int k)
    {
        var freq = new Dictionary<string, int>();
        foreach (var s in arr)
        {
            if (freq.ContainsKey(s))
                freq[s]++;
            else
                freq[s] = 1;
        }

        foreach (var s in arr)
        {
            if (freq[s] == 1)
            {
                k--;
                if (k == 0) return s;
            }
        }

        return "";
    }
}
