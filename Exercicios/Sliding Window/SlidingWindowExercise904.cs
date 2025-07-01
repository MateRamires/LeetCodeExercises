namespace Exercicios.Sliding_Window;

public class SlidingWindowExercise904
{
    public int TotalFruit(int[] fruits)
    {
        int maximumAmmountOfFruits = 0;
        int leftPointer = 0;
        Dictionary<int, int> currentPickedFruits = new Dictionary<int, int>();

        for (int rightPointer = 0; rightPointer < fruits.Length; rightPointer++)
        {
            int fruit = fruits[rightPointer];

            if(!currentPickedFruits.TryAdd(fruit, 1))
                currentPickedFruits[fruit]++;

            while (currentPickedFruits.Count > 2) 
            { 
                int leftFruit = fruits[leftPointer];
                currentPickedFruits[leftFruit]--;
                if (currentPickedFruits[leftFruit] == 0)
                    currentPickedFruits.Remove(leftFruit);
                leftPointer++;
            }

            maximumAmmountOfFruits = Math.Max(maximumAmmountOfFruits, rightPointer - leftPointer + 1);
        }

        return maximumAmmountOfFruits;
    }
}
