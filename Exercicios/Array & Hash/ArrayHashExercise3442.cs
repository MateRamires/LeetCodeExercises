namespace Exercicios.Array___Hash;

public class ArrayHashExercise3442
{
    public int MaxDifference(string s)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (char c in s) 
        { 
            if (!dict.TryAdd(c, 1))
                dict[c]++;
        }

        int highestEven = 0, highestOdd = 0;
        int lowestOdd = int.MaxValue, lowestEven = int.MaxValue;

        foreach (var item in dict) 
        {
            if (item.Value % 2 == 0)
            {
                highestEven = Math.Max(highestEven, item.Value);
                lowestEven = Math.Min(lowestEven, item.Value);
            }
            else 
            { 
                highestOdd = Math.Max(highestOdd, item.Value);
                lowestOdd = Math.Min(lowestOdd, item.Value);
            }
        }

        return Math.Max(lowestOdd - highestEven, highestOdd - lowestEven);
    }
}
