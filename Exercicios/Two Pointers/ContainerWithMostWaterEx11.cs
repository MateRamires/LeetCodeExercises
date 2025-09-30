using System.Globalization;

namespace Exercicios.Two_Pointers;

public class ContainerWithMostWaterEx11
{
    public int MaxArea(int[] height)
    {
        int leftPointer = 0, rightPointer = height.Length - 1;
        int maxSize = 0;
        while (leftPointer < rightPointer) 
        {
            int currentSize = Math.Min(height[leftPointer], height[rightPointer]) * (rightPointer - leftPointer);
            maxSize = Math.Max(maxSize, currentSize);

            if (height[leftPointer] > height[rightPointer])
                rightPointer--;
            else
                leftPointer++;
        }
        return maxSize;
    }
}
