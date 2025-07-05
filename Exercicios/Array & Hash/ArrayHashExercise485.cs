namespace Exercicios.Array___Hash;

public class ArrayHashExercise485
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int maximumNumberOfOnes = 0;
        int currentNumberOfOnes = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                currentNumberOfOnes = 0;
            else
                currentNumberOfOnes++;

            maximumNumberOfOnes = Math.Max(maximumNumberOfOnes, currentNumberOfOnes);
        }

        return maximumNumberOfOnes;
    }
}
