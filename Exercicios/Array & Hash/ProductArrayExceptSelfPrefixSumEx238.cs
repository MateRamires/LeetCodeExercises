namespace Exercicios.Array___Hash;

public class ProductArrayExceptSelfPrefixSumEx238
{
    public int[] ProductExceptSelf(int[] nums) 
    {
        var prefixArray = new int[nums.Length];
        var suffixArray = new int[nums.Length];
        var answer = new int[nums.Length];

        prefixArray[0] = 1; 
        suffixArray[nums.Length - 1] = 1;

        for (int i = 1; i < nums.Length; i++) 
            prefixArray[i] = nums[i - 1] * prefixArray[i - 1];

        for (int i = nums.Length - 2; i >= 0; i--)
            suffixArray[i] = nums[i + 1] * suffixArray[i + 1];

        for (int i = 0; i < nums.Length; i++)
            answer[i] = prefixArray[i] * suffixArray[i];
        
        return answer;
    }
}
