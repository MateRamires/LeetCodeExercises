namespace Exercicios.Two_Pointers;

public class TwoPointers2161
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        List<int> elementsGreaterThanPivot = new List<int>();
        int elementsEqualToPivot = 0;
        int writerPointer = 0;

        for (int readerPointer = 0; readerPointer < nums.Length; readerPointer++)
        {
            if (nums[readerPointer] < pivot)
                nums[writerPointer++] = nums[readerPointer];
            else if (nums[readerPointer] == pivot)
                elementsEqualToPivot++;
            else
                elementsGreaterThanPivot.Add(nums[readerPointer]);
        }

        while (elementsEqualToPivot != 0) 
        {
            nums[writerPointer++] = pivot;
            elementsEqualToPivot--;
        }

        foreach (int element in elementsGreaterThanPivot)
        {
            nums[writerPointer++] = element;
        }


        return nums;
    }
}
