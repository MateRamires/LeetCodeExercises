namespace Exercicios.Array___Hash;

public class ArrayHashExercise2965
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        var dict = new Dictionary<int, int>();
        var range = grid.Length * grid.Length;

        for (int i = 1; i <= range; i++) 
            dict.Add(i, 0);

        for (int row = 0; row < grid.Length; row++)
        {
            for (int i = 0; i < grid[row].Length; i++) 
            {
                dict[grid[row][i]]++;
            }
        }

        var answer = new int[2];
        foreach (var pair in dict) 
        { 
            if(pair.Value == 2)
                answer[0] = pair.Key;

            if (pair.Value == 0)
                answer[1] = pair.Key;
        }

        return answer;
    }
}
