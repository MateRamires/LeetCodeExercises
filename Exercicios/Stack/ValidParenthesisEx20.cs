namespace Exercicios.Stack;

public class ValidParenthesisEx20
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        var closeToOpenDict = new Dictionary<char, char> { { ')', '(' } , { '}', '{'} , { ']','[' } };

        foreach (char c in s) 
        {
            if (closeToOpenDict.ContainsKey(c)) //Se o caractere atual eh de fechamento...
            {
                if (stack.Count > 0 && stack.Peek() == closeToOpenDict[c]) //Tem que haver elementos na stack, se nao, entao estamos em um cenario onde fechamos algo sem ter aberto, retorna falso. E o outro cenario, eh que o value do elemento atual (que eh um fechamento) eh exatamente igual ao proximo elemento da stack, ou seja, a abertura.
                    stack.Pop();
                else
                    return false;
            }
            else //Se nao for de fechamento, eh de abertura.
            { 
                stack.Push(c);
            }
        }

        return stack.Count == 0 ? true : false;
    }
}
