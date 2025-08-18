using System.Security.AccessControl;

namespace Exercicios.Binary_Search;

public class KokoEatingBananasEx875
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int leftPointer = 1, rightPointer = piles.Max(); //O nosso binary search sera feito com base no range de menor velocidade de comer possivel e maior velocidade possivel, a menor sempre sera 1. A koko teoricamente poderia comer 1 banana por hora e dar sucesso, e o PIOR caso seria o maior valor do array de piles, pois se houvessem 3 pilhas e 3 horas, entao para koko comer todas as bananas ela teria que comer por hora o numero de bananas da maior pilha entre as 3 pilhas.
                                                         //Entao para o caso de piles = [3,6,7,11], o nosso binary search visualizado ficaria assim [1,2,3,4,5,6,7,8,9,10,11], e nos iremos fazer um binary search nesse range.

        int response = rightPointer; //Inicialmente a nossa resposta sera o numero maximo do range, pois esse nos temos certeza ABSOLUTA que daria certo e a koko comeria todas as bananas. So nao eh necessariamente a MENOR quantidade de bananas comidas por hora que a koko pode comer, mas eh valido.

        while (leftPointer <= rightPointer) 
        { 
            int middle = leftPointer + ((rightPointer - leftPointer) / 2);

            long totalTime = 0;
            foreach (int pile in piles) 
            {
                totalTime += (int) Math.Ceiling((double) pile / middle);
            }

            if (totalTime > h)
            {
                leftPointer = middle + 1;
            }
            else 
            {
                response = middle;
                rightPointer = middle - 1;
            }
        }

        return response;
    }
}
