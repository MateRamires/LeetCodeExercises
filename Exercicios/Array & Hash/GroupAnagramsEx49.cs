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
}
