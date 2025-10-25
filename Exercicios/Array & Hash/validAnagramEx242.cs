using System.Collections.Generic;

namespace Exercicios.Array___Hash;

public class validAnagramEx242
{
    public bool IsAnagram(string s, string t)
    {
        if(s.Length != t.Length)
            return false;

        var dict = new Dictionary<char, int>();
        var dict2 = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!dict.ContainsKey(s[i]))
                dict.Add(s[i], 0);

            dict[s[i]]++;

            if (!dict2.ContainsKey(t[i]))
                dict2.Add(t[i], 0);

            dict2[t[i]]++;
        }
       
        return dict.Count == dict2.Count && !dict.Except(dict2).Any();     
    }
}
