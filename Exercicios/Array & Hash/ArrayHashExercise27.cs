using System;

namespace Exercicios.Array___Hash;

public class ArrayHashExercise27
{
    public int RemoveElement(int[] nums, int val)
    {
        int k = 0; 
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[k++] = nums[i];
            }    
        }
        return k;
    }
}
