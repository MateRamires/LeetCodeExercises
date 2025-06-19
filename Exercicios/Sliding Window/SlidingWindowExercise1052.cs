namespace Exercicios.Sliding_Window;

public class SlidingWindowExercise1052
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        int leftPointer = 0;
        int highestAmountOfUnsatisfiedCustomersInMinutes = 0;
        int amountOfUnsatisfiedCustomersInCurrentWindow = 0;
        int satisfiedCustomers = 0;
        for(int rightPointer = 0; rightPointer < customers.Length; rightPointer++) 
        {
            if (grumpy[rightPointer] == 1)
                amountOfUnsatisfiedCustomersInCurrentWindow += customers[rightPointer];

            if (rightPointer - leftPointer + 1 == minutes) 
            {
                highestAmountOfUnsatisfiedCustomersInMinutes = Math.Max(highestAmountOfUnsatisfiedCustomersInMinutes, amountOfUnsatisfiedCustomersInCurrentWindow);

                if(grumpy[leftPointer] == 1)
                    amountOfUnsatisfiedCustomersInCurrentWindow -= customers[leftPointer];

                leftPointer++;
            }

            if (grumpy[rightPointer] == 0)
                satisfiedCustomers += customers[rightPointer];
        }

        return satisfiedCustomers + highestAmountOfUnsatisfiedCustomersInMinutes;
    }
}
