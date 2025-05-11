namespace Exercicios.Backtracking;

public class BacktrackingExercises
{
    //Ex 78
    public IList<IList<int>> Subsets(int[] nums)
    {
        var res = new List<IList<int>>(); //Essa sera nossa lista contendo todos os subsets
        var subset = new List<int>(); //Esse sera um unico subset, por vez.
        DfsEx78(nums, 0, subset, res);
        return res;
    }

    private void DfsEx78(int[] nums, int i, List<int> subset, List<IList<int>> res) 
    {
        if (i >= nums.Length) //Esse eh o base case do DFS.
        {
            res.Add(new List<int>(subset)); //Quando atingirmos o base-case, nos adicionamos o subset em questao a nossa lista de resultado
            return; //E retornamos, pois chegamos ao fim desse fio.
        }

        //O codigo abaixo representa o cenario onde adicionamos o numero em questao, pois pra cada numero teremos 2 possibilidades, adiciona-lo ao subset, ou nao adiciona-lo.
        subset.Add(nums[i]); //Aqui nos vamos adicionar o numero ao subset.
        DfsEx78(nums, i + 1, subset, res); //E aqui nos vamos enviar esse subset com o numero adicionado e o "i" incrementado, para que possamos analisar o proximo numero de nums.

        //Ja esse codigo representa o cenario onde nao vamos adicionar o numero atual ao subset, como ja adicionamos ele na linha anterior, agora nos vamos remove-lo
        subset.RemoveAt(subset.Count - 1); //Removendo o numero mais recente, no caso, o que acabou de ser adicionado.
        DfsEx78(nums, i + 1, subset, res); //E agora vamos para o proximo numero do array de inteiros, so que dessa vez sem o numero anterior no subset, e assim vao se formando todos os subsets diferentes.
    }

    //Ex 39
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> res = new List<IList<int>>();
        backtrack(0, new List<int>(), 0, candidates, target, res);
        return res;
    }

    public void backtrack(int i, List<int> cur, int total, int[] nums, int target, List<IList<int>> res)
    {
        if (total == target) //A variavel total vai guardar o valor da soma do nosso array current, caso total seja exatamente igual ao target, podemos adicionar o array como uma das possiblidades de soma de numeros para chegar no valor target.
        {
            res.Add(cur.ToList()); //Adicionamos o current com os valores para nossa lista resposta.
            return; //E podemos dar return pois esse if eh um "base-case".
        }

        if (total > target || i >= nums.Length)  //Agora, caso o total ultrapasse o target, ai entramos nesse outro "base-case", so que nesse caso, nao vamos adicionar a nossa lista de respostas. Alem disso, esse base-case vai verificar se nosso i ultrapassou o array, pois se o i for maior que o array de candidatos, ai nao tem mais numero para se analisar e acabou o processamento.
            return;

        //Nessas 2 linhas temos o caso onde vamos adiicionar o numero atual no nosso current.
        cur.Add(nums[i]); //Aqui adicionamos o numero atual a nossa resposta.
        backtrack(i, cur, total + nums[i], nums, target, res); //E comecamos a recursao, vamos continuar analisando o numero atual (pois podemos repetir o mesmo numero infinitas vezes), passando a lista curr, que contera o numero que acabamos de adicionar, o total sera ele mesmo + o proprio numero que estamos analisando (pois vamos somando esse numero ate chegar ou ultrapassar o target), e por fim passamos o mesmo array de numeros, o mesmo target e a lista response final.

        //Ja nessas 2 linhas, nos nao vamos mais adicionar o valor atual ao current, e vamos andar uma casa no array de candidatos, para ir ao proximo numero.
        cur.Remove(cur.Last()); //Removemos o numero que adicionamos acima, pois nesse caso, nao vamos mais adicionar o mesmo numero mais, vamos ir para o proximo.
        backtrack(i + 1, cur, total, nums, target, res); //A diferenca dessa chamada de recursao da de cima eh que aqui nao incrementamos a variavel total, pois nao adicionamos o numero atual, e alem disso, colocamos i + 1, pois vamos apartir daqui comecar a analisar o proximo numero do array nums/candidates.
    }
}
