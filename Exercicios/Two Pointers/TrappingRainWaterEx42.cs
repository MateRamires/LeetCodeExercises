namespace Exercicios.Two_Pointers;

public class TrappingRainWaterEx42
{
    public int Trap(int[] height)
    {
        if (height == null || height.Length == 0)
            return 0;

        int leftPointer = 0, rightPointer = height.Length - 1;
        int leftMax = height[leftPointer], rightMax = height[rightPointer];
        int res = 0;
        while (leftPointer < rightPointer) 
        {
            if (leftMax < rightMax)
            {
                leftPointer++;
                leftMax = Math.Max(leftMax, height[leftPointer]);
                res += leftMax - height[leftPointer];
            }
            else 
            {
                rightPointer++;
                rightMax = Math.Max(rightMax, height[rightPointer]);
                res += rightMax - height[rightPointer];
            }
        }

        return res;
    }
}
