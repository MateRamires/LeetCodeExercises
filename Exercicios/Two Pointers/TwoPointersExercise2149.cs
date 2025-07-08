namespace Exercicios.Two_Pointers;

public class TwoPointersExercise2149
{
    public int[] RearrangeArray(int[] nums)
    {
        List<int> positiveNumbersInOrder = new List<int>();
        List<int> negativeNumbersInOrder = new List<int>();
        int[] rearrengedArray = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
                positiveNumbersInOrder.Add(nums[i]);
            else
                negativeNumbersInOrder.Add(nums[i]);
        }

        int writerPointer = 0;
        int positiveReaderPointer = 0;
        int negativeReaderPointer = 0;
        while (writerPointer != nums.Length)
        {
            rearrengedArray[writerPointer++] = positiveNumbersInOrder[positiveReaderPointer++];
            rearrengedArray[writerPointer++] = negativeNumbersInOrder[negativeReaderPointer++];
        }

        return rearrengedArray;
    }
}
