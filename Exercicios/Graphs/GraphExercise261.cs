namespace Exercicios.Graphs;

public class GraphExercise261
{
    public bool ValidTree(int n, int[][] edges)
    {
        //Uma arvore valida SEMPRE deve ter EXATAMENTE (n - 1) conexoes (edges), pois por exemplo, 1 node tera 0 conexoes; 2 nodes, tera 1 aresta (conectando os 2 nodes); 3 nodes tera 2 conexoes (conectando os 3 nodes). Sendo assim, se o numero de conexoes for MAIOR que nodes - 1, entao o grafo nao pode ser um arvore, pois teremos com certeza um ciclo.
        if (edges.Length > n - 1) 
            return false;

        //Vamos criar uma lista que ira conter todos os nodes e seus vizinhos, nesse primeiro for, iremos preencher a lista com a quantidade de nodes.
        List<List<int>> adjacent = new List<List<int>>();
        for (int i = 0; i < n; i++) 
        { 
            adjacent.Add(new List<int>()); //Exemplo, se tiver 5 nodes (n = 5), iremos criar 5 elementos na lista.
        }

        //Ja aqui iremos prencher a lista com os nodes adjacentes, lembrando que os edges sao nao-direcionados, entao temos que ligar os vizinhos com duas direcoes. Por exemplo, do node1 para o node2, e do node2 para o node1. Assim, no final da lista teremos todos os nodes, e os seus vizinhos.
        foreach (var edge in edges) 
        {
            adjacent[edge[0]].Add(edge[1]); 
            adjacent[edge[1]].Add(edge[0]);
        }

        HashSet<int> visited = new HashSet<int>();
        if (!Dfs(0, -1, visited, adjacent)) //Para cada iteracao do DFS iremos passar o parente do node atual, como o node atual sera o primeiro node, entao na teoria ele nao tem parente, por isso enviamos -1 como parente, pois vamos considerar -1 como parente, um valor default.
        {
            return false; //Se em algum cenario o DFS falhar (retornar false) entao isso quer dizer que a arvore binaria nao eh valida, portanto ja retornamos false.
        }

        return visited.Count == n; //Se o codigo passar pelo DFS com sucesso, isso quer dizer que nao ha um ciclo, portanto nesse quesito, eh uma arvore binaria valida. Porem, temos que considerar que eh possivel nao ter um ciclo, mas ainda sim, pode haver um node separado dos outros, e se isso acontecer (um node sem vizinhos, isolado) ai a arvore nao eh valida tbm, por isso faremos visited.count == n, para ver se todos os nodes que visitamos da exatamente a quantidade total de nodes do exercicio. Se sim, ai retornamos true, a arvore eh valida, se nao, ai false.
    }

    private bool Dfs(int node, int parent, HashSet<int> visited, List<List<int>> adjacent) 
    {
        if (visited.Contains(node)) //Se visitarmos um node que ja visitamos, entao ha um ciclo, portanto a arvore eh invalida, retornamos false.
            return false; 

        visited.Add(node); //Adicionamos o node atual a visited, pois agora esse node foi visitado.

        //Vamos iterar sob todos os vizinhos do node atual.
        foreach (var nei in adjacent[node]) 
        {
            if (nei == parent)
                continue; //Como os vizinhos sao nao-direcionados, entao o node-pai de cada node (que ja visitamos anteriormente) estara como um dos vizinhos, entao por isso enviamos o parent como parametro da funcao, pois vamos checar se o vizinho que estamos analisando eh o node-pai, se for, pulamos (continue), pois esse node ja foi analisado anteriormente, e nao podemos chamar o DFS pra ele, ou se nao vai cair no nodes ja visitados e retorar false, achando que tem um loop, sendo que, nesse cenario eh um falso positivo, nao ha loop.
            
            if (!Dfs(nei, node, visited, adjacent)) //Chamamos o DFS para o node vizinho, agora o node atual sera o node-pai (o segundo parametro).
                return false; //Caso em algum dos vizinhos seja detectado um ciclo, ai vai cair na condicao do if, portanto retornamos false para tudo, pois tem um ciclo, a arvore inteira nao eh mais valida.
            
        }

        return true; //Se o node atual passar pela verificacao do ciclo, e passar pela verificacao dos seus vizinhos serem validos tambem, entao esse node eh valido, portanto retornamos true. Se todos os nodes forem validos, o ultimo node da recursao retornara true para nossa funcao principal, e portanto a possivel arvore binaria nao tem nenhum ciclo.
    }
}
