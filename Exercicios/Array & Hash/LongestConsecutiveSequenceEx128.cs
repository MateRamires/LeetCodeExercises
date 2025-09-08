namespace Exercicios.Array___Hash;

public class LongestConsecutiveSequenceEx128
{
    public int LongestConsecutive(int[] nums)
    {
        var hashSet = new HashSet<int>(nums);

        int longestSequence = 0;
        foreach (var num in hashSet) 
        {
            if (!hashSet.Contains(num - 1)) 
            {
                int currentLength = 1;
                while (hashSet.Contains(num + currentLength)) 
                    currentLength++;
                
                longestSequence = Math.Max(longestSequence, currentLength);
            }
        }

        return longestSequence;
    }
}
