namespace Exercicios.Sliding_Window;

public class BestTimeBuySellStockEx121
{
    public int MaxProfit(int[] prices)
    {
        int leftPointer = 0;
        int maxProfit = 0;
        for (int rightPointer = 1; rightPointer < prices.Length; rightPointer++)
        {
            if (prices[rightPointer] > prices[leftPointer])
            {
                maxProfit = Math.Max(maxProfit, prices[rightPointer] - prices[leftPointer]);
            }
            else 
            {
                leftPointer = rightPointer;
            }
        }
        return maxProfit;
    }
}
