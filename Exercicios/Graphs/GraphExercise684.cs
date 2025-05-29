namespace Exercicios.Graphs;

public class GraphExercise684
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        int n = edges.Length; //Numero de nodes totais que teremos
        List<List<int>> adjacent = new List<List<int>>(); //Criaremos uma lista para guardar todos os nodes adjacentes de um node especifico node (key) -> nodes adjacentes (value)

        //Abaixo iremos criar uma lista para cada node, pois cada node tera sua lista de nodes adjacente, por isso i <= n, pois TODOS os nodes terao uma lista de nodes adjacentes. Mas por agora, criaremos apenas uma lista de nodes, e cada node tera uma lista vazia, depois iremos preencher essa lista vazia com os adjacentes.
        for (int i = 0; i <= n; i++)
        {
            adjacent.Add(new List<int>());
        }

        foreach (var edge in edges)
        {
            //Primeiro nesse for iremos prencher a lista de nodes adjacentes com os respectivos nodes.
            adjacent[edge[0]].Add(edge[1]);
            adjacent[edge[1]].Add(edge[0]);

            bool[] visit = new bool[n + 1]; //Nos precisamos criar o array de visit com n + 1 pois esse exercicio é 1-based, ou seja, nao há node 0, o primeiro node é rotulado como 1, entao no array visit nos vamos ignorar o indice 0, e teremos 1 indice a mais que a quantidade de nodes, porem esse indice a mais (o 0) nem sera usado, so usaremos de 1 ate o total de nodes. Obs: pra cada iteração do foreach essa variavel é re-criada, portanto reiniciada.

            //Nos iremos chamar o DFS pra cada iteração do foreach, sera nessa logica que iremos achar o ciclo.
            if (DFS(edge[0], -1, adjacent, visit))
            {
                return new int[] { edge[0], edge[1] }; //Se o DFS em algum momento retornar true, quer dizer que la no DFS caiu no visit[node] == true, ou seja, ele visitou um node mais de uma vez nessa iteração, e portanto, tem um ciclo, e foi exatamente no EDGE atual que ocorreu esse ciclo. Por isso retornamos exatamente o edge atual como resposta, pois é o ultimo edge que causou o ciclo que estamos buscando.
            }
        }
        return new int[0]; //Caso nao haja ciclo, ai retornamos nada, pois nao há ciclo, nao há edge que transformou a arvore num grafo com ciclo.

    }

    private bool DFS(int node, int parent, List<List<int>> adjacent, bool[] visit)
    {
        if (visit[node]) return true; //Se nessa iteração do foreach da função principal, houver um cenario onde um node foi visitado mais de uma vez, tem um ciclo, portanto esse é o edge que criou o ciclo e transformou a arvore em grafo, entao retornamos true.

        visit[node] = true; //Caso o node nao tenha sido visitado, colocamos ele como um node visitado agora.

        //Iremos iterar sob todos os adjacentes do node atual
        foreach (int nei in adjacent[node])
        {
            if (nei == parent) continue; //Esse é o cenario onde nao ha problema um node que ja foi visitado ser visitado novamente, quando é o node parente do node atual. por isso pulamos ele, se nao pulassemos ele ia cair no visit erroneamente, pois nao ha ciclo, mas ele ja foi visitado.
            if (DFS(nei, node, adjacent, visit)) return true; //Chamamos de forma recursiva o DFS, se em algumas dessas recursoes cair no cenario onde tem um node ja visitado sendo visitado novamente, ele vai retornar true e cair aqui, que tambem retornara true, so que para a função principal, finalizando o problema.
        }
        return false; //Caso nenhum node visitado seja visitado novamente, retornamos false, nessa iteração, nao há ciclos.
    }
}
