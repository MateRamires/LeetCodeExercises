namespace Exercicios.Two_Pointers;

public class TwoPointersExercise125Redone
{
    public bool IsPalindrome(string s)
    {
        int leftPointer = 0, rightPointer = s.Length - 1;

        while (leftPointer < rightPointer) 
        {
            if (!isAlphanumeric(Char.ToLower(s[leftPointer]))) 
            {
                leftPointer++;
                continue;
            }

            if (!isAlphanumeric(Char.ToLower(s[rightPointer])))
            {
                rightPointer--;
                continue;
            }


            if (Char.ToLower(s[leftPointer]) != Char.ToLower(s[rightPointer])) 
                return false;
            

            leftPointer++;
            rightPointer--;
        }

        return true;
    }

    private bool isAlphanumeric(char s) 
    {
        if ((s >= 48 && s <= 57) || (s >= 97 && s <= 122)) 
        {
            return true;
        }

        return false;
    }
}
