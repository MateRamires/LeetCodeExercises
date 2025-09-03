namespace Exercicios.Binary_Search;

public class BinarySearchRepeatedExercises
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int beginningRange = 1, maxRange = piles.Max();
        int minimumEatingSpeed = beginningRange;
        while (beginningRange <= maxRange) 
        {
            int middleRange = beginningRange + ((maxRange - beginningRange) / 2);

            long totalTime = 0;
            for (int i = 0; i < piles.Length; i++) 
            { 
                totalTime += (int) Math.Ceiling((double) piles[i] / middleRange);
            }

            if (totalTime > h)
            {
                beginningRange = middleRange + 1;
            }
            else 
            { 
                minimumEatingSpeed = middleRange;
                maxRange = middleRange - 1;
            }
        }

        return minimumEatingSpeed;  
    }

    public int HighestSquareNumberOfNum(int num) 
    { 
        int startRange = 1, endRange = num;
        int maximumNumber = startRange;
        while (startRange <= endRange)
        {
            int middleRange = startRange + ((endRange - startRange) / 2);

            if ((long)middleRange * middleRange > num)
            {
                endRange = middleRange - 1;
            }
            else 
            {
                maximumNumber = middleRange;
                startRange = middleRange + 1;
            }
        }
        return maximumNumber;
    }
}
