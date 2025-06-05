namespace Exercicios.Two_Pointers;

public class TwoPointersExercise344
{
    public void ReverseString(char[] s)
    {
        int leftPointer = 0, rightPointer = s.Length - 1;
        while (leftPointer < rightPointer) 
        {
            var temp = s[leftPointer];
            s[leftPointer] = s[rightPointer];
            s[rightPointer] = temp;

            leftPointer++;
            rightPointer--;
        }
    }
}
