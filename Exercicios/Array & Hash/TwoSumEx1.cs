namespace Exercicios.Array___Hash;

public class TwoSumEx1
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var targetDifference = target - nums[i];

            if (dict.ContainsKey(nums[i]))
            {
                return new int[] { i, dict[nums[i]] };
            }

            dict.TryAdd(targetDifference, i);
        }

        return null;
    }
}
