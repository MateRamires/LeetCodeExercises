namespace Exercicios.Stack;

public class ValidParenthesisEx20
{
    public bool IsValid(string s)
    {
        //O mais recente que se abriu, eh o proximo que tem que se fechar.
        var stack = new Stack<char>();
        var closeToOpen = new Dictionary<char, char>() { { ']','[' }, { ')', '('}, { '}', '{' } };

        foreach (char c in s) 
        {
            if (closeToOpen.ContainsKey(c)) 
            {
                if (stack.Count > 0 && stack.Peek() == closeToOpen[c])
                    stack.Pop();
                else
                    return false;
            }
            else
                stack.Push(c);
        }

        return stack.Count == 0;
    }
}
