namespace Exercicios.Array___Hash;

public class ArrayHashExercise1929
{
    public int[] GetConcatenation(int[] nums)
    {
        int[] ans = new int[nums.Length * 2];

        for (int i = 0; i < nums.Length; i++)
        {
            ans[i] = nums[i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            ans[nums.Length + i] = nums[i];
        }

        return ans;
    }
}
