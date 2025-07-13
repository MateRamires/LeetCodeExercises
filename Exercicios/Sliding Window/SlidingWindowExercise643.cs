namespace Exercicios.Sliding_Window;

public class SlidingWindowExercise643
{
    public double FindMaxAverage(int[] nums, int k)
    {
        int leftPointer = 0;
        int currentSum = 0;
        double maximumAvarageValue = double.MinValue;
        for (int rightPointer = 0; rightPointer < nums.Length; rightPointer++)
        {
            currentSum += nums[rightPointer];

            if (rightPointer - leftPointer + 1 == k) 
            {
                double currentAvarageValue = Math.Round((double) currentSum / k, 5);

                maximumAvarageValue = Math.Max(maximumAvarageValue, currentAvarageValue);

                currentSum -= nums[leftPointer];
                leftPointer++;
            }
        }

        return maximumAvarageValue;
    }
}
