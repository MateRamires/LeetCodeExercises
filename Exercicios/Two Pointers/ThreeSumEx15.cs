namespace Exercicios.Two_Pointers;

public class ThreeSumEx15
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var res = new List<IList<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) break;
            if (i > 0 && nums[i] == nums[i - 1])
                continue; //Se o numero atual for igual ao ultimo, pula, se nao teremos duplicatas na resposta final.

            int leftPointer = i + 1, rightPointer = nums.Length -1;
            while (leftPointer < rightPointer) 
            { 
                int sum = nums[i] + nums[leftPointer] + nums[rightPointer];
                if (sum > 0)
                {
                    rightPointer--;
                }
                else if (sum < 0)
                {
                    leftPointer++;
                }
                else 
                {
                    res.Add(new List<int> { nums[i], nums[leftPointer], nums[rightPointer] });
                    leftPointer++;
                    rightPointer--;
                    while (leftPointer < rightPointer && nums[leftPointer] == nums[leftPointer - 1]) 
                    {
                        leftPointer++;
                    }
                }
            }
        }
        return res;
    }
}
