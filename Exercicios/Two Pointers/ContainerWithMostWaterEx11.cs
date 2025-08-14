namespace Exercicios.Two_Pointers;

public class ContainerWithMostWaterEx11
{
    public int MaxArea(int[] height)
    {
        int res = 0;
        int left = 0, right = height.Length - 1;

        while (left < right) 
        { 
            int currentArea = Math.Min(height[left], height[right]) * (right - left); //Para calcular a area tem que pegar o menor entre height left e height right

            res = Math.Max(res, currentArea);

            if (height[left] > height[right]) //Aqui fazemos o Two Pointers padrao, se o left for o maior, entao movemos o right para frente, e vice-versa
                right--;
            else
                left++;
            
        }

        return res;
    }
}
