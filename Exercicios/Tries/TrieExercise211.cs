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
        TrieNodeArray current = root;

        for (int i = j; i < word.Length; i++) 
        { 
            char c = word[i];
            if (c == '.')
            {
                foreach (TrieNodeArray child in current.children)
                {
                    if (child != null && Dfs(word, i + 1, child))
                    {
                        return true;
                    }
                }
                return false;
            }
            else 
            {
                if (current.children[c - 'a'] == null) 
                {
                    return false;
                }
                current = current.children[c - 'a'];
            }
        }
        return current.endOfWord;
    }
}
