namespace Exercicios.Sliding_Window;

public class SlidingWindowExercise209
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int leftPointer = 0, total = 0;
        int res = int.MaxValue;

        for (int rightPointer = 0; rightPointer < nums.Length; rightPointer++) //Em sliding Window comecamos o ponteiro esquerdo no 0, e o direito no 0 tbm, mas o direito, vai aumentando no for, enquanto o esquerdo, vai aumentar caso batemos a condicao, que veremos mais abaixo.
        { 
            total += nums[rightPointer]; //O total sera a variavel que ira se comparar com o target, durante cada iteracao do for.

            while (total >= target) //Quando nossa variavel total bater ou ser maior que o alvo, entraremos num loop
            { 
                res = Math.Min(res, rightPointer - leftPointer + 1); //Dentro do loop, nos primeiramente iremos alterar nossa variavel res, calculando qual o tamanho do subarray que foi necessario para chegar no target. 
                total -= nums[leftPointer]; //Depois iremos tirar da nossa variavel total, o valor do inicio da janela, o leftPointer.
                leftPointer++; //E iremos aumentar + 1 na nossa janela do leftPointer.
            } //Caso, mesmo tirando o primeiro valor da janela, nosso total AINDA seja maior ou igual target, nos continuaremos no loop, atualizando o res com -1 casa, e tirando mais um numero da janela a partir do leftPointer, ATE total ser menor que target, ai voltamos para o loop do for original, que iremos mover a janela do rightPointer.
        }

        return res == int.MaxValue ? 0 : res;
    }
}
