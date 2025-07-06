namespace Exercicios.Stack;

public class StackExercise739TemperaturesRedone
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] answer = new int[temperatures.Length];
        Stack<int[]> temperatureStack = new Stack<int[]>();

        for (int i = 0; i < temperatures.Length; i++) 
        {

            while (temperatureStack.Count > 0 && temperatures[i] > temperatureStack.Peek()[0]) 
            {
                var temp = temperatureStack.Pop();

                answer[temp[1]] = i - temp[1];
            }

            temperatureStack.Push(new int[] { temperatures[i], i });
        }

        return answer;
    }
}
