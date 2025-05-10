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
}
