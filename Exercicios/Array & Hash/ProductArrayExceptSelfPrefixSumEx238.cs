namespace Exercicios.Array___Hash;

public class ProductArrayExceptSelfPrefixSumEx238
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        int[] prefixSum = new int[n]; //Produto de todos os numeros anteriores ao numero atual
        int[] suffixSum = new int[n]; //Produto de todos os numeros posteriores ao numero atual
        int[] answer = new int[n]; 

        prefixSum[0] = 1;
        for (int i = 1; i < n; i++)
            prefixSum[i] = prefixSum[i - 1] * nums[i - 1];

        suffixSum[n - 1] = 1;
        for (int i = n - 2; i >= 0; i--)
            suffixSum[i] = suffixSum[i + 1] * nums[i + 1];

        for (int i = 0; i < n; i++)
            answer[i] = prefixSum[i] * suffixSum[i];
            
        return answer;
    }
}
