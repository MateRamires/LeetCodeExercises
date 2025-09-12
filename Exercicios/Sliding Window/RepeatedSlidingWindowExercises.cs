namespace Exercicios.Sliding_Window;

public class RepeatedSlidingWindowExercises
{
    public int LengthOfLongestSubstring(string s)
    {
        int leftPointer = 0;
        var hashSet = new HashSet<char>();
        var longestString = 0;
        for (int rightPointer = 0; rightPointer < s.Length; rightPointer++) 
        {
            while (hashSet.Contains(s[rightPointer]))  
            { 
                hashSet.Remove(s[leftPointer]);
                leftPointer++;
            }

            longestString = Math.Max(longestString, rightPointer - leftPointer + 1);
            hashSet.Add(s[rightPointer]);
        }
        return longestString;
    }
}
