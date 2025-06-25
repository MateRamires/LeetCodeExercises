namespace Exercicios.Two_Pointers;

public class TwoPointersExercise1662
{
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        int pointerWord1 = 0, pointerWord2 = 0;
        int pointerChar1 = 0, pointerChar2 = 0;

        while (pointerWord1 < word1.Length && pointerWord2 < word2.Length) 
        {
            if (word1[pointerWord1][pointerChar1] != word2[pointerWord2][pointerChar2])
                return false;

            pointerChar1++; pointerChar2++;

            if (word1[pointerWord1].Length <= pointerChar1) 
            {
                pointerWord1++;
                pointerChar1 = 0;
            }

            if (word2[pointerWord2].Length <= pointerChar2)
            {
                pointerWord2++;
                pointerChar2 = 0;
            }
        }

        return pointerWord1 == word1.Length && pointerWord2 == word2.Length; //Se sair do while, e algum dos dois arrays nao tiverem atingido o seu total de palavras (chegos ao fim) isso quer dizer que esse array eh maior que o outro em caracteres, portanto as palavras nao sao iguais e devemos retornar false.
    }
}
