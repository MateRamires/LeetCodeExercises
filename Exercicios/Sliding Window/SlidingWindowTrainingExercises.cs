namespace Exercicios.Sliding_Window;

public class SlidingWindowTrainingExercises
{
    public int test1(int[] nums, int k) 
    { 
        int leftPointer = 0;
        int currentWindowSum = 0;
        int maximumSum = int.MinValue;

        for (int rightPointer = 0; rightPointer < nums.Length; rightPointer++) 
        { 
            currentWindowSum += nums[rightPointer];

            while (rightPointer - leftPointer + 1 > k) 
            { 
                currentWindowSum -= nums[leftPointer];
                leftPointer++;
            }
            maximumSum = Math.Max(maximumSum, currentWindowSum);
        }

        return maximumSum;
    }





    public int test2(int[] nums, int target)
    {
        int leftPointer = 0;
        int currentWindowSum = 0;
        int smallestSubstring = int.MaxValue;

        for (int rightPointer = 0; rightPointer < nums.Length; rightPointer++) 
        { 
            currentWindowSum += nums[rightPointer];

            while (currentWindowSum >= target) 
            {
                smallestSubstring = Math.Min(smallestSubstring, rightPointer - leftPointer + 1);

                currentWindowSum -= nums[leftPointer];
                leftPointer++;
            }
        }
        
        return smallestSubstring == int.MaxValue ? 0 : smallestSubstring;
    }
}
