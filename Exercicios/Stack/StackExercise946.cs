namespace Exercicios.Stack;

public class StackExercise946
{
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        Stack<int> stack = new Stack<int>();
        int poppedReader = 0;

        for (int pushedReader = 0; pushedReader < pushed.Length; pushedReader++)
        {
            stack.Push(pushed[pushedReader]);

            if (stack.Count > 0) { 
                while (stack.Peek() == popped[poppedReader])
                {
                    stack.Pop();
                    poppedReader++;

                    if (stack.Count == 0)
                        break;
                }
            }
        }

        return stack.Count == 0 ? true : false;
    }
}
