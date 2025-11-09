namespace Exercicios.Stack;

internal class SearchInRotatedSortedArrayEx33
{
    public int Search(int[] nums, int target)
    {
        int leftP = 0, rightP = nums.Length - 1;

        while (leftP <= rightP) 
        { 
            int middle = leftP + ((rightP - leftP) / 2);
            if (target == nums[middle])
                return middle;

            if (nums[leftP] <= nums[middle])
            {
                if (target > nums[middle] || target < nums[leftP])
                    leftP = middle + 1;
                else
                    rightP = middle - 1;
            }
            else 
            { 
                if(target < nums[middle] || target > nums[rightP])
                    rightP = middle - 1;
                else
                    leftP = middle + 1; 
            }
            
        }

        return -1;
    }
}
