namespace Exercicios.Array___Hash;

public class ArrayHashExercise705
{
    public bool[] booleanArray;
    public ArrayHashExercise705()
    {
        booleanArray = new bool[1000001];
    }

    public void Add(int key)
    {
        booleanArray[key] = true;
    }

    public void Remove(int key)
    {
        booleanArray[key] = false;
    }

    public bool Contains(int key)
    {
        if (booleanArray[key] == true)
            return true;
        else
            return false;
    }
}
