namespace Exercicios.Sliding_Window;

public class SlidingWindowTrainingExercises
{
    public int highestSumFixedWindow(int[] nums, int k) 
    {
        int leftPointer = 0;
        int currentSum = 0;
        int biggestSum = 0;
        for (int rightPointer = 0; rightPointer < nums.Length; rightPointer++)
        {
            currentSum += nums[rightPointer];

            if (rightPointer - leftPointer + 1 >= k) 
            {
                biggestSum = Math.Max(biggestSum, currentSum);

                currentSum -= nums[leftPointer];
                leftPointer++;
            }
        }

        return biggestSum;
    }
}
