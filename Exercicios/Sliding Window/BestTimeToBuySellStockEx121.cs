namespace Exercicios.Sliding_Window;

public class BestTimeToBuySellStockEx121
{
    public int MaxProfit(int[] prices)
    {
        int leftPointer = 0;
        int maximumProfit = 0;
        for (int rightPointer = 1; rightPointer < prices.Length; rightPointer++)
        {
            if (prices[leftPointer] < prices[rightPointer])
            {
                maximumProfit = Math.Max(maximumProfit, prices[rightPointer] - prices[leftPointer]);
            }
            else
            {
                leftPointer = rightPointer;
            }
        }
        return maximumProfit;
    }
}
