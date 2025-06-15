namespace Exercicios.Sliding_Window;

public class SlidingWindowExercise2379
{
    public int MinimumRecolors(string blocks, int k)
    {
        int leftPointer = 0;
        int leastAmoutOfWhiteBlocks = int.MaxValue;
        int whiteBlocksInCurrentWindow = 0;

        for (int rightPointer = 0; rightPointer < blocks.Length; rightPointer++) 
        {
            if (blocks[rightPointer] == 'W') 
            {
                whiteBlocksInCurrentWindow++;
            }

            if (rightPointer - leftPointer + 1 == k) 
            {
                leastAmoutOfWhiteBlocks = Math.Min(leastAmoutOfWhiteBlocks, whiteBlocksInCurrentWindow);

                if (blocks[leftPointer] == 'W')
                    whiteBlocksInCurrentWindow--;

                leftPointer++;
            }
            
        }

        return leastAmoutOfWhiteBlocks;
    }
}
