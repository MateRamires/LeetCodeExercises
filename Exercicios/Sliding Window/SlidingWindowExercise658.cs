namespace Exercicios.Sliding_Window;

public class SlidingWindowExercise658
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        int leftPointer = 0, rightPointer = arr.Length - 1;

        while (rightPointer - leftPointer >= k) 
        {
            if (Math.Abs(x - arr[leftPointer]) <= Math.Abs(x - arr[rightPointer]))
                rightPointer--;
            else
                leftPointer++;
        }

        var result = new List<int>();
        for (int i = leftPointer; i <= rightPointer; i++) 
        {
            result.Add(arr[i]);
        }

        return result;
    }
}
