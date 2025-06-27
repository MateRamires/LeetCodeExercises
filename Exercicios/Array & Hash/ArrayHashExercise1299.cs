namespace Exercicios.Array___Hash;

public class ArrayHashExercise1299
{
    public int[] ReplaceElements(int[] arr)
    {
        int highestNumberFound = -1;

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int temp = arr[i];
            arr[i] = highestNumberFound;

            if (temp > highestNumberFound) 
            {
                highestNumberFound = temp;
            }
        }

        return arr;
    }
}
