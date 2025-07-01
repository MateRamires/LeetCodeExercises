namespace Exercicios.Stack;

public class StackExercise682
{
    public int CalPoints(string[] operations)
    {
        Stack<int> points = new Stack<int>();
        for (int i = 0; i < operations.Length; i++)
        {
            if (operations[i] == "+")
            {
                var aux = points.Pop();
                var lastTwoElementsSum = aux + points.Peek();
                points.Push(aux);
                points.Push(lastTwoElementsSum);
            }
            else if (operations[i] == "D")
            {
                points.Push(points.Peek() * 2);
            }
            else if (operations[i] == "C")
            {
                points.Pop();
            }
            else 
            {
                points.Push(int.Parse(operations[i]));
            }
        }

        return points.Sum();
    }
}
