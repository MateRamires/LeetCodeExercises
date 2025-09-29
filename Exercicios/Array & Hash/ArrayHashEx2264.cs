namespace Exercicios.Array___Hash;

public class ArrayHashEx2264
{
    public string LargestGoodInteger(string num)
    {
        int currentAmmountOfSameInt = 0;
        int maximumGoodInt = int.MinValue;
        for (int i = 0; i < num.Length; i++)
        {
            if (i > 0 && num[i] != num[i - 1]) 
                currentAmmountOfSameInt = 0;

            currentAmmountOfSameInt++;

            if (currentAmmountOfSameInt == 3) 
                maximumGoodInt = Math.Max(maximumGoodInt, int.Parse(num[i].ToString()));
        }

        return maximumGoodInt == int.MinValue ? "" : string.Concat(maximumGoodInt, maximumGoodInt, maximumGoodInt);
    }
}
