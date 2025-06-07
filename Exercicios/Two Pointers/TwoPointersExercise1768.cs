namespace Exercicios.Two_Pointers;

public class TwoPointersExercise1768
{
    public string MergeAlternately(string word1, string word2)
    {
        string result = "";

        int leftPointerWord1 = 0, leftPointerWord2 = 0;
        while (leftPointerWord1 < word1.Length || leftPointerWord2 < word2.Length) 
        {
            if (leftPointerWord1 < word1.Length)
                result += word1[leftPointerWord1];

            if (leftPointerWord2 < word2.Length)
                result += word2[leftPointerWord2];

            leftPointerWord1++;
            leftPointerWord2++;
        }

        return result;
    }
}
