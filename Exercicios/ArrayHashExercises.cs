namespace Exercicios;

public class ArayHashExercises
{
    //Ex 217
    public bool HasDuplicate(int[] nums)
    {
        HashSet<int> seen = new HashSet<int>();
        foreach (int num in nums)
        {
            if (seen.Contains(num))
            {
                return true;
            }
            seen.Add(num);
        }
        return false;
    }

    //Ex 242
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        /*char[] sSorted = s.ToCharArray();
        char[] tSorted = t.ToCharArray();

        Array.Sort(sSorted);
        Array.Sort(tSorted);

        return sSorted.SequenceEqual(tSorted);*/

        Dictionary<char, int> CountS = new Dictionary<char, int>();
        Dictionary<char, int> CountT = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            CountS[s[i]] = CountS.GetValueOrDefault(s[i], 0) + 1;
            CountT[t[i]] = CountT.GetValueOrDefault(t[i], 0) + 1;
        }

        return CountS.Count == CountT.Count && !CountS.Except(CountT).Any();
    }

    //Ex 1
    public int[] TwoSum(int[] nums, int target)
    {
        //Solucao "Brute Force"
        /*for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target) 
                {
                    return [i, j];
                } 
            }
        }
        return new int[0];*/



        Dictionary<int, int> numMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (numMap.ContainsKey(complement))
            {
                return new int[] { numMap[complement], i };
            }

            numMap[nums[i]] = i;
        }

        return null;
    }

    //Ex 49
    public List<List<string>> GroupAnagram(string[] strs)
    {
        var res = new Dictionary<string, List<string>>();
        foreach (string str in strs)
        {
            int[] count = new int[26];
            foreach (char c in str)
            {
                count[c - 'a']++;
            }
            string key = string.Join(",", count);
            if (!res.ContainsKey(key))
            {
                res[key] = new List<string>();
            }
            res[key].Add(str);
        }
        return res.Values.ToList<List<string>>();
    }

    //Ex 347
    public int[] TopKFrequent(int[] nums, int k)
    {
        var numbersDict = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (!numbersDict.ContainsKey(num))
                numbersDict[num] = 1;
            else
                numbersDict[num]++;
        }

        return numbersDict.OrderByDescending(n => n.Value).Take(k).Select(c => c.Key).ToArray();
    }



    //Ex 271 - Pt. 1
    public string Enconde(IList<string> strs)
    {
        //Colocar o numero de letras seguidos por "#" antes de cada string
        var res = string.Empty;
        foreach (string str in strs)
        {
            res += str.Length + "#" + str;
        }

        return res;
    }

    //Ex 271 - Pt. 2
    public IList<string> Decode(string str)
    {
        List<string> res = new List<string>();
        int i = 0;
        while (i < str.Length)
        {
            int j = i;
            while (str[j] != '#')
            {
                j++;
            }
            int length = int.Parse(str.Substring(i, j - i));
            i = j + 1;
            j = i + length;
            res.Add(str.Substring(i, length));
            i = j;
        }
        return res;
    }

    //Ex 13
    public int RomanToInt(string s)
    {
        var romans = new Dictionary<char, int>();
        romans.Add('I', 1);
        romans.Add('V', 5);
        romans.Add('X', 10);
        romans.Add('L', 50);
        romans.Add('C', 100);
        romans.Add('D', 500);
        romans.Add('M', 1000);

        var chars = s.ToCharArray();

        int result = 0;
        for (int i = 0; i < chars.Length; i++)
        {
            if (i < chars.Length - 1 && romans[chars[i]] < romans[chars[i + 1]])
            {
                result += romans[chars[i + 1]] - romans[chars[i]];
                i++;
            }
            else
                result += romans[chars[i]];
        }

        return result;
    }



    //Ex 1941
    public bool AreOccurrencesEqual(string s)
    {
        var occurrences = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (!occurrences.ContainsKey(c))
                occurrences[c] = 1;
            else
                occurrences[c]++;
        }

        return occurrences.Values.All(v => v == occurrences.Values.First());
    }



    //Ex 2068
    public bool CheckAlmostEquivalent(string word1, string word2)
    {
        var dict1 = new Dictionary<char, int>();
        var dict2 = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (!dict1.ContainsKey(c))
                dict1[c] = 1;
            else
                dict1[c]++;
        }

        foreach (char c in word2)
        {
            if (!dict2.ContainsKey(c))
                dict2[c] = 1;
            else
                dict2[c]++;
        }

        for (char c = 'a'; c <= 'z'; c++)
        {
            int freq1 = dict1.ContainsKey(c) ? dict1[c] : 0;
            int freq2 = dict2.ContainsKey(c) ? dict2[c] : 0;

            if (Math.Abs(freq1 - freq2) > 3)
                return false;
        }

        return true;

    }

    //Ex 36
    public bool IsValidSudoku(char[][] board)
    {
        Dictionary<int, HashSet<char>> cols = new Dictionary<int, HashSet<char>>();
        Dictionary<int, HashSet<char>> rows = new Dictionary<int, HashSet<char>>();
        Dictionary<string, HashSet<char>> squares = new Dictionary<string, HashSet<char>>();

        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                if (board[r][c] == '.') continue;

                string squareKey = (r / 3) + "," + (c / 3);

                if ((rows.ContainsKey(r) && rows[r].Contains(board[r][c])) ||
                    (cols.ContainsKey(c) && cols[c].Contains(board[r][c])) ||
                    (squares.ContainsKey(squareKey) && squares[squareKey].Contains(board[r][c])))
                {
                    return false;
                }

                if(!rows.ContainsKey(r)) rows[r] = new HashSet<char>();
                if(!cols.ContainsKey(c)) cols[c] = new HashSet<char>();
                if(!squares.ContainsKey(squareKey)) squares[squareKey] = new HashSet<char>();

                rows[r].Add(board[r][c]);
                cols[c].Add(board[r][c]);
                squares[squareKey].Add(board[r][c]);
            }
        }

        return true;
    }

    //Ex 128
    public int LongestConsecutive(int[] nums)
    {
        Dictionary<int, int> mp = new Dictionary<int, int>();
        int res = 0;

        foreach(int num in nums) 
        {
            if (!mp.ContainsKey(num))
            {
                mp[num] = (mp.ContainsKey(num - 1) ? mp[num - 1] : 0) +
                          (mp.ContainsKey(num + 1) ? mp[num + 1] : 0) + 1;

                mp[num - (mp.ContainsKey(num - 1) ? mp[num - 1] : 0)] = mp[num];
                mp[num + (mp.ContainsKey(num + 1) ? mp[num + 1] : 0)] = mp[num];

                res = Math.Max(res, mp[num]);
            }
        }
        return res;
    }

    //Ex 238
    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        int[] res = new int[n];
        int[] prefix = new int[n];
        int[] suffix = new int[n];

        prefix[0] = 1;
        suffix[n - 1] = 1;
        for (int i = 1; i < n; i++) 
        {
            prefix[i] = nums[i - 1] * prefix[i - 1];
        }

        for (int i = n - 2; i >= 0; i--)
        {
            suffix[i] = nums[i + 1] * suffix[i + 1];
        }

        for (int i = 0; i < n; i++)
        {
            res[i] = prefix[i] * suffix[i];
        }
        return res;
    }
}