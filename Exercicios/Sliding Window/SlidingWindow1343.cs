namespace Exercicios.Sliding_Window;

public class SlidingWindow1343
{
    public int NumOfSubarrays(int[] arr, int k, int threshold)
    {
        int subArraysGreaterThanThreshold = 0;
        int currentWindowSum = 0;

        int leftPointer = 0;
        for (int rightPointer = 0; rightPointer < arr.Length; rightPointer++) 
        {
            currentWindowSum += arr[rightPointer];

            if (rightPointer - leftPointer + 1 == k) //Janela atual eh do tamanho K, iremos verificar se a soma dos valores dessa janela eh maior ou menor que threshold.
            {
                if (currentWindowSum / k >= threshold)
                    subArraysGreaterThanThreshold++;

                currentWindowSum -= arr[leftPointer];
                leftPointer++;
            }
        }

        return subArraysGreaterThanThreshold;
    }
}
