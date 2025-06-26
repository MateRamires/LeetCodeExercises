namespace Exercicios.Two_Pointers;

public class TwoPointersExercise2460
{
    public int[] ApplyOperations(int[] nums)
    {
        for (int i = 0; i < nums.Length - 1; i++) 
        {
            if (nums[i] == nums[i + 1])
            {
                nums[i] = nums[i] * 2;
                nums[i + 1] = 0;
            }
        }

        int writerPointer = 0;
        for (int readerPointer = 0; readerPointer < nums.Length; readerPointer++) 
        {
            if (nums[readerPointer] != 0)
            {
                nums[writerPointer++] = nums[readerPointer];
            }
        }

        while (writerPointer < nums.Length)
        {
            nums[writerPointer++] = 0;
        }

        return nums;
    }
}
