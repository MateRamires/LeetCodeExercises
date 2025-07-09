namespace Exercicios.Binary_Search;

public class BinarySearchExercise704
{
    public int Search(int[] nums, int target)
    {
        int leftPointer = 0, rightPointer = nums.Length - 1;

        while (leftPointer <= rightPointer) 
        { 
            int middlePointer = leftPointer + ((rightPointer - leftPointer) / 2);

            if (nums[middlePointer] > target)
            {
                rightPointer = middlePointer - 1;
            }
            else if (nums[middlePointer] < target)
            {
                leftPointer = middlePointer + 1;
            }
            else 
            {
                return middlePointer;
            }
        }

        return -1;
    }
}
