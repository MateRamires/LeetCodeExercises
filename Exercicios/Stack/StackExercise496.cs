namespace Exercicios.Stack;

public class StackExercise496
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        Dictionary<int, int> nextGreater = new Dictionary<int, int>();
        Stack<int> monotonic = new Stack<int>();

        for (int i = nums2.Length - 1; i >= 0; i--) //Base do monotonic stack: SEMPRE vamos adicionar o numero atual a stack, mas antes, precisamos rodar um while removendo todos os numeros presentes na stack que sao menores que o numero atual (ou maiores, dependendo do exercicio), se ainda restar algum numero na stack, significa que ha um valor que atende as nossas condicoes, e no ternario, iremos ver que o stack ainda tem valores, portanto colocamos o valor mais proximo do stack. Por isso usamos stack, pois estamos buscando os valores mais PROXIMOS, entao o valor do peek, eh justamente o mais proximo do numero atual que atende as condicoes
        {
            int num = nums2[i];

            while (monotonic.Count > 0 && monotonic.Peek() <= num)
                monotonic.Pop();

            nextGreater[num] = monotonic.Count == 0 ? -1 : monotonic.Peek();
            monotonic.Push(num);
        }

        int[] answer = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            answer[i] = nextGreater[nums1[i]];
        }
        return answer;
    }
}
