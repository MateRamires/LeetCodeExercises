namespace Exercicios;

public class SlidingWindowExercises
{
    //Ex 121
    public int MaxProfit(int[] prices)
    {
        var leftPointer = 0;
        var rightPointer = 1;
        var maxProfit = 0;
        while (rightPointer < prices.Length) 
        {
            if (prices[leftPointer] < prices[rightPointer])
            {
                int profit = prices[rightPointer] - prices[leftPointer];
                maxProfit = Math.Max(maxProfit, profit);
            }
            else 
            {
                leftPointer = rightPointer;
            }
            rightPointer++;
        }
        return maxProfit;
    }

    //Ex 3
    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> charSet = new HashSet<char>();
        int leftPointer = 0;
        int res = 0;

        for (int rightPointer = 0; rightPointer < s.Length; rightPointer++) 
        {
            while (charSet.Contains(s[rightPointer])) 
            {
                charSet.Remove(s[leftPointer]);
                leftPointer++;
            }
            charSet.Add(s[rightPointer]);
            res = Math.Max(res, rightPointer - leftPointer + 1);
        }
        return res;
    }

    //Ex 424
    public int CharacterReplacement(string s, int k)
    {
        int res = 0;
        HashSet<char> charSet = new HashSet<char>(s);

        foreach (char c in charSet) 
        {
            int count = 0, leftPointer = 0;
            for (int rightPointer = 0; rightPointer < s.Length; rightPointer++)
            {
                if (s[rightPointer] == c)
                    count++;

                while ((rightPointer - leftPointer + 1) - count > k)
                {
                    if (s[leftPointer] == c)
                        count--;

                    leftPointer++;
                }
                res = Math.Max(res, rightPointer - leftPointer + 1);
            }
        }
        return res;
    }
}
