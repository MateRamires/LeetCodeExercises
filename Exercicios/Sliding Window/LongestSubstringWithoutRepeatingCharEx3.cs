namespace Exercicios.Sliding_Window;

public class LongestSubstringWithoutRepeatingCharEx3
{
    public int LengthOfLongestSubstring(string s)
    {
        int leftPointer = 0;
        var hashSet = new HashSet<char>();
        int res = 0;
        for (int rightPointer = 0; rightPointer < s.Length; rightPointer++)
        {
            while (hashSet.Contains(s[rightPointer])) 
            { 
                hashSet.Remove(s[leftPointer]); //Nos vamos remover todas as letra, ate que a ultima removida sera a condicao do while.
                leftPointer++;
            }

            hashSet.Add(s[rightPointer]);
            res = Math.Max(res, rightPointer - leftPointer + 1);
        }

        return res;
    }
}
