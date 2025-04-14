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

    //Ex 74
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int top = 0, bot = rows - 1;
        int row = 0;
        while (top <= bot) 
        {
            row = (top + bot) / 2; //Vamos fazer um binary search nos arrays da matriz
            if (target > matrix[row][cols - 1])
            {
                top = row + 1;
            }
            else if (target < matrix[row][0])
            {
                bot = row - 1;
            }
            else 
            {
                break;
            }
        }

        if (!(top <= bot)) //se cair nesse cenario, quer dizer que nenhuma linha contem o valor target, sendo assim, ja podemos retornar false.
        {
            return false;
        }

        int leftP = 0, rightP = cols - 1;
        while (leftP <= rightP) 
        { 
            int middle = leftP + ((rightP - leftP) / 2);
            if (target > matrix[row][middle])
            {
                leftP = middle + 1;
            }
            else if (target < matrix[row][middle])
            {
                rightP = middle - 1;
            }
            else 
            {
                return true;
            }
        }
        return false;
    }

    //Ex 875
    public int MinEatingSpeed(int[] piles, int h)
    {
        int leftP = 1, rightP = piles.Max(); //Nosso binary search sera feito nesse range, de 1 (leftP) ate o maior valor do array piles (rightP)
        int result = rightP; 

        while (leftP <= rightP) 
        {
            int k = leftP + ((rightP - leftP) / 2);

            long totalTime = 0;
            foreach (int pile in piles) 
            {
                totalTime += (int)Math.Ceiling((double)pile / k);
            }

            if (totalTime <= h)
            {
                result = k;
                rightP = k - 1; //Vamos procurar por uma taxa de bananas comidas por hora menor, ou seja, movemos o ponteiro direito, ja que queremos a menor taxa.
            }
            else 
            {
                leftP = k + 1; //Nesse caso vamos mover o ponteiro esquerdo, pois a taxa de bananas comidas por hora não foi o suficiente para Koko comer todas, e temos que buscar por taxas maiores.
            }
        }
        return result;
    }

    //Ex 153
    public int FindMin(int[] nums)
    {
        int leftP = 0, rightP = nums.Length - 1;
        int result = nums[0];

        while (leftP <= rightP) 
        {
            if (nums[leftP] < nums[rightP]) //Caso o ponteiro esquerdo seja menor que o ponteiro direito, isso quer dizer que ja estamos na porcao do array onde ele esta ordenado, sendo assim, o menor valor sempre sera o primeiro, ou seja, o ponteiro esquerdo, nao precisamos mais fazer binary search.
            {
                result = Math.Min(result, nums[leftP]);
                break;
            }

            int m = leftP + ((rightP - leftP) / 2);
            result = Math.Min(result, nums[m]);
            if (nums[m] >= nums[leftP]) //nos colocamos maior ou IGUAL pois o nosso "m" pode estar justamente em cima do ponteiro esquerdo, eh um edge-case.
                leftP = m + 1;
            else 
                rightP = m - 1;
        }
        return result;
    }
}
