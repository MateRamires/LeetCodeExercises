namespace Exercicios.Binary_Search;

public class KokoEatingBananasEx875
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int minSpeed = 1, maxSpeed = piles.Max();
        int fastestEatingSpeed = minSpeed;
        while (minSpeed <= maxSpeed) 
        { 
            int middleSpeed = minSpeed + ((maxSpeed - minSpeed) / 2);

            long totalTime = 0;
            foreach (int pile in piles) 
            {
                totalTime += (int)Math.Ceiling((double)pile / middleSpeed);
            }

            if (totalTime > h)
                minSpeed = middleSpeed + 1;
            else 
            {
                fastestEatingSpeed = middleSpeed;
                maxSpeed = middleSpeed - 1;
            }
        }

        return fastestEatingSpeed;
    }
}
