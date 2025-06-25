namespace Exercicios.Two_Pointers;

public class TwoPointersExercise844
{
    public bool BackspaceCompare(string s, string t)
    {
        int stringOneReader = s.Length - 1, stringTwoReader = t.Length - 1;
        int skipCharacter1 = 0, skipCharacter2 = 0;
        while (stringOneReader >= 0 || stringTwoReader >= 0) 
        {
            while (stringOneReader >= 0) 
            {
                if (s[stringOneReader] == '#')
                {
                    skipCharacter1++;
                    stringOneReader--;
                }
                else if (skipCharacter1 > 0)
                {
                    skipCharacter1--;
                    stringOneReader--;
                }
                else
                    break;
            }

            while (stringTwoReader >= 0)
            {
                if (t[stringTwoReader] == '#')
                {
                    skipCharacter2++;
                    stringTwoReader--;
                }
                else if (skipCharacter2 > 0)
                {
                    skipCharacter2--;
                    stringTwoReader--;
                }
                else
                    break;
            }

            if ((stringOneReader >= 0) != (stringTwoReader >= 0)) return false;
            if (stringOneReader >= 0 && s[stringOneReader] != t[stringTwoReader]) return false;

            stringOneReader--; stringTwoReader--;
        }

        return true;
    }
}
