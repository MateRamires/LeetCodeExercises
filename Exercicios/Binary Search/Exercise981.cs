namespace Exercicios.Binary_Search;

public class Exercise981
{
    private Dictionary<string, List<Tuple<int, string>>> keyStore;
    public Exercise981()
    {
        keyStore = new Dictionary<string, List<Tuple<int, string>>>();
    }

    public void Set(string key, string value, int timestamp)
    {
        if (!keyStore.ContainsKey(key)) 
            keyStore[key] = new List<Tuple<int, string>>();
        
        keyStore[key].Add(Tuple.Create(timestamp, value));
    }

    public string Get(string key, int timestamp)
    {
        if (!keyStore.ContainsKey(key))
            return "";

        var values = keyStore[key]; //Aqui pegamos o array (ou tuple, no caso) de pares referentes a chave passada como parametro.
        int left = 0, right = values.Count - 1;
        string result = "";

        while(left <= right) 
        {
            int mid = left + ((right - left) / 2);
            if (values[mid].Item1 <= timestamp) //Aqui estamos checando se o valor do meio eh MENOR ou igual ao timestamp passado. Menor pois, se o valor for menor, ele eh valido, porem pode haver um match exato, mas por agora salvamos o menor, e movemos o ponteiro esquerdo para o meio + 1, para ver se achamos um valor maior ou igual ao timestamp, uma vez que os timestamps das duplas de valores estao em ordem crescente.
            {
                result = values[mid].Item2; //Salvamos em resultado pois caso seja um valor menor que o timestamp passado, esse valor PODE ser o mais proximo, entao como ha essa possibilidade, ja salvamos no result.
                left = mid + 1; 
            }
            else 
            {
                right = mid - 1; //Caso o valor de timestamp do meio do nosso binary search seja maior que oq queremos achar, precisaremos mover o ponteiro direito, pois precisamos de valores MENORES, e nao maiores,
            }
        }

        return result;
    }
}
