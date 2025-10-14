namespace Exercicios.Sliding_Window;

public class LongestSubWithoutRepeatingCharEx3
{
    public int LengthOfLongestSubstring(string s)
    {
        int leftPointer = 0;
        int longestSubstring = 0;
        var hashSetChars = new HashSet<char>();
        for (int rightPointer = 0; rightPointer < s.Length; rightPointer++)
        {
            while (hashSetChars.Contains(s[rightPointer])) 
            { 
                hashSetChars.Remove(s[leftPointer]);
                leftPointer++;
            }

            longestSubstring = Math.Max(longestSubstring, rightPointer - leftPointer + 1);
            hashSetChars.Add(s[rightPointer]);
        }

        return longestSubstring;
    }
}
