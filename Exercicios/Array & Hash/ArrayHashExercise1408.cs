namespace Exercicios.Array___Hash;

public class ArrayHashExercise1408
{
    public IList<string> StringMatching(string[] words)
    {
        Array.Sort(words, (a, b) => a.Length.CompareTo(b.Length));
        List<string> substrings = new List<string>();

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if (words[j].Contains(words[i])) 
                {
                    substrings.Add(words[i]);
                    break;
                }
            }
        }
        return substrings;
    }
}
