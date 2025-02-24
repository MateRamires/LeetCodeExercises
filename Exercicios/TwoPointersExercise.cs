namespace Exercicios;

public class TwoPointersExercise
{
    //Ex 125
    public bool isPalindrome(string s) 
    {
        int leftPointer = 0, rightPointer = s.Length -1;

        while (leftPointer < rightPointer) 
        {
            while(leftPointer < rightPointer && !char.IsLetterOrDigit(s[leftPointer]))
                leftPointer++;

            while (rightPointer > leftPointer && !char.IsLetterOrDigit(s[rightPointer]))
                rightPointer--;

            if (char.ToLower(s[leftPointer]) != char.ToLower(s[rightPointer])) 
                return false;

            leftPointer++; rightPointer--;
        }

        return true;
    }


    //Ex 557
    public string ReverseWords(string s) 
    {
        char[] charArray = s.ToCharArray();

        int leftPointer = 0;
        for (int rightPointer = 0; rightPointer < charArray.Length; rightPointer++) 
        {
            if (charArray[rightPointer] == ' ' || rightPointer == charArray.Length - 1) 
            {
                int temp_leftPointer = leftPointer;
                int temp_rightPointer = rightPointer -1;

                if (rightPointer == charArray.Length - 1)
                    temp_rightPointer = rightPointer;

                while (temp_leftPointer < temp_rightPointer) 
                {
                    char temp = charArray[temp_leftPointer];
                    charArray[temp_leftPointer] = charArray[temp_rightPointer];
                    charArray[temp_rightPointer] = temp;

                    temp_leftPointer++;
                    temp_rightPointer--;
                }

                leftPointer = rightPointer + 1;
            }
        }

        return string.Join("", charArray);

    }

    //Ex 2000
    public string ReversePrefix(string word, char ch)
    {
        var charArray = word.ToCharArray();

        int leftPointer = 0;
        for (int rightPointer = 0; rightPointer < charArray.Length; rightPointer++) 
        {
            if (charArray[rightPointer] == ch) 
            { 
                while (leftPointer < rightPointer) 
                { 
                    var aux = charArray[leftPointer];
                    charArray[leftPointer] = charArray[rightPointer];
                    charArray[rightPointer] = aux;

                    leftPointer++;
                    rightPointer--;
                }

                break;
            }
        }
        return new string(charArray);
    }

    //Ex 167
    public int[] TwoSum(int[] numbers, int target)
    {
        int leftPointer = 0, rightPointer = numbers.Length - 1;

        while (leftPointer < rightPointer) 
        { 
            int sum = numbers[leftPointer] + numbers[rightPointer];

            if (sum > target)
                rightPointer--;
            else if (sum < target)
                leftPointer++;
            else
                return new int[] { leftPointer + 1, rightPointer + 1 };
        }

        return new int[0];
    }

    //Ex 15
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        List<IList<int>> res = new List<IList<int>>();

        for (int i = 0; i< nums.Length; i++) 
        {
            if (nums[i] > 0) break; //para que a soma de 3 numeros diferentes seja 0, TEM que ter um numero negativo, se nao tiver, ja sai do loop e devolve uma lista vazia.
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int leftPointer = i + 1, rightPointer = nums.Length - 1;
            while(leftPointer < rightPointer) 
            { 
                int sum = nums[i] + nums[leftPointer] + nums[rightPointer];
                if (sum > 0)
                    rightPointer--;
                else if (sum < 0)
                    leftPointer++;
                else 
                {
                    res.Add(new List<int> { nums[i], nums[leftPointer], nums[rightPointer] });
                    leftPointer++;
                    rightPointer--;
                    while(leftPointer < rightPointer && nums[leftPointer] == nums[leftPointer - 1])
                        leftPointer++;
                }
            }
        }
        return res;
    }

    //Ex 11
    public int MaxArea(int[] height)
    {
        int res = 0;
        int leftPointer = 0, rightPointer = height.Length - 1;

        while (leftPointer < rightPointer) 
        {
            int area = (Math.Min(height[leftPointer], height[rightPointer])) * (rightPointer - leftPointer); //Para calcular a altura tem que pegar o menor valor entre o ponteiro esquerdo e direito, e para calcular a largura, basta pegar o indice do ponteiro direito e fazer menos o esquerdo.
            res = Math.Max(area, res);

            if (height[leftPointer] <= height[rightPointer])
                leftPointer++;
            else
                rightPointer--;
        }
        return res;
    }

    //Ex 42
    public int Trap(int[] height)
    {
        if (height == null || height.Length == 0)
            return 0;

        int leftPointer = 0, rightPointer = height.Length - 1;
        int leftMax = height[leftPointer], rightMax = height[rightPointer];
        int response = 0;

        while (leftPointer < rightPointer) 
        {
            if (leftMax < rightMax)
            {
                leftPointer++;
                leftMax = Math.Max(leftMax, height[leftPointer]);
                response += leftMax - height[leftPointer];
            }
            else 
            {
                rightPointer--;
                rightMax = Math.Max(rightMax, height[rightPointer]);
                response += rightMax - height[rightPointer];
            }
        }

        return response;
    }
}
