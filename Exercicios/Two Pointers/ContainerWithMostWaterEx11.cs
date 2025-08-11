namespace Exercicios.Two_Pointers;

public class ContainerWithMostWaterEx11
{
    public int MaxArea(int[] height)
    {
        int res = 0;
        int left = 0, right = height.Length - 1;

        while (left < right) 
        { 
            int currentArea = Math.Min(height[left], height[right]) * (right - left);

            res = Math.Max(res, currentArea);

            if (height[left] > height[right]) 
                right--;
            else
                left++;
            
        }

        return res;
    }
}
