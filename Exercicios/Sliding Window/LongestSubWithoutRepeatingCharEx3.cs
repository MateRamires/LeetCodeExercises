namespace Exercicios.Sliding_Window;

public class LongestSubWithoutRepeatingCharEx3
{
    public int LengthOfLongestSubstring(string s)
    {
        int leftPointer = 0;
        int longestSubstring = 0;
        var hashSet = new HashSet<char>();
        for (int rightPointer = 0; rightPointer < s.Length; rightPointer++)
        {
            while (hashSet.Contains(s[rightPointer])) 
            {
                hashSet.Remove(s[leftPointer]);
                leftPointer++;
            }

            longestSubstring = Math.Max(longestSubstring, rightPointer - leftPointer + 1);

            hashSet.Add(s[rightPointer]);
        }

        return longestSubstring;
    }
}
