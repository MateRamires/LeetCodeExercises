namespace Exercicios.Stack;

public class StackExercise225
{
    Queue<int> q1;
    public StackExercise225()
    {
        q1 = new Queue<int>();
    }

    public void Push(int x)
    {
        q1.Enqueue(x);
        for (int i = 0; i < q1.Count - 1; i++) 
        { 
            q1.Enqueue(q1.Dequeue());
        }
        
    }

    public int Pop()
    {
        return q1.Dequeue();
    }

    public int Top()
    {
        return q1.Peek();
    }

    public bool Empty()
    {
        return q1.Count == 0;
    }
}
