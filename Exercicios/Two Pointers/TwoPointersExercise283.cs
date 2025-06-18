namespace Exercicios.Two_Pointers;

public class TwoPointersExercise283
{
    public void MoveZeroes(int[] nums)
    {
        int writePointer = 0;

        for (int readPointer = 0; readPointer < nums.Length; readPointer++) 
        {
            if (nums[readPointer] != 0)
            {
                nums[writePointer] = nums[readPointer];
                writePointer++;
            }
        }

        while (writePointer < nums.Length) 
        {
            nums[writePointer++] = 0;
        }
    }
}
