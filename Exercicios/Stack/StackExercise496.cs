namespace Exercicios.Stack;

public class StackExercise496
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        Dictionary<int, int> nextGreater = new Dictionary<int, int>();
        Stack<int> monotonic = new Stack<int>();

        for (int i = nums2.Length - 1; i >= 0; i--)
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
