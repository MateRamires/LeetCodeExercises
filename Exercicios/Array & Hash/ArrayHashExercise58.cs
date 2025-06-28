namespace Exercicios.Array___Hash;

public class ArrayHashExercise58
{
    public int LengthOfLastWord(string s)
    {
        int lenghtOfCurrentWord = 0;
        s = s.Trim();
        for (int i = 0; i < s.Length; i++) 
        {
            if (s[i] == ' ') 
            {
                lenghtOfCurrentWord = 0;
                continue;
            }

            lenghtOfCurrentWord++;
        }

        return lenghtOfCurrentWord;
    }
}
