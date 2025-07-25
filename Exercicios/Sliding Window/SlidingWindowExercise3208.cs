namespace Exercicios.Sliding_Window;

public class SlidingWindowExercise3208
{
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        int alternatingGroups = 0;
        int currentWindowSize = 1;
        for (int rightPointer = 1; rightPointer < colors.Length + k - 1; rightPointer++)
        {
            int trueIndex = rightPointer % colors.Length;
            int previousIndex = (rightPointer - 1 + colors.Length) % colors.Length;
            if (colors[trueIndex] == colors[previousIndex])
            {
                currentWindowSize = 1;
            }
            else 
            {
                currentWindowSize++;
            }

            if (currentWindowSize == k)
            {
                alternatingGroups++;
                currentWindowSize--;
            }
        }

        return alternatingGroups;
    }
}
