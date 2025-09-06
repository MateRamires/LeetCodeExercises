namespace Exercicios.Array___Hash;

internal class GroupAnagramsEx49
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var res = new Dictionary<string, IList<string>>();
        foreach (var str in strs)
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
        return res.Values.ToList();
    }

    public IList<IList<string>> GroupAnagramsSort(string[] strs)
    {
        var res = new Dictionary<string, IList<string>>();
        foreach (var str in strs) 
        {
            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);
            string sortedStr = new string(charArray);
            if (!res.ContainsKey(sortedStr)) 
            {
                res[sortedStr] = new List<string>();
            }
            res[sortedStr].Add(str);
        }

        return res.Values.ToList();
    }
}
