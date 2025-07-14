namespace Exercicios.Array___Hash;

public class ArrayHashExercise3105
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        int strictlyIncreasing = 1, striclyDecreasing = 1, lastNumber = nums[0];
        int res = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > lastNumber)
            {
                strictlyIncreasing++;
                striclyDecreasing = 1;

                res = Math.Max(res, strictlyIncreasing);

                lastNumber = nums[i];
            }
            else if (nums[i] < lastNumber)
            {
                striclyDecreasing++;
                strictlyIncreasing = 1;

                res = Math.Max(res, striclyDecreasing);

                lastNumber = nums[i];
            }
            else 
            {
                striclyDecreasing = 1;
                strictlyIncreasing = 1;
            }
        }

        return res;
    }
}
