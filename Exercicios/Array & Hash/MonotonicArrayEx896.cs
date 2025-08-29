namespace Exercicios.Array___Hash;

public class MonotonicArrayEx896
{
    public bool IsMonotonic(int[] nums)
    {
        bool isIncreasingMonotonic = true;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1]) 
            {
                isIncreasingMonotonic = false; break;
            }
        }

        if (isIncreasingMonotonic)  return true;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
                return false;
            
        }

        return true;
    }
}
