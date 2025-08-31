namespace Exercicios.Array___Hash;

public class ProductArrayExceptSelfPrefixSumEx238
{
    public int[] ProductExceptSelf(int[] nums) 
    {
        int[] answer = new int[nums.Length];
        int[] prefix = new int[nums.Length];
        int[] suffix = new int[nums.Length];

        prefix[0] = 1;
        for (int i = 1; i < nums.Length; i++) 
        {
            prefix[i] = prefix[i - 1] * nums[i - 1];
        }

        suffix[suffix.Length - 1] = 1;
        for (int i = suffix.Length - 2; i >= 0; i--) 
        {
            suffix[i] = suffix[i + 1] * nums[i + 1];    
        }

        for (int i = 0; i < answer.Length; i++) 
        {
            answer[i] = prefix[i] * suffix[i];
        }

        return answer;
    }
}
