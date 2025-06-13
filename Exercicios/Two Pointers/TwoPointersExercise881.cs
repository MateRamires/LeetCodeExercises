namespace Exercicios.Two_Pointers;

public class TwoPointersExercise881
{
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);

        int currentMax = 0, leftPointer = 0, rightPointer = people.Length -1;
        int boatQuantity = 0;

        while (leftPointer <= rightPointer) 
        { 
            currentMax = people[leftPointer] + people[rightPointer];

            if (currentMax <= limit)
                leftPointer++;

            rightPointer--;
            boatQuantity++;
        }

        return boatQuantity;
    }
}
