namespace Exercicios.Sliding_Window;

public class SlidingWindowExercise1652
{
    public int[] Decrypt(int[] code, int k) 
    {
        //Esse exercicio usa um array circular, para tratar elementos de um array circular, podemos utilizar modulo (%). A logica eh a seguinte, pegaremos o ponteiro do elemento que esta "out-of-bounds" que sera o momento onde o array vai cirular e iremos fazer esse ponteiro MODULO tamanho do array (rightPointer % array.Length -1) vamos supor que o rightPointer esta na posicao 4, ou seja, no primeiro elemento apos o array cirular, se fizermos 4 % 4 (tamanho do array) receberemos 0, que eh exatamente o index que queremos, o primeiro elemento do array apos ele cirular.

        int[] answer = new int[code.Length];

        if (k == 0) return answer;

        int leftPointer = 0;
        int currentSum = 0;
        for (int rightPointer = 0; rightPointer < code.Length + Math.Abs(k); rightPointer++)
        {
            currentSum += code[rightPointer % code.Length];

            if (rightPointer - leftPointer + 1 > Math.Abs(k)) 
            { 
                currentSum -= code[leftPointer % code.Length];
                leftPointer = (leftPointer + 1) % code.Length;
            }

            if (rightPointer - leftPointer + 1 == Math.Abs(k)) 
            {
                if (k > 0)
                    answer[(leftPointer - 1 + code.Length) % code.Length] = currentSum;
                else if (k < 0)
                    answer[(rightPointer + 1) % code.Length] = currentSum;
            }
        }

        return answer;
    }
}
