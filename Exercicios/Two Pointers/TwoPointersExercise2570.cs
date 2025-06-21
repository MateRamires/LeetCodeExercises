namespace Exercicios.Two_Pointers;

public class TwoPointersExercise2570
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        int readPointer1 = 0, readPointer2 = 0;
        List<List<int>> resultArray = new List<List<int>>();
        while (readPointer1 < nums1.Length && readPointer2 < nums2.Length) 
        {
            if (nums1[readPointer1][0] == nums2[readPointer2][0])
            {
                resultArray.Add(new List<int> { nums1[readPointer1][0], nums1[readPointer1][1] + nums2[readPointer2][1] });
                readPointer1++;
                readPointer2++;
            }
            else if (nums1[readPointer1][0] < nums2[readPointer2][0])
            {
                resultArray.Add(new List<int> { nums1[readPointer1][0], nums1[readPointer1][1] });
                readPointer1++;
            }
            else if (nums1[readPointer1][0] > nums2[readPointer2][0]) 
            {
                resultArray.Add(new List<int> { nums2[readPointer2][0], nums2[readPointer2][1] });
                readPointer2++;
            }
        }

        while (readPointer1 < nums1.Length) 
        {
            resultArray.Add(new List<int> { nums1[readPointer1][0], nums1[readPointer1][1] });
            readPointer1++;
        }

        while (readPointer2 < nums2.Length)
        {
            resultArray.Add(new List<int> { nums2[readPointer2][0], nums2[readPointer2][1] });
            readPointer2++;
        }

        return resultArray.Select(sublist => sublist.ToArray()).ToArray();
    }
}
