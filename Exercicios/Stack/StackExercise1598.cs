namespace Exercicios.Stack;

public class StackExercise1598
{
    public int MinOperations(string[] logs)
    {
        Stack<int> operations = new Stack<int>();
        int folderDepth = 0;

        for (int i = 0; i < logs.Length; i++)
        {
            if (logs[i] == "../")
            {
                if (folderDepth > 0) 
                {
                    operations.Push(-1);
                    folderDepth--;
                }
            }
            else if (logs[i] != "./")
            {
                operations.Push(1);
                folderDepth++;
            }
        }

        return operations.Sum();
    }
}
