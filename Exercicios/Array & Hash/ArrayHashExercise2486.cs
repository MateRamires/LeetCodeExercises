namespace Exercicios.Array___Hash;

public class ArrayHashExercise2486
{
    public int AppendCharacters(string s, string t)
    {
        int substringReaderPointer = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == t[substringReaderPointer]) 
            {
                substringReaderPointer++;
            }

            if (substringReaderPointer == t.Length)
                return 0;
        }

        return t.Length - substringReaderPointer;
    }
}
