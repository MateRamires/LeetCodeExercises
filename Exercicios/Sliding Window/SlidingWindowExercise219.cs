namespace Exercicios.Sliding_Window;

public class SlidingWindowExercise219
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        HashSet<int> visitedNumbers = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++) 
        {
            if (visitedNumbers.Contains(nums[i]))
                return true;

            visitedNumbers.Add(nums[i]);

            if (i >= k)
                visitedNumbers.Remove(nums[i - k]);
        }

        return false;
    }
}
