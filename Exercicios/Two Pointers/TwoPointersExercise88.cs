namespace Exercicios.Two_Pointers;

public class TwoPointersExercise88
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int last = m + n - 1; //Usamos (-1) pois (m + n) nao leva em consideracao a posicao 0 do array, entao (m + n) sem o -1 teria uma posicao a mais, ja que o array comeca com 0.

        //Merge em ordem reversa (vamos preencher do maior numero ao menor)
        while (m > 0 && n > 0) 
        {
            if (nums1[m - 1] > nums2[n - 1])
            {
                nums1[last] = nums1[m - 1];
                m--;
            }
            else
            {
                nums1[last] = nums2[n - 1];
                n--;
            }
            last--;
        }

        //Se sobrar elementos no nums2, colocamos eles agora no inicio do array nums1.
        while (n > 0)
        {
            nums1[last] = nums2[n - 1];
            n--;
            last--;
        }
    }
}
