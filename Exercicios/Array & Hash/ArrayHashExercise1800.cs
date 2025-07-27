namespace Exercicios.Array___Hash;

public class ArrayHashExercise1800
{
    public int MaxAscendingSum(int[] nums)
    {
        int highestSum = nums[0];
        int currentSum = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                currentSum += nums[i];
            }
            else 
            {
                currentSum = nums[i];
            }

            highestSum = Math.Max(highestSum, currentSum);
        }

        return highestSum;
    }
}
