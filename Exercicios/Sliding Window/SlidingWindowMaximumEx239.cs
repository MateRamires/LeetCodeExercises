namespace Exercicios.Sliding_Window;

public class SlidingWindowMaximumEx239
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var result = new List<int>();
        int maxIdx = -1;

        var leftPointer = 0;
        for (int rightPointer = 0; rightPointer < nums.Length; rightPointer++)
        {
            if (maxIdx == -1 || nums[rightPointer] > nums[maxIdx])
                maxIdx = rightPointer;

            if (rightPointer - leftPointer + 1 == k)
            {
                result.Add(nums[maxIdx]);

                if (leftPointer++ == maxIdx) 
                {
                    int newMaxIdx = leftPointer;
                    for (int i = leftPointer; i <= rightPointer; i++) 
                    {
                        if (nums[i] >= nums[newMaxIdx]) 
                            newMaxIdx = i;
                    }
                    maxIdx = newMaxIdx;
                }
            }
        }

        return result.ToArray();
    }
}
