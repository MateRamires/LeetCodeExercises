namespace Exercicios.Stack;

public class StackExercise1475Monotonic
{
    public int[] FinalPrices(int[] prices)
    {
        int[] answer = new int[prices.Length];
        Stack<int> monotonic = new Stack<int>();

        for (int i = prices.Length - 1; i >= 0; i--)
        {
            while(monotonic.Count > 0 && monotonic.Peek() > prices[i])
                monotonic.Pop();

            if(monotonic.Count == 0)
                answer[i] = prices[i];
            else
                answer[i] = prices[i] - monotonic.Peek();

            monotonic.Push(prices[i]);
        }

        return answer;
    }
}
