namespace Exercicios.Array___Hash;

public class ArrayHashExercise3110
{
    public int ScoreOfString(string s)
    {
        int score = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (i + 1 < s.Length)
            {
                score += Math.Abs(s[i] - s[i + 1]);
            }
        }
        return score;
    }
}
