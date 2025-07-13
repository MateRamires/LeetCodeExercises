namespace Exercicios.Sliding_Window;

public class SlidingWindowCircularTestExercise
{
    public int[] circularArray(int[] nums, int startIndex, int readThatManyElements) 
    {
        int[] res = new int[readThatManyElements];
        int readerPointer = 0;
        for (int index = startIndex; index < nums.Length + readThatManyElements; index++)
        {
            res[readerPointer++] = nums[index % nums.Length];

            if (readerPointer == readThatManyElements)
                break;
        }

        return res;
    }
}
