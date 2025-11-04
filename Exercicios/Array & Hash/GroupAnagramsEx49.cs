using System.Linq;

namespace Exercicios.Array___Hash;

public class GroupAnagramsEx49
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var res = new Dictionary<string, IList<string>>();
        foreach (var str in strs)
        {
            int[] count = new int[26];
            foreach (char c in str)
                count[c - 'a']++; //Criamos uma chave que corresponde as letras da string.
              
            string key = string.Join(",", count);
            if (!res.ContainsKey(key)) 
                res[key] = new List<string>();

            res[key].Add(str);
        }

        return res.Values.ToList<IList<string>>();
    }
}
