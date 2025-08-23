namespace Exercicios.Stack;

public class StackExercise739TemperaturesRedone
{
    public int[] DailyTemperatures(int[] temperatures)
    { 
        var answer = new int[temperatures.Length];
        var stack = new Stack<int>();

        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()]) 
            {
                answer[stack.Peek()] = i - stack.Pop();
            }

            stack.Push(i);
        }

        return answer;
    }
}
