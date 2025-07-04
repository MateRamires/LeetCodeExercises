using System.Text;

namespace Exercicios.Stack;

public class StackExercise2390
{
    public string RemoveStars(string s)
    {
        StringBuilder stack = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '*') 
                stack.Remove(stack.Length - 1, 1);
            else
                stack.Append(s[i]);
            
        }

        return stack.ToString();
    }
}
