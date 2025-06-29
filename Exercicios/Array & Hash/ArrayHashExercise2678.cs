namespace Exercicios.Array___Hash;

public class ArrayHashExercise2678
{
    public int CountSeniors(string[] details)
    {
        int numberOfCitizensOlderThan60 = 0;
        foreach (var detail in details) 
        {
            if (int.Parse("" + detail[11] + detail[12]) >= 61)
                numberOfCitizensOlderThan60++;
        }
        return numberOfCitizensOlderThan60;
    }
}
