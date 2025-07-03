using System.Text;

namespace Exercicios.Stack;

public class StackExercise1544
{
    public string MakeGood(string s)
    {
        StringBuilder stack = new StringBuilder();

        for (int i = 0; i < s.Length; i++) 
        {
            if (stack.Length > 0 && Math.Abs(stack[stack.Length - 1] - s[i]) == 32)
                stack.Remove(stack.Length - 1, 1);
            else
                stack.Append(s[i]);
        }

        return stack.ToString();
    }
}
