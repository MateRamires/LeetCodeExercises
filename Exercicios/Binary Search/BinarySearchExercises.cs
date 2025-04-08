namespace Exercicios.Binary_Search;

public class BinarySearchExercises
{
    //Ex 704
    public int Search(int[] nums, int target)
    {
        int leftP = 0, rightP = nums.Length - 1;

        while (leftP <= rightP) 
        {
            int middle = leftP + ((rightP - leftP) / 2); //rightP - leftP seria a distancia total, dividimos por 2 e temos quantas casas temos que andar, soma essas casas que temos que andar + o inicio (que pode ser 0 ou um numero maior) e temos o meio.
            //int middle = (leftP + rightP) / 2;

            if (nums[middle] > target)
            {
                rightP = middle - 1;
            }
            else if (nums[middle] < target)
            {
                leftP = middle + 1;
            }
            else 
            {
                return middle;
            }
        }
        return -1;
    }
}
