namespace Exercicios.Two_Pointers;

public class TwoPointers121Redone
{
    public int MaxProfit(int[] prices)
    {
        int leftPointer = 0;
        int rightPointer = 1;
        int maximumProfit = 0;

        while (rightPointer < prices.Length) 
        {
            if (prices[leftPointer] < prices[rightPointer])
            {
                maximumProfit = Math.Max(maximumProfit, prices[rightPointer] - prices[leftPointer]);
            }
            else 
            {
                leftPointer = rightPointer;
            }
            rightPointer++;
        }

        return maximumProfit;
    }
}
