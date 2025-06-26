namespace Exercicios.Two_Pointers;

public class TwoPointersExercise80
{
    public int RemoveDuplicates(int[] nums)
    {
        Dictionary<int, int> numberOfTimesValueAppear = new Dictionary<int, int>();

        int writerPointer = 0;
        for (int readerPointer = 0; readerPointer < nums.Length; readerPointer++)
        {
            if (!numberOfTimesValueAppear.ContainsKey(nums[readerPointer])) 
            {
                numberOfTimesValueAppear[nums[readerPointer]] = 0;
            }
            numberOfTimesValueAppear[nums[readerPointer]]++;

            if (numberOfTimesValueAppear[nums[readerPointer]] <= 2)
            {
                nums[writerPointer++] = nums[readerPointer];
            }
        }

        return writerPointer;
    }
}
