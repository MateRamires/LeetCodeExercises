namespace Exercicios.Array___Hash;

public class ArrayHashExercise448
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        HashSet<int> result = new HashSet<int>();
        for (int i = 1; i <= nums.Length; i++)
            result.Add(i);

        foreach (int num in nums)
            result.Remove(num);

        return result.ToList();
    }
}
