namespace Exercicios.Array___Hash;

public class ArrayHashExercise3423
{
    public int MaxAdjacentDistance(int[] nums)
    {
        int res = 0;
        res = Math.Abs(nums[0] - nums[nums.Length - 1]);

        for (int i = 0; i < nums.Length; i++)
        {
            if (i + 1 < nums.Length)
            {
                res = Math.Max(res, Math.Abs(nums[i] - nums[i + 1]));
            }
        }

        return res;
    }
}
