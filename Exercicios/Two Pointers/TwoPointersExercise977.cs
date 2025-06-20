using System.Collections;

namespace Exercicios.Two_Pointers;

public class TwoPointersExercise977
{
    public int[] SortedSquares(int[] nums)
    {
        int leftPointer = 0, rightPointer = nums.Length - 1, write = nums.Length - 1;
        int[] res = new int[nums.Length];

        while (leftPointer <= rightPointer) 
        {
            int sqLeft = nums[leftPointer] * nums[leftPointer];
            int sqRight = nums[rightPointer] * nums[rightPointer];

            if (sqLeft > sqRight)
            {
                res[write--] = sqLeft;
                leftPointer++;
            }
            else
            {
                res[write--] = sqRight;
                rightPointer--;
            }

        }
        return res;
    }
}
