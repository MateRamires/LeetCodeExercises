using System.Text;

namespace Exercicios.Two_Pointers;

public class TwoPointersExercise2109
{
    public string AddSpaces(string s, int[] spaces)
    {
        var sb = new StringBuilder(s.Length + spaces.Length); //Tem quer usar stringBuilder, pois so com string vai estourar o tempo limite, ja que para cada adicao de letra a string, sera criado uma nova string, que demora muito mais. Usando string builder, ele ira realmente adicionar letra a letra, sem ter que criar uma nova string a cada adicao.

        int spacesReaderPointer = 0;

        for (int i = 0; i < s.Length; i++) 
        {
            if (spacesReaderPointer < spaces.Length && i == spaces[spacesReaderPointer]) 
            {
                sb.Append(' ');
                spacesReaderPointer++;
            }
            sb.Append(s[i]);
        }

        return sb.ToString();
    }
}
