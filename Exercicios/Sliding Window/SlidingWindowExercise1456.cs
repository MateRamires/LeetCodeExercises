namespace Exercicios.Sliding_Window;

public class SlidingWindowExercise1456
{
    public int MaxVowels(string s, int k)
    {
        int leftPointer = 0;
        int highestAmmountOfVowelsInK = 0;
        int ammountOfVowelsInCurrentWindow = 0;
        HashSet<char> vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u'};
        for (int rightPointer = 0; rightPointer < s.Length; rightPointer++)
        {
            if(vowels.Contains(s[rightPointer]))
                ammountOfVowelsInCurrentWindow++;

            if (rightPointer - leftPointer + 1 == k) 
            {
                highestAmmountOfVowelsInK = Math.Max(highestAmmountOfVowelsInK, ammountOfVowelsInCurrentWindow);

                if (vowels.Contains(s[leftPointer]))
                    ammountOfVowelsInCurrentWindow--;

                leftPointer++;
            }
        }

        return highestAmmountOfVowelsInK;
    }
}
