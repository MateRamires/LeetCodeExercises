namespace Exercicios.Array___Hash;

public class ArrayExercise169
{
    public int MajorityElement(int[] nums)
    {
        Dictionary<int, int> countElements = new Dictionary<int, int>();
        int res = 0; int biggestValue = 0;

        foreach (int num in nums) 
        {
            if (!countElements.ContainsKey(num)) 
            {
                countElements[num] = 0;
            }

            countElements[num]++;

            if (countElements[num] > biggestValue) 
            {
                res = num;
                biggestValue = countElements[num];
            }
        }

        return res;
    }
}
