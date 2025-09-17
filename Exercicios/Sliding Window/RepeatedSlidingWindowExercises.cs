namespace Exercicios.Sliding_Window;

public class RepeatedSlidingWindowExercises
{
    public int LengthOfLongestSubstring(string s)
    {
        var hashSet = new HashSet<int>();
        int leftPointer = 0;
        int longestSubstring = 0;

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
