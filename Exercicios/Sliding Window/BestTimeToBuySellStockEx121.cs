namespace Exercicios.Sliding_Window;

public class BestTimeToBuySellStockEx121
{
    public int MaxProfit(int[] prices)
    {
        int leftPointer = 0, rightPointer = 1;
        int maximumProfit = 0;
        while (rightPointer < prices.Length) 
        {
            if (prices[leftPointer] < prices[rightPointer]) //Comparamos o MENOR valor (leftPointer sempre sera o menor valor ate a o momento) com o proximo valor (rightPointer)
            {
                maximumProfit = Math.Max(maximumProfit, prices[rightPointer] - prices[leftPointer]);
            }
            else //Caso o proximo valor seja menor que o menor valor ate agora, entao o menor valor ate agora eh esse proximo valor, por isso fazemos left = right
            {
                leftPointer = rightPointer;
            }
            rightPointer++; //E o right sempre vai se mexer para frente, independente dos casos.
        }
        return maximumProfit;
    }
}
