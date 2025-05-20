namespace Exercicios.Graphs;
public class GraphExercise133
{
    public Node CloneGraph(Node node) //Um node tem um valor e uma lista de nodes neighbors, ou seja, cada node tem um valor a si mesmo e uma quantidade ilimitada de possiveis vizinhos, que tambem sao nodes.
    {
        Dictionary<Node, Node> oldToNew = new Dictionary<Node, Node>(); //Esse hashmap ira mapear os nodes originais para os nodes atuais.
        return Dfs(node, oldToNew); //Vamos retornar o DFS, pois o DFS vai nos retornar no fim das contas, a copia exata do grafo.
    }

    private Node Dfs(Node node, Dictionary<Node, Node> oldToNew) 
    {
        if (node == null) //Para cuidar do edge-case caso o grafo nao tenha nada.
            return null;

        if (oldToNew.ContainsKey(node)) //Primeiro checamos se o node que estamos analisando atualmente ja existe no nosso hashMap, se sim, entao significa que ja fizemos um clone desse node.
            return oldToNew[node]; //Nesse caso, vamos retornar apenas o priprio clone, nao vamos criar nada, nos temos que retornar o node copiado, pois se caimos nessa condicao, isso quer dizer que algum node tem esse node como vizinho, portanto temos que retornar a propria copia para prencher esse vizinho deste node x com o node copiado.

        Node copy = new Node(node.val); //Criamos o node copia do node original
        oldToNew[node] = copy; //Mapeamos esse node, onde a chave sera o node original, e o valor sera o node novo

        foreach(Node neighbor in node.neighbors) //Aqui vamos iterar sob TODOS os vizinhos do node atual
            copy.neighbors.Add(Dfs(neighbor, oldToNew)); //Para cada vizinho, iremos adicionar o node que ira sair do DFS, por isso mais acima criamos a condicao onde checamos se o node ja foi criado, pois se ele ja foi criado, nao vamos criar uma outra copia dele, e nem vamos ver os vizinhos dele, pois ja vimos, POREM, iremos adicionar esse node como vizinho do node que esta sendo analisado, por isso retornamos o node.

        return copy; //Caso nao caia em nenhuma das 2 condicoes, nos iremos retornar o node que acabou de ser copiado. E na ultima iteracao, ira retornar o grafo completo para nossa funcao principal.
    }
}
