using System.Globalization;

namespace Exercicios.Two_Pointers;

public class TwoPointersExercise26
{
    public int RemoveDuplicates(int[] nums)
    {
        int writePointer = 0;
        HashSet<int> uniqueElement = new HashSet<int>();
        for (int readPointer = 0; readPointer < nums.Length; readPointer++) 
        {
            if (!uniqueElement.Contains(nums[readPointer]))
            {
                nums[writePointer++] = nums[readPointer];
                uniqueElement.Add(nums[readPointer]);

            }
        }

        return uniqueElement.Count;
    }
}
