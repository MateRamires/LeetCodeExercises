namespace Exercicios.Two_Pointers;

public class TwoPointersExercise2108
{
    public string FirstPalindrome(string[] words)
    {
        foreach (var word in words) 
        { 
            int leftPointer = 0, rightPointer = word.Length - 1;
            bool isPalindrome = true;

            while (leftPointer < rightPointer) 
            {
                if (word[leftPointer] != word[rightPointer])
                    isPalindrome = false;

                leftPointer++;
                rightPointer--;
            }

            if (isPalindrome)
                return word;
        }

        return "";
    }
}
