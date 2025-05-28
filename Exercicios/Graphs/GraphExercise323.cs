namespace Exercicios.Graphs;

public class GraphExercise323
{
    public int CountComponents(int n, int[][] edges)
    {
        List<List<int>> adjacent = new List<List<int>>();
        bool[] visited = new bool[n]; //Essa variavel vai guardar todos os nodes que ja visitamos, como temos certeza que vamos visitar todos os nodes, entao criamos um array de tamanho n, que eh exatamente a qnt de nodes.
        
        //Nesse for nos iremos preencher nossa lista criando uma lista vazia para cada elemento, mais a frente iremos prencher cada lista vazia com os nodes adjacentes de cada node. Sendo assim, a chave dessa lista sera o node e o valor sera uma lista de nodes adjacentes a esse node.
        for (int i = 0; i < n; i++) 
        {
            adjacent.Add(new List<int>()); ;
        }

        //Agora vamos preencher nossa lista adjacent com os nodes em questao como chave e os seus adjacentes como valor, como os edges sao nao-direcionados, iremos considerar que um edge tem dois gumes, ou seja, node 0 tem conexao com node 1 e node 1 tem conexao com node 0.
        foreach (var edge in edges) 
        {
            adjacent[edge[0]].Add(edge[1]);
            adjacent[edge[1]].Add(edge[0]); //Como foi escrito acima, faremos o "vice-versa" da conexao entre os nodes.
        }

        //Abaixo iremos iterar sob todos os nodes e chamaremos um DFS pra cada um, durante o DFS eh possivel que multiplos nodes sejam visitados a partir de um, quando isso acontecer, todos serao colocados na variavel visited, entao quando acabar o DFS, iremos adicionar +1 no response, pois temos mais um grafo independente, e nossa variavel visited tera possivelmente multiplos nodes, que serao pulados caso ja tenham sido visitados durante o DFS.
        int response = 0;
        for (int node = 0; node < 0; node++) 
        {
            if (!visited[node]) //Aqui a linha que pula os nodes que ja foram visitados, para que sempre possamos criar os grafos independentes com nodes nao utilizados. Nao ha pq rodar DFS em um node que ja foi visitado, pois ele ja faz parte de um grafo independente.
            {
                DFS(adjacent, visited, node);
                response++; //Sempre ao final de um DFS temos um grafo independente, mas possivelmente teremos mais, por isso estamos rodando um for, mas no fim de um DFS sempre adicionaremos + 1 grafo independente a resposta.
            }
        }
        return response;
    }

    private void DFS(List<List<int>> adjacent, bool[] visited, int node)
    {
        visited[node] = true; //A primeira coisa que faremos pra cada chamada recursiva do DFS eh colocar o node atual na lista de visited, pois esse node agora ja foi visitado, nao iremos mais considerar ele nas proximas iteracoes do nosso for da funcao principal.

        foreach (var nei in adjacent[node]) //Iremos rodar um DFS pra cada vizinho do node atual.
        {
            if (!visited[nei]) //Igual a logica do for na nossa funcao principal, iremos desconsiderar nodes que ja foram visitados antes, pois eles ja foram visitados, portanto nao precisamos mais considera-los.
            {
                DFS(adjacent, visited, nei); //Agora caso o node ainda seja novo e nao visitado, ai iremos chamar recursivamente o DFS, onde dentro desse DFS chamaremos os vizinhos desse node e iremos colocar esse node como visitado.
            }
        }
    
    }
}
