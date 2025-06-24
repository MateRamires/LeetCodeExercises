namespace Exercicios.Two_Pointers;

public class TwoPointersExercise905
{
    public int[] SortArrayByParity(int[] nums)
    {
        List<int> oddNumbers = new List<int>();
        int writerPointer = 0;

        for (int readPointer = 0; readPointer < nums.Length; readPointer++) 
        {
            if (nums[readPointer] % 2 == 0)
            {
                nums[writerPointer++] = nums[readPointer];
            }
            else 
            {
                oddNumbers.Add(nums[readPointer]);
            }
        }

        foreach (int oddNum in oddNumbers)
        {
            nums[writerPointer++] = oddNum;
        }

        return nums;
    }
}
