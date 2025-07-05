namespace Exercicios.Array___Hash;

public class ArrayHashExercise1394
{
    public int FindLucky(int[] arr)
    {
        Dictionary<int, int> values = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (!values.TryAdd(arr[i], 1))
                values[arr[i]]++;
        }

        foreach (var kpv in values) 
        { 
            if(kpv.Key != kpv.Value)
                values.Remove(kpv.Key);
        }

        return values.Count > 0 ? values.Keys.Max() : -1;

    }
}
