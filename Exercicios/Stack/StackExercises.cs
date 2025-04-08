namespace Exercicios.Stack;

public class StackExercises
{
    //Ex 20
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();

        Dictionary<char, char> closeToOpen = new Dictionary<char, char> {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

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
            {
                stack.Push(c);
            }
        }

        return stack.Count == 0;
    }

    //Ex 150
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new Stack<int>();

        foreach (string c in tokens) 
        {
            if (c == "+")
            {
                stack.Push(stack.Pop() + stack.Pop());
            }
            else if (c == "-")
            {
                int a = stack.Pop();
                int b = stack.Pop();
                stack.Push(b - a);
            }
            else if (c == "*")
            {
                stack.Push(stack.Pop() * stack.Pop());
            }
            else if (c == "/")
            {
                int a = stack.Pop();
                int b = stack.Pop();
                stack.Push((int) ((double) b / a));
            }
            else 
            {
                stack.Push(int.Parse(c));
            }
        }
        return stack.Pop();
    }

    //Ex 739
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] res = new int[temperatures.Length];
        Stack<int[]> stack = new Stack<int[]>(); 

        for (int i = 0; i < temperatures.Length; i++)
        {
            int temp = temperatures[i];
            while (stack.Count > 0 && temp > stack.Peek()[0]) //Se houver algum dado na stack E a temperatura atual for maior que a temperatura da stack (temperatura antiga)
            {
                int[] pair = stack.Pop();
                res[pair[1]] = i - pair[1]; //Do par vindo do stack, o segundo elemento eh a posicao do elemento original, e o i - pair[i) sera a distancia entre o dia original e o dia que estava mais calor.
            }
            stack.Push(new int[] { temp, i });
        }
        return res;
    }

    //Ex 853
    public int CarFleet(int target, int[] position, int[] speed)
    {
        int[][] pair = new int[position.Length][];
        for (int i = 0; i < position.Length; i++)
        {
            pair[i] = new int[] { position[i], speed[i] };
        }
        Array.Sort(pair, (a, b) => b[0].CompareTo(a[0]));
        Stack<double> stack = new Stack<double>();
        foreach (var p in pair) 
        {
            stack.Push((double)(target - p[0]) / p[1]);
            if (stack.Count >= 2 && stack.Peek() <= stack.ElementAt(1)) 
            {
                stack.Pop();
            }
        }
        return stack.Count;
    }

    //Ex 22
    private void Backtrack(int openParenthesesCount, int closedParanthesesCount, int n, IList<string> res, string stack) 
    {
        if (openParenthesesCount == closedParanthesesCount && openParenthesesCount == n) 
        {
            res.Add(stack);
            return;
        }

        if (openParenthesesCount < n)
            Backtrack(openParenthesesCount + 1, closedParanthesesCount, n, res, stack + '(');

        if (closedParanthesesCount < openParenthesesCount)
            Backtrack(openParenthesesCount, closedParanthesesCount + 1, n, res, stack + ')');
    }

    public IList<string> GenerateParenthesis(int n)
    {
        IList<string> res = new List<string>();
        string stack = "";
        Backtrack(0, 0, n, res, stack);
        return res;
    }

    //Ex 84

}
