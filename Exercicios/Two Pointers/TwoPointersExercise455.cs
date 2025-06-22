namespace Exercicios.Two_Pointers;

public class TwoPointersExercise455
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);

        int greedFactorPointer = 0, cookiePointer = 0, contentChildren = 0;

        while (greedFactorPointer < g.Length && cookiePointer < s.Length) 
        {
            if (s[cookiePointer] >= g[greedFactorPointer])
            {
                contentChildren++;
                cookiePointer++;
                greedFactorPointer++;
            }
            else if (g[greedFactorPointer] > s[cookiePointer]) 
            { 
                cookiePointer++;
            }
        }

        return contentChildren;
    }
}
