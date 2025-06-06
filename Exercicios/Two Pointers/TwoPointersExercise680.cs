namespace Exercicios.Two_Pointers;

public class TwoPointersExercise680
{
    public bool ValidPalindrome(string s)
    {
        int leftPointer = 0, rightPointer = s.Length -1;

        var wrongCharacterPosition1 = -1;
        var wrongCharacterPosition2 = -1;
        while (leftPointer < rightPointer) 
        {
            if (s[leftPointer] != s[rightPointer]) 
            {
                wrongCharacterPosition1 = leftPointer;
                wrongCharacterPosition2 = rightPointer;
                break;
            }

            leftPointer++;
            rightPointer--;
        }

        if (wrongCharacterPosition1 == -1)
            return true;

        bool isValid = true;

        //Removing leftMostCharacter
        string newString = s.Remove(wrongCharacterPosition1, 1);

        leftPointer = 0; 
        rightPointer = newString.Length - 1;

        while (leftPointer < rightPointer)
        {
            if (newString[leftPointer] != newString[rightPointer]) 
            {
                isValid = false;
                break;
            }  

            leftPointer++;
            rightPointer--;
        }

        if (isValid)
            return true;

        //Removing rightMostCharacter
        string newString2 = s.Remove(wrongCharacterPosition2, 1);

        isValid = true;

        leftPointer = 0;
        rightPointer = newString2.Length - 1;

        while (leftPointer < rightPointer)
        {
            if (newString2[leftPointer] != newString2[rightPointer])
            {
                isValid = false;
                break;
            }


            leftPointer++;
            rightPointer--;
        }

        if (isValid)
            return true;

        return false;
    }
}
