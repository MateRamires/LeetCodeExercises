namespace Exercicios.Array___Hash;

public class ArrayHashExercise2215
{
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        HashSet<int> numbersInNums1 = new HashSet<int>();
        HashSet<int> numbersInNums2 = new HashSet<int>();
        HashSet<int> prohibitedNumbers = new HashSet<int>();
        IList<IList<int>> answer = new List<IList<int>>();

        foreach (int num in nums1) 
        { 
            if(!numbersInNums1.Contains(num))
                numbersInNums1.Add(num);
        }

        foreach (int num in nums2)
        {
            if (numbersInNums1.Contains(num))
            {
                numbersInNums1.Remove(num);
                prohibitedNumbers.Add(num);
            }
            else 
            {
                if (!numbersInNums2.Contains(num) && !prohibitedNumbers.Contains(num))
                    numbersInNums2.Add(num);
            }
        }

        answer.Add(numbersInNums1.ToList());
        answer.Add(numbersInNums2.ToList());

        return answer;
    }
}
