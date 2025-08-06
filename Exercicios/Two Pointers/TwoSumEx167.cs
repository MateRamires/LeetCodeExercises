namespace Exercicios.Two_Pointers;

public class TwoSumEx167
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int leftPointer = 0;
        int rightPointer = numbers.Length - 1; 
        while(leftPointer <= rightPointer) { 
            int sum = numbers[leftPointer] + numbers[rightPointer];
            if (sum == target)
                return new int[2] { leftPointer, rightPointer };
            else if (sum > target)
                rightPointer--;
            else if (sum < target)
                leftPointer++;
        }

        return null;
    }
}
