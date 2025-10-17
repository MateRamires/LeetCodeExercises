namespace Exercicios.Stack;

public class ValidParenthesisEx20
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        var dictClosedParanthesisToOpen = new Dictionary<char, char>() { { '}', '{' }, { ']', '[' }, { ')', '(' } };

        foreach (char c in s) 
        {
            if (dictClosedParanthesisToOpen.ContainsKey(c))
            {
                if (stack.Count >= 1 && dictClosedParanthesisToOpen[c] == stack.Peek())
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
