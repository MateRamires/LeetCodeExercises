namespace Exercicios.Two_Pointers;

public class TwoSumEx167
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int leftPointer = 0, rightPointer = numbers.Length - 1;
        while (leftPointer < rightPointer) 
        { 
            int currentSum = numbers[leftPointer] + numbers[rightPointer];

            if (currentSum > target)
                rightPointer--;
            else if (currentSum < target)
                leftPointer++;
            else
                return new int[] { leftPointer + 1, rightPointer + 1 };
        }

        return new int[] { 0, 0 };
    }
}
