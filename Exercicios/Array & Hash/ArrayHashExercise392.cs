namespace Exercicios.Array___Hash;

public class ArrayHashExercise392
{
    public bool IsSubsequence(string s, string t)
    {
        int substringReaderPointer = 0;
        int quantityOfMatchingCharacters = 0;

        if (s.Length == 0)
            return true;

        if (t.Length == 0)
            return false;

        for (int i = 0; i < t.Length; i++) 
        {
            if (t[i] == s[substringReaderPointer]) 
            {
                quantityOfMatchingCharacters++;
                substringReaderPointer++;
            }

            if (quantityOfMatchingCharacters == s.Length)
                return true;
        }

        return false;
    }
}
