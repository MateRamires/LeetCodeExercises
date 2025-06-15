
namespace Exercicios.Tries;

public class TrieNode 
{ 
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>(); //Cada node tera um filho, o filho sera um trieNode, e tera como chave o caractere que ele representa.
    public bool endOfWord = false; //Para cada trieNode teremos esse booleano indicando se esse trieNode eh ou nao o fim de uma palavra.
}

public class TrieExercise208
{
    private TrieNode root; //O root sempre sera vazio, ele sera o ponto de partida e tera possivelmente 26 filhos (cada letra do alfabeto)

    public TrieExercise208()
    {
        root = new TrieNode(); //Instanciamos o root node, que nao tera nenhum caractere associado.
    }

    public void Insert(string word)
    {
        TrieNode cur = root;
        foreach (char c in word) //Iremos iterar sob cada caractere da palavra a ser adicionada
        {
            if (!cur.children.ContainsKey(c)) //Para cada caractere EM ORDEM, iremos checar se existe na arvore, se nao existe, adicionamos o caractere a arvore como um novo node.
            {
                cur.children[c] = new TrieNode();
            }
            cur = cur.children[c]; //Depois de adicionar, agora o caractere atual eh o novo current, para nas proximas iteracoes checaremos os filhos DESSE node atual.
        }
        cur.endOfWord = true; //No fim, quando for adicionado a ultima letra, demarcaremos esse node como o fim da palavra.
    }

    public bool Search(string word)
    {
        TrieNode cur = root;
        foreach (char c in word) 
        {
            if (!cur.children.ContainsKey(c)) //Se alguma das letras na ordem nao exisit, automaticamente retornamos false, pq a palavra nao existe
            {
                return false;
            }
            cur = cur.children[c];
        }
        return cur.endOfWord; //Se todas as letras existirem na ordem certa, ainda no fim teremos que verificar se a ultima letra eh uma endOfWord = true, pois se nao for, entao a palavra que achamos eh apenas uma substring de outra palavra com o mesmo prefixo, mas a palavra em si, "nao existe" na arvore, apenas como uma substring de outra palavra maior.
    }

    public bool StartsWith(string prefix)
    {
        TrieNode cur = root;
        foreach (char c in prefix) 
        {
            if (!cur.children.ContainsKey(c)) //Mesma logica, se alguma das letras nao existir na arvore na ordem correta, entao automaticamente nao ha nenhuma palavra que comece com a string prefix, portanto ja retornamos false.
            {
                return false;
            }
            cur = cur.children[c];
        }
        return true; //A unica diferenca dessa funcao para a funcao Search, eh aque aqui nao precisamos saber se a endOfWord eh true ou nao, apenas se existem as letras na ordem certa, se sim, ja retornamos true, pois existe uma palavra que comeca com o prefixo passado como parametro.
    }
}
