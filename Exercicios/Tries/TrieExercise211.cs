namespace Exercicios.Tries;

public class TrieNodeArray() 
{
    public TrieNodeArray[] children = new TrieNodeArray[26];
    public bool endOfWord = false;
}

public class TrieExercise211
{
    private TrieNodeArray root;
    public TrieExercise211() 
    { 
        root = new TrieNodeArray();
    }

    public void AddWord(string word)
    {
        TrieNodeArray currentNode = root;
        foreach (char c in word) 
        {
            if (currentNode.children[c - 'a'] == null)
            {
                currentNode.children[c - 'a'] = new TrieNodeArray();
            }
            currentNode = currentNode.children[c - 'a'];
        }
        currentNode.endOfWord = true;
    }

    public bool Search(string word)
    {
        return Dfs(word, 0, root);
    }

    private bool Dfs(string word, int j, TrieNodeArray root)
    {
        TrieNodeArray current = root; //Pegamos o node atual, de inicio, o node sera o root, que eh vazio, mas tem 26 filhos, sendo cada uma das letras do alfabeto.

        for (int i = j; i < word.Length; i++) 
        { 
            char c = word[i]; //Pegamos a letra i da palavra em questao que estamos buscando
            if (c == '.')
            {
                foreach (TrieNodeArray child in current.children) //Se a letra for ".", entao nos temos que checar todos os filhos do node atual (os 26 filhos) e ver se ALGUM deles tem um valor, pois o "." eh um curinga, qualquer letra do alfabeto que nao for nula pode ser valida aqui.
                {
                    if (child != null && Dfs(word, i + 1, child)) //Primeiro checamos se o filho for nulo, pois se for nulo, entao essa letra nao existe na nossa arvore trie. Depois fazemos um DFS para cada letra/node que nao for nulo, buscando a palavra, entao digamos que a palavra eh ". a d", quando checamos que o primeiro caractere eh "." agora vamos buscar todas as 26 letras possiveis para a posicao ., se tiver 8 letras/nodes nao nulos, nos iremos chamar 8 DFS, e para cada DFS iremos analisar as proximas letras com base nessas 8 letras iniciais, tipo buscaremos cad-mad-bad-sad-rad etc, se alguma dessas existir, ja retornamos true e acaba o processo.
                    {
                        return true;
                    }
                }
                return false;
            }
            else //Se a letra nao for ., entao teremos que checar se essa letra existe como filho do node atual, dessa vez a letra exata deve existir, se nao existir, retornamos false.
            {
                if (current.children[c - 'a'] == null) //A letra em questao nao existe como um dos filhos do node atual, portanto, a palavra nao existe na arvore trie, retornamos false ja.
                {
                    return false;
                }
                current = current.children[c - 'a']; //Agora se a letra existir, ai agora o currentNode sera a nova letra, e iremos analisar os filhos dessa proxima letra/node, buscando a proxima letra da palavra que estamos buscando em questao.
            }
        }
        return current.endOfWord; //No fim, se a palavra for de fato encontrada, teremos que por fim checar se ela eh uma PALAVRA mesmo ou so uma substring de outra palavra maior, se for uma substrign, ai retornaremos false igual, agora se a palavra em questao realmente existir, ai sim retornamos true.
    }
}
