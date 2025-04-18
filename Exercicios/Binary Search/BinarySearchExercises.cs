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

    //Ex 33
    public int Search2(int[] nums, int target)
    {
        int leftP = 0, rightP = nums.Length - 1;

        while (leftP <= rightP) 
        {
            int mid = leftP + ((rightP - leftP) / 2);
            if (target == nums[mid])
                return mid;

            //Left Sorted Portion (Se o menor numero da porcao esquerda (leftPointer) for menor que o meio, entao estamos na porcao ordenada esquerda
            if (nums[leftP] <= nums[mid])
            {
                if (target > nums[mid] || target < nums[leftP]) //Se o alvo for maior que o meio OU o target for ainda menor que o menor numero da porcao esquerda, nos devemos buscar nosso alvo na porcao direita, removendo completamente todos os numeros da porcao esquerda.
                    leftP = mid + 1;
                else //Se o alvo for menor que o meio, porem, for maior ou igual ao ponteiro esquerdo, isso quer dizer que o alvo esta na porcao esquerda, seja entre o ponteiro esquerdo e o meio, ou o proprio ponteiro esquerdo, mas sabemos que ele nao esta na porcao direita.
                    rightP = mid - 1;

            }
            else //Right Sorted Portion (Se o menor numero da porcao da esquerda for maior que o meio, entao estamos na porcao ordenada da direita)
            {
                if(target < nums[mid] || target > nums[rightP]) //Se o alvo for menor que o meio OU o alvo for maior que o ultimo numero da porcao direita (o maior numero da porcao direita), entao o alvo nao esta na porcao direita, sendo assim, movemos o ponteiro e faremos a busca na porcao esquerda.
                    rightP = mid - 1;
                else
                    leftP = mid + 1; //Se o alvo for MAIOR que o meio e MENOR que o maior numero da porcao direita (RightPointer), entao nosso alvo esta definitivamente na porcao direita, ou nao existe, entao excluimos todos os numeros da porcao esquerda.
            }
        }
        return -1; //Se sair do while e nao encontrar o valor, entao o valor nao existe no array.
    }

    //Ex 4
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] A = nums1;
        int[] B = nums2;
        int total = A.Length + B.Length;
        int half = (total + 1) / 2;

        if (B.Length < A.Length) //Para esse ex ficar mais facil, nos faremos binary search apenas no array que tem menor tamanho, para isso, vamos garantir que sempre o array A tenha o menor tamanho, trocando os elementos entre ambos caso A seja maior no parametro da funcao.
        {
            int[] temp = A;
            A = B;
            B = temp;
        }

        int leftPointer = 0, rightPointer = A.Length;
        while (leftPointer <= rightPointer)
        {
            int i = (leftPointer + rightPointer) / 2; //Encontramos a casa do elemento do meio do array A.
            int j = half - i; //Encontramos quantos elementos teremos que pegar do array B.

            int ALeft = 1 > 0 ? A[i - 1] : int.MinValue;
            int Aright = i < A.Length ? A[i] : int.MaxValue;
            int Bleft = j > 0 ? B[j - 1] : int.MinValue;
            int Bright = j < B.Length ? B[j] : int.MaxValue;

            if (ALeft <= Bright && Bleft <= Aright)
            {
                if (total % 2 != 0) //Se o total numero de elementos for impar.
                {
                    return Math.Max(ALeft, Bleft);
                }
                return (Math.Max(ALeft, Bleft) + Math.Min(Aright, Bright)) / 2;
            }
            else if (ALeft > Bright)
            {
                rightPointer = i - 1;
            }
            else
            {
                leftPointer = i - 1;
            }
        }
        return -1;
    }
}
