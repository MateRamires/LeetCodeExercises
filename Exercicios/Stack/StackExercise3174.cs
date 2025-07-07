using System.Text;

namespace Exercicios.Stack;

public class StackExercise3174
{
    public string ClearDigits(string s)
    {

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            
            else 
                stringBuilder.Append(s[i]);
        }

        return stringBuilder.ToString();
    }
}
