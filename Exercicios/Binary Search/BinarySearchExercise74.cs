namespace Exercicios.Binary_Search;

public class BinarySearchExercise74
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int leftPointer = 0, rightPointer = matrix.Length - 1;
        int targetLine = 0;
        while (leftPointer <= rightPointer) 
        { 
            int middlePointer = leftPointer + ((rightPointer - leftPointer) / 2);

            if (matrix[middlePointer][matrix[middlePointer].Length - 1] < target)
            {
                leftPointer = middlePointer + 1;
            }
            else if (matrix[middlePointer][0] > target)
            {
                rightPointer = middlePointer - 1;
            }
            else 
            { 
                targetLine = middlePointer;
                break;
            }
        }

        leftPointer = 0; rightPointer = matrix[targetLine].Length - 1;
        while (leftPointer <= rightPointer) 
        { 
            int middlePointer = leftPointer + ((rightPointer - leftPointer) / 2);

            if (matrix[targetLine][middlePointer] < target)
            {
                leftPointer = middlePointer + 1;
            }
            else if (matrix[targetLine][middlePointer] > target)
            {
                rightPointer = middlePointer - 1;
            }
            else 
            {
                return true;
            }
        }

        return false;
    }
}
